namespace YelpAgainstCompanies.Api.Models;

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
