namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class CompanyDoesNotExistException : ProblemDetailsException
{
    public CompanyDoesNotExistException(string instance)
    {
        Type = "A URL to a site with an explanation";
        Title = "You tried to get a company that does not exist.";
        Detail = "The id given to the database does not correspond to an existing company.";
        Instance = instance;
    }
}
