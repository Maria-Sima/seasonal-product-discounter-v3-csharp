using CodeCool.SeasonalProductDiscounter.Service.Users;
using CodeCool.SeasonalProductDiscounter.Ui.Authentication;
using CodeCool.SeasonalProductDiscounter.Ui.Factory;

namespace CodeCool.SeasonalProductDiscounter.Ui.Selector;

public class UiSelector
{
    private readonly SortedList<int, UiFactoryBase> _factories;
    private readonly IAuthenticationService _authenticationService;

    public UiSelector(SortedList<int, UiFactoryBase> factories,IAuthenticationService authenticationService)
    {
        _factories = factories;
        _authenticationService = authenticationService;
    }

    public UiBase Select()
    {
        Console.WriteLine("Welcome to Seasonal Product Discounter v3");

        DisplayMenu();

        int choice = GetIntInput();
        UiFactoryBase factory;
        if (!_factories.TryGetValue(choice, out factory))
        {
            Console.WriteLine("Invalid selection.");
            return null;
        }
        UiBase ui = factory.Create();
        if (ui.RequiresAuthentication)
        {
            
            var userAuthenticator = new UserAuthenticator(_authenticationService);
            if (!userAuthenticator.Authenticate())
            {
                Console.WriteLine("Authentication failed.");
                return null;
            }
        }
        return ui;
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Available screens:");
        foreach (KeyValuePair<int, UiFactoryBase> factory in _factories)
        {
            Console.WriteLine($"{factory.Key}. {factory.Value.UiName}");
        }
    }

    private static int GetIntInput()
    {
        int input = 0;

        while (input == 0)
        {
            var i = Console.ReadLine();
            if (!int.TryParse(i, out input))
            {
                Console.Write("Please provide a valid number!");
            }
        }

        return input;
    }
}
