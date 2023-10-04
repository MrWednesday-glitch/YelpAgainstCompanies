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

    //TODO Add location (street, postal code, city) + picture url?

    public virtual IEnumerable<Rating> Ratings { get; set; }
}
