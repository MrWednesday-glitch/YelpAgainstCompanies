namespace YelpAgainstCompanies.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AppUser> GetUser(string username)
    {
        var user = await _userRepository.GetUser(username);

        return user;
    }
}
