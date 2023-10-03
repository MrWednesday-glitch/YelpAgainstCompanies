namespace YelpAgainstCompanies.Api.Models;

public class RatingDTO
{
    public string Date { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public double Score { get; set; }

    public string? Comment { get; set; }
}
