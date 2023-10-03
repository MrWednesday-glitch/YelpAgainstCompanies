namespace YelpAgainstCompanies.Business.Testing.ServiceTests.CompanyServiceTests;

//TODO Fix this
[ExcludeFromCodeCoverage]
public class Base
{
    public readonly ICompanyService _companyService;
    public readonly DataStore _dataStore;
    //public readonly Mock<DataStore> _mockedDataStore;

    public Base()
    {
        _dataStore = new DataStore();
        //_companyService = new CompanyService(_dataStore);
        //_mockedDataStore = new Mock<DataStore>();
        //_companyService = new CompanyService(_mockedDataStore.Object);
    }
}
