namespace YelpAgainstCompanies.Api.Models;

//TODO Seperate the company dto from the rating dto => give this location data, and use name + location to find the corresponding collection of ratings
//TODO Give a number that says how many ratings it has
//TODO Also do this in the angular model
public class CompanyDTO
{
    public CompanyDTO()
    {
        Ratings = new List<RatingDTO>();
    }

    public string Name { get; set; } = string.Empty;

    public double Score { get; set; }

    public List<RatingDTO> Ratings { get; set; }
}
