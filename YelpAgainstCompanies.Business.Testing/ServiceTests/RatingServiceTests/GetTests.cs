using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpAgainstCompanies.Domain.Exceptions;

namespace YelpAgainstCompanies.Business.Testing.ServiceTests.RatingServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests : Base
{
    [Fact]
    public async Task Should_ReturnCorrectAmountOfRatings()
    {
        // -- Arrange
        var mockedRatings = new List<Rating>()
        {
            new Rating()
            {
                Id = 1,
                Score = 3,
                CompanyId = 1,
                Date = new DateTime(2022, 4, 1),
            },
            new Rating()
            {
                Id = 2,
                Score = 4,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 1
            },
            new Rating()
            {
                Id = 2,
                Score = 1,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 2
            },
        };
        _mockedRatingRepository.Setup(x => x.GetRecords()).ReturnsAsync(mockedRatings.AsQueryable);

        // -- Act
        var ratings = await _ratingService.Get(1);

        // -- Assert
        ratings.ToList().Count.Should().Be(2);
    }

    [Fact]
    public async Task Should_BeSortedOnDate()
    {
        var mockedRatings = new List<Rating>()
        {
            new Rating()
            {
                Id = 1,
                Score = 3,
                CompanyId = 1,
                Date = new DateTime(2022, 5, 1),
                Comment = "middle",
            },
            new Rating()
            {
                Id = 2,
                Score = 4,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 1,
                Comment = "first",
            },
            new Rating()
            {
                Id = 2,
                Score = 1,
                Date = new DateTime(2022, 8, 1),
                CompanyId = 1,
                Comment = "last",
            },
        };
        _mockedRatingRepository.Setup(x => x.GetRecords()).ReturnsAsync(mockedRatings.AsQueryable);

        var ratings = await _ratingService.Get(1);

        ratings.ToList().Should().BeInDescendingOrder(x => x.Date);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-2)]
    public async Task Should_ThrowExceptionWhenGivenIdOfZeroOrLess(int id)
    {
        Func<Task> sut = async () =>
        {
            await _ratingService.Get(id);
        };

        await sut.Should().ThrowAsync<CompanyDoesNotExistException>();
    }

    [Fact]
    public async Task Should_ReturnEmptyCollectionIfNoDataInDatabase()
    {
        var mockedRatings = new List<Rating>()
        {
            new Rating()
            {
                Id = 1,
                Score = 3,
                CompanyId = 1,
                Date = new DateTime(2022, 5, 1),
                Comment = "middle",
            },
            new Rating()
            {
                Id = 2,
                Score = 4,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 1,
                Comment = "first",
            },
            new Rating()
            {
                Id = 2,
                Score = 1,
                Date = new DateTime(2022, 8, 1),
                CompanyId = 1,
                Comment = "last",
            },
        };
        _mockedRatingRepository.Setup(x => x.GetRecords()).ReturnsAsync(mockedRatings.AsQueryable);

        var ratings = await _ratingService.Get(999);

        ratings.Should().BeEmpty();
    }

    [Fact]
    public async Task Should_ReturnRatingsBelongingToCorrectUser()
    {
        var userHenk = new AppUser
        {
            FirstName = "Henk",
            UserName = "henk@email.com"
        };
        var userBen = new AppUser
        {
            FirstName = "Ben",
            UserName = "ben@email.com"
        };

        var mockedRatings = new List<Rating>()
        {
            new()
            {
                Id = 1,
                Score = 3,
                CompanyId = 1,
                Date = new DateTime(2022, 5, 1),
                Comment = "middle",
                User = userHenk,
            },
            new()
            {
                Id = 2,
                Score = 4,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 1,
                Comment = "first",
                User = userBen,
            },
            new()
            {
                Id = 2,
                Score = 1,
                Date = new DateTime(2022, 8, 1),
                CompanyId = 1,
                Comment = "last",
                User = userHenk,
            },
        };
        _mockedRatingRepository.Setup(x => x.GetRecords()).ReturnsAsync(mockedRatings.AsQueryable);

        var ratings = await _ratingService.Get(userHenk);

        ratings.ToList().Count.Should().Be(2);
    }

    [Fact]
    public async Task Should_ReturnRatingsBelongingToCorrectUserAndProperlySorted()
    {
        var userHenk = new AppUser
        {
            FirstName = "Henk",
            UserName = "henk@email.com"
        };
        var userBen = new AppUser
        {
            FirstName = "Ben",
            UserName = "ben@email.com"
        };

        var mockedRatings = new List<Rating>()
        {
            new()
            {
                Id = 1,
                Score = 3,
                CompanyId = 1,
                Date = new DateTime(2022, 5, 1),
                Comment = "middle",
                User = userHenk,
            },
            new()
            {
                Id = 2,
                Score = 4,
                Date = new DateTime(2022, 4, 1),
                CompanyId = 1,
                Comment = "first",
                User = userBen,
            },
            new()
            {
                Id = 2,
                Score = 1,
                Date = new DateTime(2022, 8, 1),
                CompanyId = 1,
                Comment = "last",
                User = userHenk,
            },
        };
        _mockedRatingRepository.Setup(x => x.GetRecords()).ReturnsAsync(mockedRatings.AsQueryable);

        var ratings = await _ratingService.Get(userHenk);

        ratings.ToList().Count.Should().Be(2);
        ratings.ToList().Should().BeInDescendingOrder(x => x.Date);
    }
}
