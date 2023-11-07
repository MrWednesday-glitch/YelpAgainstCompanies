namespace YelpAgainstCompanies.Domain.Interfaces;

public interface IRatingService
{
    /// <summary>
    /// A function to retrieve all the ratings attached to a single company.
    /// </summary>
    /// <param name="companyId">The id of the company.</param>
    /// <returns>The ratings attached to a specific company.</returns>
    Task<IEnumerable<Rating>> Get(int companyId);
}
