namespace YelpAgainstCompanies.Api.Helpers;

//TODO Turn this into a static extension methods
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
            Id = company.Id,
            Name = company.Name,
            Score = company.Score, //TODO Have this rounded to 1 decimal
            Address = company.Address,
            PostalCode = company.PostalCode,
            City = company.City,
            NumberOfRatings = company.Ratings.Count,
            PictureUrl = company.PictureUrl,
        };

        return companyDTO;
    }

    public RatingDTO Transform(Rating rating) => new()
    {
        Date = rating.Date.ToLongDateString(),
        Name = $"{rating.User.FirstName} {rating.User.LastName}",
        Score = rating.Score,
        Comment = rating.Comment,
    };
}
