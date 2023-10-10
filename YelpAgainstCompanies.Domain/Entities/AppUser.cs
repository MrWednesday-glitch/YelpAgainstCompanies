namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; }
}
