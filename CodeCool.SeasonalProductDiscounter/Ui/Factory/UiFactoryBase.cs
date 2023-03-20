using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui.Factory;

public abstract class UiFactoryBase
{
    protected readonly IAuthenticationService AuthenticationService;

    protected UiFactoryBase(IAuthenticationService authenticationService)
    {
        AuthenticationService = authenticationService;
    }

    public abstract string UiName { get; }
    public abstract UiBase Create();
}
