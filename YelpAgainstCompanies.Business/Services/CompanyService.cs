using System.Data.Entity;

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
        var companies = (await _companyRepository.GetRecords())
                    .OrderBy(x => x.Name).ThenBy(y => y.City)
                    .ToList();

        return companies;
    }

    public async Task<(IEnumerable<Company>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "", string? cityName = "")
    {
        var companyCollection = await _companyRepository.GetRecords();
        var cities = companyCollection.Select(c => c.City).Distinct().ToList();

        //TODO Return a collection of all cities specifically to put into a list in the front end to select from
        if (!cityName.IsNullOrEmpty())
        {
            companyCollection = companyCollection.Where(c =>
                c.City == cityName);
        }

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm!.ToLower();

            companyCollection = companyCollection.Where(c =>
                c.Name.ToLower().Contains(searchTerm) ||
                c.City.ToLower().Contains(searchTerm));
        }

        var totalItemCount = companyCollection.Count();
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber, cities);

        var companies = companyCollection
            .OrderBy(c => c.Name).ThenBy(c => c.City)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (companies, paginationMetadata);
    }

    public async Task<Company> Get(int id)
    {
        var company = await _companyRepository.GetRecord(id)
            ?? throw new CompanyDoesNotExistException($"/company/{id}");

        return company;
    }

    public async Task Create(Company company)
    {
        if (!company.Address.IsValidAddress())
        {
            throw new StringNotValidException("address", "/company/savecompanytodatabase");
        }

        company.PostalCode = company.PostalCode.ToLower();
        if (company.PostalCode.Length == 7 && company.PostalCode[4] == ' ')
        {
            company.PostalCode = company.PostalCode.Remove(4, 1);
        }

        if (!company.PostalCode.IsValidPostalCode())
        {
            throw new StringNotValidException("postal code", "/company/savecompanytodatabase");
        }

        if (await ExistingCompanyInDB(company) != null)
        {
            throw new RecordExistsInDatabaseException("company", "/company/savecompanytodatabase");
        }

        await _companyRepository.CreateRecord(company);
        await _companyRepository.SaveChanges();
    }

    private async Task<Company?> ExistingCompanyInDB(Company company)
    {
        return (await _companyRepository.GetRecords())
            .SingleOrDefault(x => x.Name == company.Name && x.PostalCode == company.PostalCode);
    }


    public async Task<Company> AddToCompany(Rating rating)
    {
        if (rating.CompanyId <= 0)
        {
            throw new CompanyDoesNotExistException($"/attachratingtocompany/{rating.CompanyId}");
        }

        if (rating.Score < 1 || rating.Score > 5)
        {
            throw new AttachWrongScoreToCompanyException("You tried to enter an impossible score, or not score the company at all.", $"/attachratingtocompany/{rating.CompanyId}");
        }

        var company = await Get(rating.CompanyId);

        company.Ratings.Add(rating);
        company.Score = company.Ratings.Average(x => x.Score);
        await _companyRepository.SaveChanges();

        return company;
    }

    // TODO Write unit tests
    public async Task<Company> Delete(int id)
    {
        var company = await Get(id);

        if (company.DeletedDate != null) 
        {
            throw new CompanyAlreadyDeletedException($"/companies/{id}");
        }

        await _companyRepository.DeleteRecord(company);
        await _companyRepository.SaveChanges();

        return company;
    }
}
