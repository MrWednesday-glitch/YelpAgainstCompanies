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
//Todo run codemaid
             City = "Den Haag",
        },
        new Company()
        {
            Id = 2,
            Name = "Dave",
            Score = 2.22,
             City = "Den Haag",
        },
        new Company()
        {
            Id = 3,
            Name = "Alex",
            Score = 1.11,
            City = "Zoetermeer",
        },
    };

    [Fact]
    public async Task Should_ReturnCorrectAmountOfCompanies()
    {
        // -- Arrange
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        // -- Act
        var companies = await _companyService.Get();

        // -- Assert
        companies.ToList().Count.Should().Be(3);
    }

    [Fact]
    public async Task Should_BeSorted()
    {
        // -- Arrange
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

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
        _mockedCompanyRepository.Setup(x => x.GetRecord(It.IsAny<int>())).ReturnsAsync(mockedCompany);

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

        await sut.Should().ThrowAsync<CompanyDoesNotExistException>();
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    public async Task Should_ReturnALimitedCollection(int pageSize, int expectedCollectionSize)
    {
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        var (companies, paginationMetadata) = await _companyService.Get(1, pageSize);

        companies.ToList().Should().HaveCount(expectedCollectionSize);
    }


    [Fact]
    public async Task Should_ReturnTheCorrectSortedCollection()
    {
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        var (companies, paginationMetadata) = await _companyService.Get(1, 2);

        companies.ToList()[0].Name.Should().BeEquivalentTo("Alex");
        companies.ToList()[1].Name.Should().BeEquivalentTo("Charles");
    }

    [Fact]
    public async Task Should_HaveCorrectPaginationMetadata()
    {
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        var (companies, paginationMetadata) = await _companyService.Get(1, 2);

        paginationMetadata.PageSize.Should().Be(2);
        paginationMetadata.CurrentPage.Should().Be(1);
        paginationMetadata.TotalItemCount.Should().Be(3);
        paginationMetadata.TotalPageCount.Should().Be(2);
    }

    [Fact]
    public async Task Should_ChangeTheSearchTermToLower()
    {
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        var (companies, paginationMetadata) = await _companyService.Get(1, 10, "ChaRlES");

        companies.ToList().Count.Should().Be(1);
    }

    [Theory]
    [InlineData("lex", 1)]
    [InlineData("den haag", 2)]
    [InlineData("da", 1)]
    public async Task Should_FindCorrectAmountOfCompanies(string searchTerm, int collectionSize)
    {
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(_mockedCompanies.AsQueryable);

        var (companies, paginationMetadata) = await _companyService.Get(1, 10, searchTerm);

        companies.ToList().Count.Should().Be(collectionSize);
    }
}
