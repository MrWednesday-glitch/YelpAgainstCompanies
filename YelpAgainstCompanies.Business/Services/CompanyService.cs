using Microsoft.EntityFrameworkCore;
using YelpAgainstCompanies.Domain;

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

    public async Task<(IEnumerable<Company>, PaginationMetadata)> Get(int pageNumber, int pageSize)
    {
        var companyCollection = await _companyRepository.GetRecords();

        var totalItemCount = companyCollection.Count();
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

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

    private async Task<Company?> ExistingCompanyInDB(Company company) =>
      (await _companyRepository.GetRecords())
            .SingleOrDefault(x =>
                x.Name == company.Name &&
                x.PostalCode == company.PostalCode);

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
}
