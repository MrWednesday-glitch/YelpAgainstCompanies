namespace YelpAgainstCompanies.Business.Testing.ExtensionTests.AddressExtensionTests;

[ExcludeFromCodeCoverage]
public class IsValidPostalCodeTests
{
    [Theory]
    [InlineData("1234er", true)]
    [InlineData("1234 er", true)]
    [InlineData("ahsy3e", false)]
    [InlineData("asdf123", false)]
    public void Should_CheckPostalCodesCorrectly(string postalCode, bool expected)
    {
        // -- Arrange

        // -- Act
        var sut = postalCode.IsValidPostalCode();

        // -- Assert
        sut.Should().Be(expected);
    }
}
