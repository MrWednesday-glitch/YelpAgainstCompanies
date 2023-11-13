namespace YelpAgainstCompanies.Domain.Exceptions;

public class UserDoesNotExistException : ProblemDetailsException
{
    public UserDoesNotExistException(string instance)
    {
        Type = "An URL to a site with an explanation";
        Title = "You tried to log in as a user that does not exist.";
        Detail = "No user exists with the given email/username.";
        Instance = instance;
    }
}
