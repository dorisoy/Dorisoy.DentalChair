namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 用于主题切换视图模型
/// </summary>
public partial class ThemeSettingsPopupViewModel : BaseViewModel
{
    public ThemeSettingsPopupViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        //DarkModeSwitchToggled = AppSettings.IsDarkMode;
        //SelectedPrimaryColorItem = AppSettings.SelectedPrimaryColorItem;
        //SelectedPrimaryColor = AppSettings.SelectedPrimaryColorIndex;
    }

    private PrimaryColorItem selectedPrimaryColorItem;
    public PrimaryColorItem SelectedPrimaryColorItem
    {
        get => selectedPrimaryColorItem;
        set
        {
            SetProperty(ref selectedPrimaryColorItem, value);
            AppSettings.SelectedPrimaryColorItem = value;
            //AppSettings.SelectedPrimaryColorIndex = value.Index;
            ThemeUtil.ApplyColorSet(value.Index);
        }
    }

    private int selectedPrimaryColor;
    public int SelectedPrimaryColor
    {
        get => selectedPrimaryColor;
        set
        {
            SetProperty(ref selectedPrimaryColor, value);
            AppSettings.SelectedPrimaryColorIndex = value;
        }
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
    }
}
