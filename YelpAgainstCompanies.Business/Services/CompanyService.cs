namespace YelpAgainstCompanies.Business.Services;

public class CompanyService : ICompanyService
{
    private readonly DataStore _dataStore;

    public CompanyService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    //TODO Write tests
    public async Task<IEnumerable<Company>> Get() => await _dataStore.GetCompanies();

    //TODO Write tests
    public async Task<Company> Get(int id) => (await _dataStore.GetCompanies()).SingleOrDefault(x => x.Id == id)
        ?? throw new ArgumentNullException("No company was found with this id.");
}
