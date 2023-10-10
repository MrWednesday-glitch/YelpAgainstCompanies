namespace YelpAgainstCompanies.Business.Testing.ExtensionTests.PasswordExtensionTests;

[ExcludeFromCodeCoverage]
public class IsValidPasswordTests
{
    [Theory]
    [InlineData(true, "ANGelo55!!")]
    [InlineData(true, "BatMan(4)")]
    [InlineData(false, "abrakadabra4!")]
    [InlineData(false, "aBRAkadabra4")]
    [InlineData(false, "aBRAkadabra!!")]
    public void Should_CheckPasswordsCorrectly(bool expected, string password)
    {
        // -- Arrange

        // -- Act
        var sut = password.IsValidPassword();

        // -- Assert
        sut.Should().Be(expected);
    }
}
