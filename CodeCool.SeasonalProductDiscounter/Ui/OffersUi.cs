using CodeCool.SeasonalProductDiscounter.Service.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class OffersUi:UiBase
{
    private readonly IOfferService _offerService;
    public OffersUi(IAuthenticationService authenticationService, string title,IOfferService offerService) : base(title)
    {
        _offerService = offerService;
    }
    public override bool RequiresAuthentication => false;

    public override void Run()
    {
        _offerService.GetOffers(DateTime.Today);
    }
}