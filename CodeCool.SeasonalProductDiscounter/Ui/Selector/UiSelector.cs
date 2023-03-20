using CodeCool.SeasonalProductDiscounter.Ui.Factory;

namespace CodeCool.SeasonalProductDiscounter.Ui.Selector;

public class UiSelector
{
    private readonly SortedList<int, UiFactoryBase> _factories;

    public UiSelector(SortedList<int, UiFactoryBase> factories)
    {
        _factories = factories;
    }

    public UiBase Select()
    {
        Console.WriteLine("Welcome to Seasonal Product Discounter v3");

        DisplayMenu();

        //...
        return null;
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Available screens:");
        //...
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
