namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class PaginationMetadata
{
    public int TotalItemCount { get; set; }

    public int TotalPageCount { get; set; }

    public int PageSize { get; set; }

    public int CurrentPage { get; set; }

    public List<string> Cities { get; set; }

    public PaginationMetadata(int totalItemCount, int pageSize, int currentPage, List<string> cities)
    {
        TotalItemCount = totalItemCount;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)PageSize);
        Cities = cities;
    }
}