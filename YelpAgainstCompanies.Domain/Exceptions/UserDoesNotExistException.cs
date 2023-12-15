namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class UserDoesNotExistException : ProblemDetailsException
{
    public UserDoesNotExistException(string instance)
    {
        Type = "An URL to a site with an explanation";
        Title = "This user does not exist.";
        Detail = "No user exists with the given email/username.";
        Instance = instance;
    }
}
