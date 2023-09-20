namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests : Base
{
    //private readonly List<Company> _mockedCompanies = new()
    //{
    //    new Company()
    //    {
    //        Id = 1,
    //        Name = "Charles",
    //        Score = 4.44,
    //        Ratings = new List<Rating>
    //        {
    //            new Rating() { Id = 1, }
    //        }
    //    },
    //    new Company()
    //    {
    //        Id = 2,
    //        Name = "Dave",
    //        Score = 2.22,
    //        Ratings = new List<Rating>
    //        {
    //            new Rating() { Id = 2, }
    //        }
    //    },
    //    new Company()
    //    {
    //        Id = 3,
    //        Name = "Alex",
    //        Score = 1.11,
    //        Ratings = new List<Rating>
    //        {
    //            new Rating() { Id = 3, }
    //        }
    //    },
    //};

    [Fact]
    public async Task Should_ReturnCorrectAmountOfCompanies()
    {
        // -- Arrange
        //_mockedDataStore.Setup(x => x.GetCompanies()).ReturnsAsync(_mockedCompanies);

        // -- Act
        var companies = await _companyService.Get();

        // -- Assert
        companies.ToList().Count.Should().Be(3);
    }

    [Fact]
    public async Task Should_BeSorted()
    {

    }

    [Theory]
    [InlineData(1, "Kees Balvert")]
    [InlineData(2, "Albert Heijn")]
    [InlineData(3, "Burger King")]
    public async Task Should_FindCorrectCompany(int id, string name)
    {
        var company = await _companyService.Get(id);

        company.Name.Should().BeEquivalentTo(name);
    }

    [Theory]
    [InlineData(-4)]
    [InlineData(0)]
    [InlineData(444)]
    public async Task Should_ThrowArgumentNullExceptionWhenGivenFaultyId(int id)
    {
        Func<Task> sut = async () => await _companyService.Get(id);

        await sut.Should().ThrowAsync<ArgumentNullException>();
    }
}
