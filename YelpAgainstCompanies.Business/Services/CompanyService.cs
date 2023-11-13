namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<Company>> Get()
    {
        var companies = _companyRepository.GetRecords()
            .OrderBy(x => x.Name)
            .ThenBy(y => y.City);

        return companies;
    }

    public async Task<Company> Get(int id)
    {
        var company = _companyRepository.GetRecord(id);

        return company;
    }

    public async Task Create(Company company)
    {
        if (!company.Address.IsValidAddress())
        {
            throw new Exception("The address is not properly entered.");
        }

        if (!company.PostalCode.IsValidPostalCode())
        {
            throw new Exception("The postal code is not properly entered.");
        }

        if (await ExistingCompanyInDB(company) != null)
        {
            throw new Exception("The company you tried to create already exists.");
        }

        await _companyRepository.CreateRecord(company);
        await _companyRepository.SaveChanges();
    }

    private async Task<Company?> ExistingCompanyInDB(Company company) =>
        _companyRepository.GetRecords()
            .SingleOrDefault(x =>
                x.Name == company.Name &&
                x.PostalCode == company.PostalCode);

    public async Task<Company> AddToCompany(Rating rating)
    {
        if (rating.CompanyId <= 0)
        {
            throw new Exception("You tried to enter a comment to a company that does not exist.");
        }

        if (rating.Score < 1 || rating.Score > 5)
        {
            throw new Exception("You tried to enter an impossible score, or not score the company at all.");
        }

        var company = await Get(rating.CompanyId);

        company.Ratings.Add(rating);
        company.Score = company.Ratings.Average(x => x.Score);
        await _companyRepository.SaveChanges();

        return company;
    }
}
