using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public abstract class UiBase
{
    
    private readonly string _title;
    public abstract bool RequiresAuthentication { get; }
    protected UiBase(string title)
    {
        _title = title;
        
    }


    public void DisplayTitle()
    {
        Console.WriteLine();
        Console.WriteLine($"--- {_title} ---");
        Console.WriteLine();
    }



    public abstract void Run();
}
