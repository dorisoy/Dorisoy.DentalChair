
namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 账户管理视图模型
/// </summary>
public partial class AccountViewModel : BaseViewModel
{
    private readonly IAuthenticationService _authenticationService;
    private readonly INavigationService  _navigationService;

    [ObservableProperty]
    UserInfo _userInfo = null;

    public AccountViewModel(SettingsService settingsService,
        DatabaseService databaseService, 
        IAuthenticationService authenticationService, 
        INavigationService navigationService) : base(settingsService, databaseService)
    {
        _authenticationService = authenticationService;
        _navigationService = navigationService;

        LoadData();

        DarkModeSwitchToggled = AppSettings.IsDarkMode;
    }

    private bool darkModeSwitchToggled;
    public bool DarkModeSwitchToggled
    {
        get => darkModeSwitchToggled;
        set
        {
            SetProperty(ref darkModeSwitchToggled, value);
            SetTheme(value);
        }
    }

    private void LoadData()
    {
        UserInfo = MockServices.Instance.GetUserInfo;
    }

    [RelayCommand]
    private void Logout()
    {
       // var page = App.Services?.GetService<LoginPage>();
        _navigationService.NavigationPage(nameof(LoginPage));
    }

    public void SetTheme(bool isDarkMode)
    {
        if (isDarkMode)
        {
            Application.Current?.Resources.ApplyDarkTheme();
            AppSettings.IsDarkMode = true;
            
        }
        else
        {
            Application.Current?.Resources.ApplyLightTheme();
            AppSettings.IsDarkMode = false;
        }
        ThemeUtil.ApplyColorSet(AppSettings.SelectedPrimaryColorIndex);
    }
}
