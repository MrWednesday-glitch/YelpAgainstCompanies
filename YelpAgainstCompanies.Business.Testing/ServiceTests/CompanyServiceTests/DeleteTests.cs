namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

[ExcludeFromCodeCoverage]
public class DeleteTests : Base
{
    [Fact]
    public async Task Should_DeleteCompaniesProperly()
    {
        var company = new Company()
        {
            Id = 1,
            Name = "Shell"
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).ReturnsAsync(company);

        var returnedCompany = await _companyService.Delete(1);

        _mockedCompanyRepository.Verify(x => x.DeleteRecord(It.IsAny<Company>()), Times.Once);
        returnedCompany.Should().BeEquivalentTo(company);
    }

    [Fact]
    public async Task Should_ThrowCompanyAlreadyDeletedException_When_TheDeletedTimePropertyIsNotNull()
    {
        var company = new Company
        {
            Id = 1,
            DeletedDate = DateTime.UtcNow,
            Name = "Van der Valk"
        };
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).ReturnsAsync(company);

        Func<Task> deleteAction = async () => await _companyService.Delete(1);

        await deleteAction.Should().ThrowAsync<CompanyAlreadyDeletedException>();
    }
}
