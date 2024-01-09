namespace YelpAgainstCompanies.Domain.Interfaces;

public interface ICompanyService
{
    /// <summary>
    /// Deals with a singular company that is retrieved from the database.
    /// </summary>
    /// <param name="id">The id of the company that is needed to be retrieved.</param>
    /// <returns>A company entity.</returns>
    Task<Company> Get(int id);

    /// <summary>
    /// Deals with getting all the companies from the database.
    /// </summary>
    /// <returns>A collection of company entities from the database.</returns>
    Task<IEnumerable<Company>> Get();

    /// <summary>
    /// This method retrieves a set of companies from the repository. It applies pagination, and potentially a searchTerm.
    /// </summary>
    /// <param name="cityName"></param>
    /// <param name="pageNumber">The page that selects which set of company entities needs to be retrieved.</param>
    /// <param name="pageSize">The amount of company entities that will be contained in the collection.</param>
    /// <param name="searchTerm">A user given searchterm which will be used to search through the database.</param>
    /// <returns>A task that contains a selection of company entities.</returns>
    Task<(IEnumerable<Company>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "", string? cityName = "");

    /// <summary>
    /// A method to give the company data to be added into a database.
    /// </summary>
    /// <param name="company">The company to be added.</param>
    /// <returns></returns>
    Task Create(Company company);

    /// <summary>
    /// This method will add a rating to a company.
    /// </summary>
    /// <param name="rating">The given rating to be added to the company.</param>
    /// <returns></returns>
    Task<Company> AddToCompany(Rating rating);
}
