using YelpAgainstCompanies.Domain.Entities;

namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("companies")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    private readonly Transformations _transformations;
    private readonly IUserService _userService;
    private const int MaxCompanyPageSize = 20;

    public CompanyController(ICompanyService companyService, Transformations transformations, IUserService userService)
    {
        _companyService = companyService;
        _transformations = transformations;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies(int pageNumber = 1, int pageSize = 10, string? searchTerm = "", string? cityName = "")
    {
        if (pageSize > MaxCompanyPageSize)
        {
            pageSize = MaxCompanyPageSize;
        }

        var (companies, paginationMetadata) = (await _companyService.Get(pageNumber, pageSize, searchTerm, cityName));
        var companiesDTO = companies.Select(x => _transformations.Transform(x));

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(companiesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company = await _companyService.Get(id);

        var companyAndRatingsDTO = _transformations.Transform(company, company.Ratings);

        return Ok(companyAndRatingsDTO);
    }

    //[Authorize]
    [HttpPost]
    public async Task<IActionResult> SaveCompanyToDatabase([FromBody] CompanyDTO companyDTO)
    {
        var company = new Company
        {
            Name = companyDTO.Name.Trim(),
            Address = companyDTO.Address.Trim(),
            City = companyDTO.City.Trim(),
            PictureUrl = companyDTO.PictureUrl, //TODO Add a picture here if the pictureURL equals null
            PostalCode = companyDTO.PostalCode.Trim(),
            Score = 0, //TODO Do something different here?
        };

        await _companyService.Create(company);

        return Ok(new
        {
            Message = $"The company {company.Name} has been saved to the database.",
            Success = true
        });
    }

    //TODO Maybe move this back to the ratingcontroller?
    [Authorize]
    [HttpPost("{companyId}/rating")]
    public async Task<IActionResult> AttachRatingToCompany([FromBody] MadeRating madeRating, int companyId)
    {
        JwtSecurityToken bearerToken = GetBearerToken() ?? throw new NotLoggedInException(HttpContext.Request.Path);
        string userName = bearerToken.Claims.Single(c => c.Type == "Username").Value;
        var user = _userService.GetUser(userName);

        var rating = new Rating
        {
            Comment = madeRating.Comment ?? "//The user did not add a comment to their score//.",
            Date = DateTime.Now,
            CompanyId = companyId,
            Score = madeRating.Score,
            User = user,
            UserId = user.Id,
        };

        var updateCompany = await _companyService.AddToCompany(rating);
        var companyAndRatingsDTO = _transformations.Transform(updateCompany, updateCompany.Ratings);

        return Ok(new
        {
            Message = $"The rating to {companyAndRatingsDTO.Name} has been added.",
            Success = true
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCompanyFromDatabase(int id)
    {
        var company = await _companyService.Get(id);
        await _companyService.Delete(company);

        return Ok(new
        {
            Message = $"The company {company} has been removed from the database.",
            Success = true
        });
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
