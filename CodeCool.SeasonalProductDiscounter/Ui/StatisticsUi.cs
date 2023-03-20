using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class StatisticsUi
{
    private readonly IProductStatistics _productStatistics;

    public StatisticsUi(IProductStatistics productStatistics)
    {
        _productStatistics = productStatistics;
    }

    public void Run()
    {
        Console.WriteLine($"Total products: {_productStatistics.TotalProducts()}");
        Console.WriteLine($"Average price of products: {_productStatistics.GetAveragePrice()}");
        Console.WriteLine($"Cheapest product: [{_productStatistics.GetCheapest()}]");
        Console.WriteLine($"Most expensive product [{_productStatistics.GetMostExpensive()}]");
    }
}
