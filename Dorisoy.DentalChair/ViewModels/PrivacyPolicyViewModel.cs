
namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 隐私和策略视图模型
/// </summary>
public partial class PrivacyPolicyViewModel : BaseViewModel
{
    [ObservableProperty]
    string _url;


    public PrivacyPolicyViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
       
    }
}
