namespace YelpAgainstCompanies.Business.Extensions;

public static class EmailExtensions
{
    public static bool IsValidEmail(this string email)
    {
        var pattern = @"([\w-\.]+@[\w-]+\.+[\w-]{2,4})";

        return Regex.IsMatch(email, pattern);
    }
}
