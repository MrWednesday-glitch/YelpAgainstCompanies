namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class StringNotValidException : ProblemDetailsException
{
    public StringNotValidException(string textType, string instance)
    {
        Type = "An URL to a site with an explanation";
        Title = $"The {textType} you tried to enter is not valid.";
        Detail = $"The {textType} is not valid with the rules that we require the {textType} to have.";
        Instance = instance;
    }
}
