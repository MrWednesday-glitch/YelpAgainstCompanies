namespace YelpAgainstCompanies.Business.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<IEnumerable<Rating>> Get(int companyId)
    {
        if (companyId <= 0)
        {
            throw new CompanyDoesNotExistException($"/rating/{companyId}");
        }

        var ratings = (await _ratingRepository.GetRecords())
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.Date);

        if (!ratings.Any())
        {
            return new List<Rating>();
        }

        return ratings;
    }
}
