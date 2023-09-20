namespace YelpAgainstCompanies.Business.Services;

//TODO Make things async
public class CompanyService : ICompanyService
{
    private readonly DataStore _dataStore;

    public CompanyService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    //TODO Write tests
    public List<Company> Get() => _dataStore.GetCompanies();

    //TODO Write tests
    public Company Get(int id) => _dataStore.GetCompanies().SingleOrDefault(x => x.Id == id);
}
