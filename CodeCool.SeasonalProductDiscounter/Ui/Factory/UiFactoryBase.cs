using CodeCool.SeasonalProductDiscounter.Service.Users;

namespace CodeCool.SeasonalProductDiscounter.Ui.Factory;

public abstract class UiFactoryBase
{
    protected readonly IAuthenticationService AuthenticationService;

  
    public abstract bool RequiresAuthentication { get; }
    public abstract string UiName { get; }
    public abstract UiBase Create();
}
