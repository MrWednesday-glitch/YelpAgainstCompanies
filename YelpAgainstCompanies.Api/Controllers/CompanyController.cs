namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("company")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;
    private readonly Transformations _transformations;

    public CompanyController(ICompanyService companyService, Transformations transformations)
    {
        _companyService = companyService;
        _transformations = transformations;
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
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
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
            return BadRequest(new
            {
                Message = ex.Message,
                Success = false
            });
        }
    }
}
