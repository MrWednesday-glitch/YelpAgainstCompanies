namespace YelpAgainstCompanies.Api.Models;

public class UserDTO
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<RatingDTO> Ratings { get; set; } = new List<RatingDTO>();
}
