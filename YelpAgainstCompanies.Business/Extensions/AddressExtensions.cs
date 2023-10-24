namespace YelpAgainstCompanies.Business.Extensions;

public static class AddressExtensions
{
    //TODO Test this
    public static bool IsValidAddress(this string address)
    {
        var regexPattern = "^.+\\s{1}[0-9]+\\w{0,2}$";

        return Regex.IsMatch(address, regexPattern);
    }

    //TODO Test this
    public static bool IsValidPostalCode(this string postalCode)
    {
        var regexPattern = "^[1-9][0-9]{3} ?(?!sa|sd|ss)[a-z]{2}$";

        return Regex.IsMatch(postalCode, regexPattern);
    }
}
