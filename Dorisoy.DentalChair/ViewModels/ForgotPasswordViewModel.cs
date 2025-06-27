namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 密码找回视图模型
/// </summary>
public partial class ForgotPasswordViewModel : BaseViewModel
{
    public ForgotPasswordViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {

    }

    [RelayCommand]
    private void Submit()
    {

    }
}
