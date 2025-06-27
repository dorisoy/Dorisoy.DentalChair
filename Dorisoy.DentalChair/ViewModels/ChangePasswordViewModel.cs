namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 更新密码
/// </summary>
public partial class ChangePasswordViewModel : BaseViewModel
{
    public ChangePasswordViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {

    }

    [RelayCommand]
    private void Submit()
    {

    }
}
