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

IOfferService offerService = null;

IAuthenticationService authenticationService = null;
UiFactoryBase productsUiFactory = new ProductsUiFactory(authenticationService, productBrowser);
UiFactoryBase statisticsUiFactory = null;
UiFactoryBase offersUiFactory = null;

SortedList<int, UiFactoryBase> factories = new SortedList<int, UiFactoryBase>
{
    { 1, productsUiFactory },
    { 2, statisticsUiFactory },
    { 3, offersUiFactory }
};

var uiSelector = new UiSelector(factories);

UiBase ui = uiSelector.Select();

if (ui.Authenticate())
{
    ui.DisplayTitle();
    ui.Run();
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
