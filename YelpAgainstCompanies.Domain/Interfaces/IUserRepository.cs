namespace YelpAgainstCompanies.Domain.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Gets a user from the database based on their username(email).
    /// </summary>
    /// <param name="username">The given username(email)</param>
    /// <returns>The user.</returns>
    AppUser GetUser(string username);
}
