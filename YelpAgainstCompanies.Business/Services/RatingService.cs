namespace YelpAgainstCompanies.Business.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly ICompanyService _companyService;

    public RatingService(IRatingRepository ratingRepository, ICompanyService companyService)
    {
        _ratingRepository = ratingRepository;
        _companyService = companyService;
    }

    //TODO Test this
    public async Task AddToCompany(Rating rating)
    {
        await _companyService.AddToCompany(rating);
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

        if (!ratings.Any())
        {
            return new List<Rating>();
        }

        return ratings;
    }
}
