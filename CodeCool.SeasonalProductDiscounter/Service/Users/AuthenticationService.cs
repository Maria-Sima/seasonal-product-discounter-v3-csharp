using CodeCool.SeasonalProductDiscounter.Model.Users;

namespace CodeCool.SeasonalProductDiscounter.Service.Users;

public class AuthenticationService:IAuthenticationService
{
    private readonly List<User> _users = new()
    {
        new User("user1", "password1"),
        new User("user2", "password2")
    };

    public bool Authenticate(User user)
    {
        return _users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
    }
}

