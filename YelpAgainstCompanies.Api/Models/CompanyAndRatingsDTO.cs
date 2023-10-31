namespace YelpAgainstCompanies.Api.Models;

public class CompanyAndRatingsDTO
{
    public CompanyAndRatingsDTO()
    {
        Ratings = new List<RatingDTO>();
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public double Score { get; set; }

    public int NumberOfRatings { get; set; }

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }

    public List<RatingDTO> Ratings { get; set; }
}
