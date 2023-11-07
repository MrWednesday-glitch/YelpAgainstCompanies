namespace YelpAgainstCompanies.Business.Testing.ServiceTests.UserServiceTests;

[ExcludeFromCodeCoverage]
public class Base
{
    public readonly IUserService _userService;
    public readonly Mock<IUserRepository> _mockedUserRepository;

    public Base()
    {
        _mockedUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockedUserRepository.Object);
    }
}
