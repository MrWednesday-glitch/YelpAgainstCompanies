namespace YelpAgainstCompanies.Domain.Exceptions;

public class AttachWrongScoreToCompanyException : ProblemDetailsException
{
    public AttachWrongScoreToCompanyException(string message, string instance)
    {
        Type = "A URL to a site with an explanation";
        Title = message;
        Detail = "The score that the user tried to attach to his rating is not accepted.";
        Instance = instance;
    }
}
