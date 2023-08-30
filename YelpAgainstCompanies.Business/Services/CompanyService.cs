namespace YelpAgainstCompanies.Business.Services;

//TODO Make things async
public class CompanyService : ICompanyService
{
    private readonly DataStore _dataStore;

    public CompanyService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public List<Company> Get() => _dataStore.GetCompanies();

    public Company Get(int id) => _dataStore.GetCompanies().SingleOrDefault(x => x.Id == id);
}
