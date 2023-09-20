namespace YelpAgainstCompanies.Domain.Interfaces;

public interface ICompanyService
{
    Task<Company> Get(int id);

    Task<IEnumerable<Company>> Get();
}
