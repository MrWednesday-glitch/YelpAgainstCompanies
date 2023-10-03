namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    //TODO Add a method to calculate the average of the ratings based on what is in the ratings and apply it to the get methods
    public async Task<IEnumerable<Company>> Get() => _companyRepository.GetRecords();

    public async Task<Company> Get(int id) => _companyRepository.GetRecord(id)
        ?? throw new ArgumentNullException("No company was found with this id.");
}
