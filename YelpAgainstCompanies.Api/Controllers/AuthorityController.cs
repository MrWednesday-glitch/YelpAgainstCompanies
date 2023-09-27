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
    public async Task<IActionResult> Login([FromBody] LoginModel model) //TODO write LoginModel
    {
        try
        {
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
