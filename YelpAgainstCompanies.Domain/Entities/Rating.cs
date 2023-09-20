namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Rating : EntityBase
{
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public double Score { get; set; }

    public string? Comment { get; set; }
}
