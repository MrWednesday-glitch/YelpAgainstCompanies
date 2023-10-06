namespace YelpAgainstCompanies.Api.Models;

//TODO Seperate the company dto from the rating dto => give this location data, and use name + location to find the corresponding collection of ratings
//TODO Give a number that says how many ratings it has
//TODO Also do this in the angular model
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
