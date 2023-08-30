using Microsoft.AspNetCore.Mvc;
using YelpAgainstCompanies.Domain.Interfaces;

namespace YelpAgainstCompanies.Api.Controllers;

[ApiController]
[Route("controller")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
}
