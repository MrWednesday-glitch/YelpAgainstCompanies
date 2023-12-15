namespace YelpAgainstCompanies.Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class ProblemDetailsException : Exception
{
    public string Type { get; set; }

    public string Detail { get; set; }

    public string Title { get; set; }

    public string Instance { get; set; }
}
