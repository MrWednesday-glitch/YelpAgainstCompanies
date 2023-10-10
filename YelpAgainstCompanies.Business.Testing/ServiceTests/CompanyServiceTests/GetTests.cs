namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests : Base
{
    private readonly List<Company> _mockedCompanies = new()
    {
        new Company()
        {
            Id = 1,
            Name = "Charles",
            Score = 4.44,
        },
        new Company()
        {
            Id = 2,
            Name = "Dave",
            Score = 2.22,
        },
        new Company()
        {
            Id = 3,
            Name = "Alex",
            Score = 1.11,
        },
    };

    [Fact]
    public async Task Should_ReturnCorrectAmountOfCompanies()
    {
        // -- Arrange
        _mockedCompanyRepository.Setup(x => x.GetRecords()).Returns(_mockedCompanies.AsQueryable);

        // -- Act
        var companies = await _companyService.Get();

        // -- Assert
        companies.ToList().Count.Should().Be(3);
    }

    [Fact]
    public async Task Should_BeSorted()
    {
        // -- Arrange
        _mockedCompanyRepository.Setup(x => x.GetRecords()).Returns(_mockedCompanies.AsQueryable);

        // -- Act
        var companies = await _companyService.Get();

        // -- Assert
        companies.ToList().Should().BeInAscendingOrder(x => x.Name);
    }

    [Fact]
    public async Task Should_FindCorrectCompany()
    {
        var mockedCompany = new Company()
        {
            Id = 1,
            Name = "Dead Cells"
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(It.IsAny<int>())).Returns(mockedCompany);

        var company = await _companyService.Get(1);

        company.Name.Should().BeEquivalentTo("Dead Cells");
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
