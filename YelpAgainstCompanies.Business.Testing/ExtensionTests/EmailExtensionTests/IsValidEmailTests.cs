namespace YelpAgainstCompanies.Business.Testing.ExtensionTests.EmailExtensionTests;

[ExcludeFromCodeCoverage]
public class IsValidEmailTests
{
    [Theory]
    [InlineData(true, "rowan@email.com")]
    [InlineData(true, "rowan@email.nl")]
    [InlineData(false, "rowan.email.com")]
    [InlineData(false, "rowan@emailcom")]
    public void Should_CheckEmailsCorrectly(bool expected, string email)
    {
        // -- Arrange

        // -- Act
        var sut = email.IsValidEmail();

        // -- Assert
        sut.Should().Be(expected);
    }
}
