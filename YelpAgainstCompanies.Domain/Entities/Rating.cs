namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Rating : EntityBase
{
    public DateTime Date { get; set; }

    public Guid UserId { get; set; }

    public double Score { get; set; }

    public string? Comment { get; set; }

    public int CompanyId { get; set; }

    public virtual AppUser User { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
