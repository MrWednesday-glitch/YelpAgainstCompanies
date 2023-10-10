namespace YelpAgainstCompanies.Business.Testing.ServiceTests.RatingServiceTests;

[ExcludeFromCodeCoverage]
public class Base
{
    public readonly IRatingService _ratingService;
    public readonly Mock<IRatingRepository> _mockedRatingRepository;

    public Base()
    {
        _mockedRatingRepository = new Mock<IRatingRepository>();
        _ratingService = new RatingService(_mockedRatingRepository.Object);
    }
}
