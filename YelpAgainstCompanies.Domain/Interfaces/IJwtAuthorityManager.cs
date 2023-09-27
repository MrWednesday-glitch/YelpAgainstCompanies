namespace YelpAgainstCompanies.Domain.Interfaces;

/// <summary>
/// Defines the interface for the JwtAuthorityManager, used to operate JWT tokens.
/// </summary>
public interface IJwtAuthorityManager
{
    /// <summary>
    /// A method used to generate a JWT Token
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="claims"></param>
    /// <param name="currentTime"></param>
    /// <returns>>A refresh token and an access token.</returns>
    JwtAuthorityResult GenerateTokens(string userName, Claim[] claims, DateTime currentTime);
}
