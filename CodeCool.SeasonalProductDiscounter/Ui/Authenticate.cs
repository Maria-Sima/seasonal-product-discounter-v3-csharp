using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui.Authentication
{
    public class UserAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public UserAuthenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public bool Authenticate()
        {
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            bool isAuthenticated = _authenticationService.Authenticate(new User(username,password));

            if (!isAuthenticated)
            {
                Console.WriteLine("Invalid username or password!");
            }

            return isAuthenticated;
        }
    }
}