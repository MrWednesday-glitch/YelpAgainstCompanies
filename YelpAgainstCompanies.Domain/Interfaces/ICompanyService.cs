using YelpAgainstCompanies.Domain.Entities;

namespace YelpAgainstCompanies.Domain.Interfaces;

public interface ICompanyService
{
    Company Get(int id);

    List<Company> Get();
}
