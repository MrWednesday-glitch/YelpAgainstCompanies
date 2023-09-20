namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("company")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    private CompanyDTO Transform(Company company)
    {
        var companyDTO = new CompanyDTO()
        {
            Name = company.Name,
            Score = company.Score,
        };

        var ratings = new List<RatingDTO>();
        foreach (var rating in company.Ratings)
        {
            ratings.Add(Transform(rating));
        }

        companyDTO.Ratings = ratings;

        return companyDTO;
    }

    //TODO move this somewhere else
    private RatingDTO Transform(Rating rating) => new()
    {
        Date = rating.Date.ToLongDateString(),
        Comment = rating.Comment,
        Score = rating.Score,
        UserName = $"{rating.User.FirstName} {rating.User.LastName}"
    };

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = (await _companyService.Get()).Select(x => Transform(x));

        return Ok(companies);
    }
}
