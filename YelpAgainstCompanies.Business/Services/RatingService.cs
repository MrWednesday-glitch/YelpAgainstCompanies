namespace YelpAgainstCompanies.Business.Services;

//TODO Have adding a singular rating to a company update (CRUD) the average total rating of the company
//If the total rating is null or zero have it become the first singular rating
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
            throw new ArgumentOutOfRangeException(nameof(companyId));
        }

        var ratings = _ratingRepository.GetRecords()
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.Date);

        //TODO Maybe if ratings.count == 0 throw exception?
        return ratings;
    }
}
