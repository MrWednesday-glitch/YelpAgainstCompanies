using YelpAgainstCompanies.Api.Models;

namespace YelpAgainstCompanies.Api.Helpers;

public class Transformations
{
    private readonly IUserService _userService;

    public Transformations(IUserService userService)
    {
        _userService = userService;
    }

    public CompanyDTO Transform(Company company) => new()
    {
        Id = company.Id,
        Name = company.Name,
        Score = double.Round(company.Score, 1), 
        Address = company.Address,
        PostalCode = company.PostalCode,
        City = company.City,
        NumberOfRatings = company.Ratings.Count,
        PictureUrl = company.PictureUrl,
    };

    public RatingDTO Transform(Rating rating) => new()
    {
        Date = rating.Date.ToLongDateString(),
        Name = $"{rating.User.FirstName} {rating.User.LastName}",
        Score = rating.Score,
        Comment = rating.Comment,
    };

    public CompanyAndRatingsDTO Transform(Company company, ICollection<Rating> ratings)
    {
        var ratingsDTO = new List<RatingDTO>();
        foreach (var rating in ratings)
        {
            ratingsDTO.Add(Transform(rating));
        }

        return new CompanyAndRatingsDTO
        {
            Id = company.Id,
            Name = company.Name,
            Score = double.Round(company.Score, 1),
            Address = company.Address,
            PostalCode = company.PostalCode,
            City = company.City,
            NumberOfRatings = company.Ratings.Count,
            PictureUrl = company.PictureUrl,
            ratingDTOs = ratingsDTO,
        };
    }
}
