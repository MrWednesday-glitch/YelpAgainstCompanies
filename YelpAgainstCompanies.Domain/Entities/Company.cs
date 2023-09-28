namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Company : EntityBase
{
    public Company()
    {
        Ratings = new List<Rating>();
    }

    public string Name { get; set; } = string.Empty;

    public double Score { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; }
}
