namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class AddToCompanyTests : Base
{
    [Fact]
    public async Task Should_OnlyAddOneComment()
    {
        // -- Arrange
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = 1,
            Score = 3,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>
            {
                new Rating
                {
                    Date = new DateTime(2023, 9, 4),
                    Comment = "I'm an old comment.",
                    CompanyId = 1,
                    Score = 4,
                }
            }
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        // -- Act
        var updatedCompany = await _companyService.AddToCompany(newRating);

        // -- Assert
        updatedCompany.Ratings.ToList().Count.Should().Be(2);
    }

    [Fact]
    public async Task Should_AverageAccurately()
    {
        // -- Arrange
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = 1,
            Score = 3,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>
            {
                new Rating
                {
                    Date = new DateTime(2023, 9, 4),
                    Comment = "I'm an old comment.",
                    CompanyId = 1,
                    Score = 4,
                }
            }
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        // -- Act
        var updatedCompany = await _companyService.AddToCompany(newRating);

        // -- Assert
        updatedCompany.Score.Should().Be(3.5);
    }

    [Fact]
    public async Task Should_AverageAccuratelyWhenFirstComment()
    {
        // -- Arrange
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = 1,
            Score = 3,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>()
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        // -- Act
        var updatedCompany = await _companyService.AddToCompany(newRating);

        // -- Assert
        updatedCompany.Score.Should().Be(3);
    }

    [Fact]
    public async Task Should_OnlyHitTheDatabaseOnce()
    {
        // -- Arrange
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = 1,
            Score = 3,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>
            {
                new Rating
                {
                    Date = new DateTime(2023, 9, 4),
                    Comment = "I'm an old comment.",
                    CompanyId = 1,
                    Score = 4,
                }
            }
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        // -- Act
        var updatedCompany = await _companyService.AddToCompany(newRating);

        // -- Assert
        _mockedCompanyRepository.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    public async Task Should_HitException_When_CompanyIdIsZeroOrLess(int companyId)
    {
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = companyId,
            Score = 3,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>
            {
                new Rating
                {
                    Date = new DateTime(2023, 9, 4),
                    Comment = "I'm an old comment.",
                    CompanyId = 1,
                    Score = 4,
                }
            }
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        Func<Task<Company>> sut = async () => await _companyService.AddToCompany(newRating);

        await sut.Should().ThrowAsync<CompanyDoesNotExistException>();
    }

    [Theory]
    [InlineData(0.5)]
    [InlineData(-2)]
    [InlineData(5.5)]
    [InlineData(7)]
    public async Task Should_HitException_When_ScoreIsLessThanOne_Or_MoreThanFive(int score)
    {
        var newRating = new Rating
        {
            Date = DateTime.Now,
            Comment = "I'm a comment.",
            CompanyId = 1,
            Score = score,
        };
        var company = new Company
        {
            Id = 1,
            Name = "AH",
            Score = 4,
            Ratings = new List<Rating>
            {
                new Rating
                {
                    Date = new DateTime(2023, 9, 4),
                    Comment = "I'm an old comment.",
                    CompanyId = 1,
                    Score = 4,
                }
            }
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(Task.FromResult(company));

        Func<Task<Company>> sut = async () => await _companyService.AddToCompany(newRating);

        await sut.Should().ThrowAsync<AttachWrongScoreToCompanyException>();
    }
}
