using CodeCool.SeasonalProductDiscounter.Service.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui.Factory;

public class OfferUiFactory:UiFactoryBase
{
    private readonly IOfferService _offerService;

    public OfferUiFactory(IOfferService offerService) : base()
    {
        _offerService = offerService;
    }

    public override string UiName => "Offers";
    public override bool RequiresAuthentication => false;
    public override UiBase Create()
    {
        return new OffersUi(AuthenticationService, UiName, _offerService);
    }
}