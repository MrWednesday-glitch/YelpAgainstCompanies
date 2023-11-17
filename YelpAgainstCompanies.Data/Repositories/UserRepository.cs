namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public AppUser GetUser(string username)
    {
        return _dataContext.Set<AppUser>()
            .SingleOrDefault(x => x.UserName == username)
            //TODO Place this exception in the service so that they can be tested.
            ?? throw new UserDoesNotExistException("/attachratingtocompany/companyId");
    }
}
