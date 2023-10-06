namespace YelpAgainstCompanies.Api.Models;

public class CompanyDTO
{
    public string Name { get; set; } = string.Empty;

    public double Score { get; set; }

    public int NumberOfRatings { get; set; }

    public string Address { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }
}
