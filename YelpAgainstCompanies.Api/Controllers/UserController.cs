namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("user-management")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly Transformations _transformations;
    private readonly IRatingService _ratingService;

    public UserController(IUserService userService, Transformations transformations, IRatingService ratingService)
    {
        _userService = userService;
        _transformations = transformations;
        _ratingService = ratingService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        JwtSecurityToken bearerToken = GetBearerToken() ?? throw new NotLoggedInException(HttpContext.Request.Path);
        string userName = bearerToken.Claims.Single(c => c.Type == "Username").Value;
        var user = await _userService.GetUser(userName)
            ?? throw new UserDoesNotExistException($"/user-management/{userName}");

        var userRatings = await _ratingService.Get(user);
        var userRatingsDTO = userRatings.Select(x => _transformations.Transform(x));

        var userDTO = _transformations.Transform(user, userRatingsDTO);

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
