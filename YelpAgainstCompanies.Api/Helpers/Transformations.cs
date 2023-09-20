namespace YelpAgainstCompanies.Api.Helpers;

public class Transformations
{
    public CompanyDTO Transform(Company company)
    {
        var companyDTO = new CompanyDTO()
        {
            Name = company.Name,
            Score = company.Score,
        };

        var ratings = new List<RatingDTO>();
        foreach (var rating in company.Ratings)
        {
            ratings.Add(Transform(rating));
        }

        companyDTO.Ratings = ratings;

        return companyDTO;
    }

    private RatingDTO Transform(Rating rating) => new()
    {
        Date = rating.Date.ToLongDateString(),
        Comment = rating.Comment,
        Score = rating.Score,
        UserName = $"{rating.User.FirstName} {rating.User.LastName}"
    };
}
