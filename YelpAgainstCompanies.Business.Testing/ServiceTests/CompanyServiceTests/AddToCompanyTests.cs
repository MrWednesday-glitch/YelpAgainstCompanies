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
        _mockedCompanyRepository.Setup(x => x.GetRecord(1)).Returns(company);

        // -- Act
        var updatedCompany = await _companyService.AddToCompany(newRating);

        // -- Assert
        updatedCompany.Ratings.ToList().Count.Should().Be(2);
    }
}
