namespace YelpAgainstCompanies.Domain.Interfaces;

public interface IRatingService
{
    /// <summary>
    /// A function to retrieve all the ratings attached to a single company.
    /// </summary>
    /// <param name="companyId">The id of the company.</param>
    /// <returns>The ratings attached to a specific company.</returns>
    Task<IEnumerable<Rating>> Get(int companyId);

    /// <summary>
    /// A function to retrieve all the ratings made by a singular user.
    /// </summary>
    /// <param name="user">The user object that will be used to retrieve the collection of comments.</param>
    /// <returns>A collection of comments that the user has made.</returns>
    Task<IEnumerable<Rating>> Get(AppUser user);
}
