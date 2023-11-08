namespace YelpAgainstCompanies.Business.Testing.ServiceTests.UserServiceTests;

[ExcludeFromCodeCoverage]
public class GetUserTests : Base
{
    [Fact]
    public void Should_GetUser()
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
        _mockedUserRepository.Setup(x => x.GetUser(userName)).Returns(user);

        // -- Act
        var returnedUser = _userService.GetUser(userName);

        // -- Assert
        returnedUser.FirstName.Should().BeEquivalentTo("Henk");
        returnedUser.LastName.Should().BeEquivalentTo("Krol");
    }
}
