namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 头部弹出设置栏视图模型
/// </summary>
public partial class MobileTopupViewModel : BaseViewModel
{
    public MobileTopupViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        LoadData();
    }

    void LoadData()
    {
        Task.Run(async () =>
        {
            IsBusy = true;
            // await api call;
            await Task.Delay(1000);
            Application.Current.Dispatcher.Dispatch(() =>
            {
                ContactLists = new ObservableCollection<WalletContact>(MockServices.Instance.GetContacts);

                IsBusy = false;
            });
        });
    }


    [ObservableProperty]
    public ObservableCollection<WalletContact> _contactLists;
}
