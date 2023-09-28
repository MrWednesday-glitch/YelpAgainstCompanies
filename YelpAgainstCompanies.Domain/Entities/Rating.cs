namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Rating : EntityBase
{
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public AppUser User { get; set; }

    public double Score { get; set; }

    public string? Comment { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;
}
