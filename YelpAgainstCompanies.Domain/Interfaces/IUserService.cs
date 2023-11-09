namespace YelpAgainstCompanies.Domain.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Gets a user based on their username(email).
    /// </summary>
    /// <param name="username">The given username(email)</param>
    /// <returns>The user.</returns>
    AppUser GetUser(string username);
}
