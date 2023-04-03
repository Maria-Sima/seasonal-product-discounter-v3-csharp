using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounter.Service.Offers;

public class OfferService : IOfferService
{
    private readonly IDiscountProvider _discountProvider;
    private readonly IProductProvider _productProvider;

    public OfferService(IDiscountProvider discountProvider, IProductProvider productProvider)
    {
        _discountProvider = discountProvider;
        _productProvider = productProvider;
    }

    public IEnumerable<Offer> GetOffers(DateTime date)
    {
        List<Offer> offers = new List<Offer>();

        var products = new ProductBrowser(_productProvider).GetAll();
        foreach (var product in products)
        {
            Offer offer = new DiscounterService(_discountProvider).GetOffer(product, date);
            offers.Add(offer);
        }

        return offers;
    }
}
