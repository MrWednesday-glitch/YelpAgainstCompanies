namespace YelpAgainstCompanies.Data.Repositories;

[ExcludeFromCodeCoverage]
public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    //TODO Integrate this into the interface
    public AppUser GetUser(string username)
    {
        return _dataContext.Set<AppUser>()
            .SingleOrDefault(x => x.UserName == username)
            ?? throw new Exception($"{username} is not a user on this site.");
    }
}
