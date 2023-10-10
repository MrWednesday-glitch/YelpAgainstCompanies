namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

//TODO Fix this
[ExcludeFromCodeCoverage]
public class Base
{
    public readonly ICompanyService _companyService;
    public readonly Mock<ICompanyRepository> _mockedCompanyRepository;

    public Base()
    {
        _mockedCompanyRepository = new Mock<ICompanyRepository>();
        _companyService = new CompanyService(_mockedCompanyRepository.Object);
    }
}
