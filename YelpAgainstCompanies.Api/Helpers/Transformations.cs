namespace YelpAgainstCompanies.Api.Helpers;

public class Transformations
{
    private readonly IUserService _userService;

    public Transformations(IUserService userService)
    {
        _userService = userService;
    }

    public CompanyDTO Transform(Company company)
    {
        var companyDTO = new CompanyDTO()
        {
            Name = company.Name,
            Score = company.Score,
            Address = company.Address,
            PostalCode = company.PostalCode,
            City = company.City,
            NumberOfRatings = company.Ratings.Count(),
        };

        return companyDTO;
    }

    private RatingDTO Transform(Rating rating) => new()
    {
        Date = rating.Date.ToLongDateString(),
        Comment = rating.Comment,
        Score = rating.Score,
        Name = $"{rating.User.FirstName} {rating.User.LastName}"
    };
}
