
namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 系统提醒视图模型
/// </summary>
public partial class NotificationsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Notification> _notifications;
    
    public NotificationsViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        LoadData();
    }

    void LoadData()
    {
        Notifications = new ObservableCollection<Notification>(MockServices.Instance.GetNotifications);
    }

}
