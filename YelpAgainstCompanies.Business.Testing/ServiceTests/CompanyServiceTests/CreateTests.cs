namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class CreateTests : Base
{
    [Fact]
    public void Should_OnlyEnterCompanyOnce()
    {
        // -- Arrange
        var companies = new List<Company>();
        _mockedCompanyRepository.Setup(x => x.GetRecords()).Returns(companies.AsQueryable);
        var company = new Company
        {
            Name = "Test company",
            PostalCode = "12345",
        };

        // -- Act
        _companyService.Create(company);

        // -- Assert
        _mockedCompanyRepository.Verify(x => x.CreateRecord(It.IsAny<Company>()), Times.Once);
    }

    [Fact]
    public async Task Should_NotCreateCompanyIfItAlreadyExists()
    {
        var company = new Company
        {
            Name = "Test company",
            PostalCode = "12345",
        };
        var companies = new List<Company>() 
        { 
            company 
        };
        _mockedCompanyRepository.Setup(x => x.GetRecords()).Returns(companies.AsQueryable);

        Func<Task> sut = async () => await _companyService.Create(company);

        await sut.Should().ThrowAsync<Exception>().WithMessage("The company you tried to create already exists.");
    }
}
