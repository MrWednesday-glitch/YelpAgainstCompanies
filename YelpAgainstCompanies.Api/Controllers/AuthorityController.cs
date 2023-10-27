using Microsoft.AspNetCore.WebUtilities;

//TODO In angular => merge the login form and register form into one form, like other sites have it
//TODO In Angular => Have pressing buttons return to previous screens (like login returning to the main screen
//TODO In angular => Have it send the user back to the mainscreen when jwt is no longer valid
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

    //TODO In angular => have a succesfull login send the user to the main page.
    [HttpPost("token")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        try
        {
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new Exception("No user found.");
                var claims = new[]
                {
                    new Claim("Username", user.UserName ?? "No username found."),
                    new Claim("Role", "guest"),
                    new Claim("Email", user.Email ?? "No email found."),
                    new Claim("Firstname", user.FirstName),
                    new Claim("Lastname", user.LastName ?? "No last name found.")
                };

                var jwtResult = _jwtAuthorityManager.GenerateTokens(user.UserName ?? throw new Exception("No username found"), claims, DateTime.Now);

                return Ok(new
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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

    //TODO Seperate the loginModel into a seperate registermodel so that the loginmodel does not need superfluous data
    //TODO In Angular => have a succesful register automatically send the user to the login page
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
