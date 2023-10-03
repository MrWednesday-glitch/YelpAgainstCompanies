using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpAgainstCompanies.Business.Extensions;

public static class PasswordExtensions
{
    public static bool IsValidPassword(this string password)
    {
        var pattern = @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";

        return Regex.IsMatch(password, pattern);
    }
}
