using Newtonsoft.Json;

namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 登录验证视图模型
/// </summary>
public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    private string _userName;

    [ObservableProperty]
    private string _password;

    public LoginViewModel(SettingsService settingsService,
        DatabaseService databaseService,
        IAuthenticationService authenticationService) : base(settingsService, databaseService)
    {
        _authenticationService = authenticationService;
        UserName = Constants.UserNameDefault;
        Password = Constants.PasswordDefault;
    }

    [RelayCommand]
    private async void Login()
    {
        var window = App.Window;
        var user = await _authenticationService.LoginUserAsync(UserName, Password);
        if (user != null && window != null)
        {
            //PR存储用户信息
            _settingsService.SavePreference("USER", user);
            window.Page = new AppShell();
        }
        else
        {
            App.Dialog("用户不存在！");
        }
    }

    [RelayCommand]
    private void ForgotPassword()
    {

    }
}
