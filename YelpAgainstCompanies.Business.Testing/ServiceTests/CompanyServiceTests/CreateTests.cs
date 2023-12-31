﻿namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class CreateTests : Base
{
    [Fact]
    public void Should_OnlyEnterCompanyOnce()
    {
        // -- Arrange
        var companies = new List<Company>();
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(companies.AsQueryable);
        var company = new Company
        {
            Name = "Test company",
            PostalCode = "1234er",
            Address = "Kees Janstraat 4"
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
            PostalCode = "1234er",
            Address = "Kees Janstraat 4"
        };
        var companies = new List<Company>()
        {
            company
        };
        _mockedCompanyRepository.Setup(x => x.GetRecords()).ReturnsAsync(companies.AsQueryable);

        Func<Task> sut = async () => await _companyService.Create(company);

        await sut.Should().ThrowAsync<RecordExistsInDatabaseException>();
    }

    [Fact]
    public async Task Should_ThrowExceptionWhenPostalCodeIsWrong()
    {
        var company = new Company
        {
            Name = "Test company",
            PostalCode = "1234eee",
            Address = "Kees Janstraat 4"
        };

        Func<Task> sut = async () => await _companyService.Create(company);

        await sut.Should().ThrowAsync<StringNotValidException>();
    }

    [Fact]
    public async Task Should_ThrowExceptionWhenAddressIsWrong()
    {
        var company = new Company
        {
            Name = "Test company",
            PostalCode = "1234er",
            Address = "Kees Janstraat"
        };

        Func<Task> sut = async () => await _companyService.Create(company);

        await sut.Should().ThrowAsync<StringNotValidException>();
    }
}
