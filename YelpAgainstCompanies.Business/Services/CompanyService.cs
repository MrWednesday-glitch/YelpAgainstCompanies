namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IRatingService _ratingService;

    public CompanyService(ICompanyRepository companyRepository, IRatingService ratingService)
    {
        _companyRepository = companyRepository;
        _ratingService = ratingService;
    }

    //TODO Add a method to calculate the average of the ratings based on what is in the ratings and apply it to the get methods
    public async Task<IEnumerable<Company>> Get()
    {
        var companies = _companyRepository.GetRecords()
            .OrderBy(x => x.Name)
            .ThenBy(y => y.City);

        return companies;
    } 

    public async Task<Company> Get(int id)
    {
        var company = _companyRepository.GetRecord(id)
            ?? throw new ArgumentNullException("No company was found with this id.");

        return company;
    } 
}
