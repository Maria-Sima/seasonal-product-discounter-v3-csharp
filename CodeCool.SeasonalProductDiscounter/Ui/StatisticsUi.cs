using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class StatisticsUi:UiBase
{
    private readonly IProductStatistics _productStatistics;

    public StatisticsUi (IAuthenticationService authenticationService, IProductStatistics productStatistics, string title) : base( title)
    {
        _productStatistics = productStatistics;
    }
    public override bool RequiresAuthentication => true;
    public override void Run()
    {
        Console.WriteLine($"Total products: {_productStatistics.TotalProducts()}");
        Console.WriteLine($"Average price of products: {_productStatistics.GetAveragePrice()}");
        Console.WriteLine($"Cheapest product: [{_productStatistics.GetCheapest()}]");
        Console.WriteLine($"Most expensive product [{_productStatistics.GetMostExpensive()}]");
    }
}
