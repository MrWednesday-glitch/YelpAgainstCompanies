namespace YelpAgainstCompanies.Api.Models;

public class RatingDTO
{
    public string Date { get; set; }

    public string UserName { get; set; }

    public double Score { get; set; }

    public string? Comment { get; set; }
}
