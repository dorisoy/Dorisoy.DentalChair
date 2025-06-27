namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 密码验证视图模型
/// </summary>
public partial class PasswordVerificationViewModel : BaseViewModel
{
    public PasswordVerificationViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {

    }

    [RelayCommand]
    private void Resend()
    {

    }

    [RelayCommand]
    private void Submit()
    {

    }
}
