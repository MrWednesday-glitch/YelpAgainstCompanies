using Microsoft.AspNetCore.WebUtilities;

namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("authority")]
public class AuthorityController : Controller
{
    private readonly IJwtAuthorityManager _jwtAuthorityManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IOptions<ApiBehaviorOptions> _apiBehaviorOptions;

    public AuthorityController(
        IJwtAuthorityManager jwtAuthorityManager,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IOptions<ApiBehaviorOptions> apiBehaviorOptions)
    {
        _jwtAuthorityManager = jwtAuthorityManager;
        _userManager = userManager;
        _signInManager = signInManager;
        _apiBehaviorOptions = apiBehaviorOptions;
    }

    [HttpPost("token")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        try
        {
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var claims = new[]
                {
                    new Claim("Username", user.UserName),
                    new Claim("Role", "guest"),
                    new Claim("Email", user.Email)
                };

                var jwtResult = _jwtAuthorityManager.GenerateTokens(user.UserName, claims, DateTime.Now);

                return Ok(new
                {
                    UserName = user.UserName,
                    Role = "guest",
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            else
            {
                return Unauthorized();
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }

    //TODO Have first and last name also be registered
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginModel model, [FromQuery] string? returnUrl = null)
    {
        try
        {
            if (!model.Email.IsValidEmail())
            {
                throw new Exception("You did not give a valid email.");
            }

            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email
            };

            if (!model.Password.IsValidPassword())
            {
                throw new Exception("The password you entered does not qualify with the restrictions.");
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return AddIdentityErrors(result);
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            return Ok(new
            {
                Succes = true,
                ConfirmationCode = code
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                ex.Message,
                InnerExceptionMessage = ex.InnerException?.Message
            });
        }
    }

    private IActionResult AddIdentityErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
    }
}
