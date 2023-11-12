namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("company")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    private readonly Transformations _transformations;
    private readonly IUserService _userService;

    public CompanyController(ICompanyService companyService, Transformations transformations, IUserService userService)
    {
        _companyService = companyService;
        _transformations = transformations;
        _userService = userService;
    }

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = (await _companyService.Get())
            .Select(x => _transformations.Transform(x));

        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        try
        {
            var company = await _companyService.Get(id);

            var companyAndRatingsDTO = _transformations.Transform(company, company.Ratings);

            return Ok(companyAndRatingsDTO);
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/something/or/another",
                Title = ex.Message,
                Detail = ex.StackTrace,
                Instance = HttpContext.Request.Path
            };
            return NotFound(problemDetails);
        }
    }

    [Authorize]
    [HttpPost("savecompanytodatabase")]
    public async Task<IActionResult> SaveCompanyToDatabase([FromBody] CompanyDTO companyDTO)
    {
        var company = new Company
        {
            Name = companyDTO.Name.Trim(),
            Address = companyDTO.Address.Trim(),
            City = companyDTO.City.Trim(),
            PictureUrl = companyDTO.PictureUrl,
            PostalCode = companyDTO.PostalCode.Trim(),
            Score = 0, //TODO Do something different here?
        };

        try
        {
            await _companyService.Create(company);

            return Ok(new
            {
                Message = $"The company {company.Name} has been saved to the database.",
                Success = true
            });
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Type = "a site",
                Title = ex.Message,
                Detail = ex.StackTrace,
                Instance = HttpContext.Request.Path
            };
            //TODO Ensure Angular can take this.
            //TODO Test this in postman
            return BadRequest(problemDetails);
            //return BadRequest(new
            //{
            //    Message = ex.Message,
            //    Success = false
            //});
        }
    }

    [Authorize]
    [HttpPost("attachratingtocompany/{companyId}")]
    public async Task<IActionResult> AttachRatingToCompany([FromBody] MadeRating madeRating, int companyId)
    {
        try
        {
            JwtSecurityToken bearerToken = GetBearerToken() ?? throw new Exception("Cannot add comment when not logged in.");
            string userName = bearerToken.Claims.Single(c => c.Type == "Username").Value;
            var user = _userService.GetUser(userName);

            var rating = new Rating
            {
                Comment = madeRating.Comment ?? "//The user did not add a comment to his score//.",
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
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Type = "a site",
                Title = ex.Message,
                Detail = ex.StackTrace,
                Instance = HttpContext.Request.Path
            };
            //TODO Ensure Angular can take this.
            //TODO Test this in postman
            return BadRequest(problemDetails);

            //return BadRequest(new
            //{
            //    Message = ex.Message,
            //    Success = false
            //});
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
