namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class RecordExistsInDatabaseException : ProblemDetailsException
{
    public RecordExistsInDatabaseException(string entityType, string instance)
    {
        Type = "An URL to a site with an explanation";
        Title = $"The {entityType} already exists in the database.";
        Detail = $"The {entityType} that you tried to enter in the database was already found in the database.";
        Instance = instance;
    }
}
