using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui.Factory;

public class StatisticUiFactory:UiFactoryBase
{
    private readonly IProductStatistics _productStatistics;

    public StatisticUiFactory(IProductStatistics productStatistics) : base()
    {
        _productStatistics = productStatistics;
    }
    public override bool RequiresAuthentication => true;
    public override string UiName => "Statistics";
    public override UiBase Create()
    {
        return new StatisticsUi(AuthenticationService,_productStatistics,UiName);
    }
}