namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class CompanyAlreadyDeletedException : ProblemDetailsException
{
    public CompanyAlreadyDeletedException(string instance)
    {
        Type = "A URL to a site with an explanation";
        Title = "You tried to delete a company that was already deleted.";
        Detail = "The id given to the database does not correspond to an existing company.";
        Instance = instance;
    }
}
