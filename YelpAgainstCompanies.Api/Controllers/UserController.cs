namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("user-management")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly Transformations _transformations;

    public UserController(IUserService userService, Transformations transformations)
    {
        _userService = userService;
        _transformations = transformations;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        JwtSecurityToken bearerToken = GetBearerToken() ?? throw new NotLoggedInException(HttpContext.Request.Path);
        string userName = bearerToken.Claims.Single(c => c.Type == "Username").Value;
        var user = _userService.GetUser(userName)
            ?? throw new UserDoesNotExistException($"/user-management/{userName}");
        var userDTO = _transformations.Transform(user);

        return Ok(userDTO);
    }

    //TODO Put getting the bearertoken and user in a seperate class
    private JwtSecurityToken? GetBearerToken()
    {
        IEnumerable<string> authValues = Request.Headers.Authorization;

        if (authValues.Any())
        {
            string[] token = authValues.First().Split(' ');
            if (token.Length == 2 && token.First() == "Bearer")
            {
                return new JwtSecurityTokenHandler().ReadJwtToken(token.Last());
            }
        }

        return null;
    }
}
