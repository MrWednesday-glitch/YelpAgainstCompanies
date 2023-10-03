namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class JwtAuthorityResult
{
    public string AccessToken { get; set; }

    public RefreshToken RefreshToken { get; set; }
}
