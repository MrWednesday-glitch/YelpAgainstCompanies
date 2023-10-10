namespace YelpAgainstCompanies.Domain.Interfaces;

public interface ICompanyService
{
    /// <summary>
    /// Deals with a singular company that is retrieved from the database.
    /// </summary>
    /// <param name="id">The id of the company that is needed to be retrieved.</param>
    /// <returns>A company entity.</returns>
    Task<Company> Get(int id);

    /// <summary>
    /// Deals with getting all the companies from the database.
    /// </summary>
    /// <returns>A collection of company entities from the database.</returns>
    Task<IEnumerable<Company>> Get();
}
