using System.Text.RegularExpressions;

namespace YelpAgainstCompanies.Business.Extensions;

public static class EmailExtensions
{
    public static bool IsValidEmail(this string email)
    {
        var pattern = @"([\w-\.]+@[\w-]+\.+[\w-]{2,4})";

        return Regex.IsMatch(email, pattern);
    }

    public static List<string> ExtractEmails(this string text)
    {
        var result = new List<string>();
        var pattern = @"([\w-\.]+@[\w-]+\.+[\w-]{2,4})";
        var matches = Regex.Matches(text, pattern);

        foreach (var match in matches)
        {
            result.Add(match.ToString());
        }

        return result;
    }
}
