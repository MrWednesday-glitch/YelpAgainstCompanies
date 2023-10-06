namespace YelpAgainstCompanies.Domain.Interfaces;

//TODO Write documenmtation
public interface ICompanyService
{
    Task<Company> Get(int id);

    Task<IEnumerable<Company>> Get();
}
