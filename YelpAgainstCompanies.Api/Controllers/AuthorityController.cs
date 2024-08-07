﻿namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("authority-management")]
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
        var result = await _signInManager
            .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new UserDoesNotExistException(HttpContext.Request.Path);
            var claims = new[]
            {
                    new Claim("Username", user.UserName ?? "No username found."),
                    new Claim("Role", "guest"),
                    new Claim("Email", user.Email ?? "No email found."),
                    new Claim("Firstname", user.FirstName),
                    new Claim("Lastname", user.LastName ?? "No last name found.")
                };

            var jwtResult = _jwtAuthorityManager.GenerateTokens(user.UserName ?? throw new UserDoesNotExistException(HttpContext.Request.Path), claims, DateTime.Now);

            return Ok(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName ?? "No lastname found.",
                UserName = user.UserName,
                Role = "guest",
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        else
        {
            return Unauthorized("An incorrect account/password combination. Check if your account exists or enter the correct password.");
        }
    }

    //TODO Seperate the loginModel into a seperate registermodel so that the loginmodel does not need superfluous data
    [HttpPost("user")]
    public async Task<IActionResult> Register([FromBody] LoginModel model, [FromQuery] string? returnUrl = null)
    {
        if (!model.Email.IsValidEmail())
        {
            throw new StringNotValidException("email", HttpContext.Request.Path);
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
            throw new StringNotValidException("password", HttpContext.Request.Path);
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

    private IActionResult AddIdentityErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
    }
}
