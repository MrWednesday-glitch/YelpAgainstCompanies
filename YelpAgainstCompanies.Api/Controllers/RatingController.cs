using System.IdentityModel.Tokens.Jwt;

namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("rating")]
public class RatingController : Controller
{
    private readonly IRatingService _ratingService;
    private readonly Transformations _transformations;
    private readonly IUserService _userService;

    public RatingController(IRatingService ratingService, Transformations transformations, IUserService userService)
    {
        _ratingService = ratingService;
        _transformations = transformations;
        _userService = userService;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetRatingsForCompany(int companyId)
    {
        try
        {
            var ratings = (await _ratingService.Get(companyId))
                .Select(x => _transformations.Transform(x));

            return Ok(ratings);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpPost("attachratingtocompany")]
    public async Task<IActionResult> AttachRatingToCompany([FromBody] MadeRating madeRating, [FromBody] int companyId)
    {
        try
        {
            JwtSecurityToken bearerToken = GetBearerToken() ?? throw new Exception("Cannot add comment when not logged in.");
            string userName = bearerToken.Claims.Single(c => c.Type == ClaimTypes.Name).Value;
            var user = _userService.GetUser(userName);

            var rating = new Rating
            {
                Comment = madeRating.Comment ?? "Rater did not add a comment.",
                Date = DateTime.Now,
                CompanyId = companyId, //TODO In the service look up the company via the id => then add the comment to the company via company.ratings.add(rating)
                Score = madeRating.Score,
                //Maybe do this in the ratingservice?
                User = user,
                UserId = user.Id,
            };

            //TODO Add send rating to the service to be added to the database

            return Ok(new
            {
                Message = $"The rating has been added.",
                Success = true
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Message = ex.Message,
                Success = false
            });
        }
    }

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
