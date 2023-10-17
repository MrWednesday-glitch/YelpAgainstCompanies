using Microsoft.AspNetCore.Authorization;

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
            var company = _transformations.Transform(await _companyService.Get(id));

            return Ok(company);
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
        //TODO Write checks to ensure the data here is proper (like a regex that says that an address and postalcode are good
        var company = new Company
        {
            Name = companyDTO.Name,
            Address = companyDTO.Address,
            City = companyDTO.City,
            PictureUrl = companyDTO.PictureUrl,
            PostalCode = companyDTO.PostalCode,
            Score = 0, //TODO Do something different here?
        };

        try
        {
            await _companyService.Create(company);

            //TODO Send proper information back and have the front end respons to it properly by have a major success message and going back to the updated companylist
            return Ok(new
            {
                Message = $"The company {company.Name} has been saved to the database."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
