namespace YelpAgainstCompanies.Api.Helpers;

public class Transformations
{
    public CompanyDTO Transform(Company company) => new()
    {
        Id = company.Id,
        Name = company.Name,
        Score = double.Round(company.Score, 1),
        Address = company.Address,
        PostalCode = company.PostalCode,
        City = company.City,
        NumberOfRatings = company.Ratings.Count,
        PictureUrl = company.PictureUrl == string.Empty
            ? "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled-1150x647.png"
            : company.PictureUrl,
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
        var sortedRatings = ratings
            .OrderByDescending(x => x.Date)
            .ToList();
        var ratingsDTO = new List<RatingDTO>();

        foreach (var rating in sortedRatings)
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
            PictureUrl = company.PictureUrl == string.Empty
                ? "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled-1150x647.png"
                : company.PictureUrl,
            Ratings = ratingsDTO,
        };
    }

    public UserDTO Transform(AppUser user, IEnumerable<RatingDTO> ratings)
    {
        return new UserDTO
        {
            FirstName = user.FirstName,
            LastName = user.LastName ?? "",
            Email = user.UserName ?? "",
            Ratings = ratings.ToList(),
        };
    }
}
