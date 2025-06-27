namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 主Shell框架视图模型
/// </summary>
public partial class AppShellViewModel : BaseViewModel
{
    public ObservableCollection<TransactionData> DataSource { get; private set; }

    [ObservableProperty]
    private int _torque;

    [ObservableProperty]
    private int _rotationRate;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get
        {
            return _selectedIndex;
        }
        set
        {
            _selectedIndex = value;
            UpdateListViewData();
        }
    }

    public AppShellViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {

    }

    /// <summary>
    /// 载入数据
    /// </summary>
    /// <returns></returns>
    public override Task LoadDataAsync()
    {
        var currentUser = _settingsService.GetPreference<User>("USER");
        if (currentUser != null)
            User = currentUser;

        DataSource =
        [
            new() { Duration = "DR.BOR" },
            new() { Duration = "DORISOY.Dorisoy.DentalChair" },
            new() { Duration = "ZHONGHONG.CHEN" },
        ];

        return Task.CompletedTask;
    }


    private void UpdateListViewData()
    {
        switch (SelectedIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    [RelayCommand]
    private async void CloseLock()
    {
        await PopupNavigation.Instance.PopAsync();
    }
}
