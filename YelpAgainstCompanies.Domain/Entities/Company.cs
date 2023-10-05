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

    public string Address { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }

    public virtual IEnumerable<Rating> Ratings { get; set; }
}
