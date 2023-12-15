namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class NotLoggedInException : ProblemDetailsException
{
    public NotLoggedInException(string instance)
    {
        Type = "A URL to a site with an explanation";
        Title = "User is not logged in.";
        Detail = "The user is not authorized to perform this action.";
        Instance = instance;
    }
}
