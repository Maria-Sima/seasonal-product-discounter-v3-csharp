using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Service.Users;
using CodeCool.SeasonalProductDiscounter.Ui;
using CodeCool.SeasonalProductDiscounter.Ui.Factory;
using CodeCool.SeasonalProductDiscounter.Ui.Selector;

var productProvider = new RandomProductGenerator(100, 10, 50);
var productBrowser = new ProductBrowser(productProvider);
var productStatistics = new ProductStatistics(productBrowser);
var discountProvider = new DiscountProvider();
var discounterService = new DiscounterService(discountProvider);

IOfferService offerService = new OfferService(discountProvider,productProvider);

IAuthenticationService authenticationService = new AuthenticationService();
UiFactoryBase productsUiFactory = new ProductsUiFactory( productBrowser);
UiFactoryBase statisticsUiFactory =new StatisticUiFactory(productStatistics);
UiFactoryBase offersUiFactory = new OfferUiFactory(offerService);

SortedList<int, UiFactoryBase> factories = new SortedList<int, UiFactoryBase>
{
    { 1, productsUiFactory },
    { 2, statisticsUiFactory },
    { 3, offersUiFactory }
};

var uiSelector = new UiSelector(factories,authenticationService);

UiBase ui = uiSelector.Select();


if (ui != null)
{
    ui.DisplayTitle();
    ui.Run();
}


Console.WriteLine("Press any key to exit.");
Console.ReadKey();
