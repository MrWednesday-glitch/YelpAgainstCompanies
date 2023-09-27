namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly DataStore _dataStore;

    public CompanyService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    //TODO Add a method to calculate the average of the ratings based on what is in the ratings and apply it to the get methods
    public async Task<IEnumerable<Company>> Get() => await _dataStore.GetCompanies();

    public async Task<Company> Get(int id) => (await _dataStore.GetCompanies()).SingleOrDefault(x => x.Id == id)
        ?? throw new ArgumentNullException("No company was found with this id.");
}
