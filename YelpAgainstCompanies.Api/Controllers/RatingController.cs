namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("rating")]
public class RatingController : Controller
{
    private readonly IRatingService _ratingService;
    private readonly Transformations _transformations;

    public RatingController(IRatingService ratingService, Transformations transformations)
    {
        _ratingService = ratingService;
        _transformations = transformations;
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
}
