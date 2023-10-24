namespace YelpAgainstCompanies.Business.Testing.ExtensionTests.AddressExtensionTests;

[ExcludeFromCodeCoverage]
public class IsValidAddressTests
{
    [Theory]
    [InlineData("Lijnbaan 4", true)]
    [InlineData("Korte Janstraat 55", true)]
    [InlineData("Abbalaan 4a", true)]
    [InlineData("Geenstraatnummer", false)]
    public void Should_CheckAddressesCorrectly(string address, bool expected)
    {
        // -- Arrange

        // -- Act
        var sut = address.IsValidAddress();

        // -- Assert
        sut.Should().Be(expected);
    }
}
