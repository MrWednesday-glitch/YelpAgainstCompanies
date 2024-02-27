namespace YelpAgainstCompanies.Business.Testing.ServiceTests.UserServiceTests;

[ExcludeFromCodeCoverage]
public class GetUserTests : Base
{
    [Fact]
    public async Task Should_GetUser()
    {
        // -- Arrange
        var userName = "henkkrol@email.nl";
        var user = new AppUser
        {
            Email = "henkkrol@email.nl",
            FirstName = "Henk",
            LastName = "Krol",
            UserName = "henkkrol@email.nl",
        };
        _mockedUserRepository.Setup(x => x.GetUser(userName)).ReturnsAsync(user);

        // -- Act
        var returnedUser = await _userService.GetUser(userName);

        // -- Assert
        returnedUser.FirstName.Should().BeEquivalentTo("Henk");
        returnedUser.LastName.Should().BeEquivalentTo("Krol");
    }
}
