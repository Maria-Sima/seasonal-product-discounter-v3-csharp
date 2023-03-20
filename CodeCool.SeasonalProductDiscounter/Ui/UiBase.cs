using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public abstract class UiBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly string _title;

    protected UiBase(IAuthenticationService authenticationService, string title)
    {
        _title = title;
        _authenticationService = authenticationService;
    }

    private static string GetTextInput(string text)
    {
        string input = string.Empty;

        while (input == string.Empty)
        {
            Console.Write(text);
            input = Console.ReadLine() ?? string.Empty;
        }

        return input;
    }

    private User GetUser()
    {
        //...
        return null;
    }


    public void DisplayTitle()
    {
        //...
    }

    public bool Authenticate()
    {
        var user = GetUser();
        //...

        return false;
    }

    public abstract void Run();
}
