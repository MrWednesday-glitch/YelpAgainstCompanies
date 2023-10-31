namespace YelpAgainstCompanies.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //TODO TEst this
    public AppUser GetUser(string username)
    {
        return _userRepository.GetUser(username);
    }
}
