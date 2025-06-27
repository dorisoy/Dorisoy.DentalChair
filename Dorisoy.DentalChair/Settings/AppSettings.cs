
namespace Dorisoy.DentalChair.Settings;

public static class Constants
{
    public readonly static string UserNameDefault = "admin";
    public readonly static string PasswordDefault = "admin@Dorisoy.DentalChair.com";
}

public class AppSettings
{
    public static bool IsFirstLaunching
    {
        get => Preferences.Get(nameof(IsFirstLaunching), true);
        set => Preferences.Set(nameof(IsFirstLaunching), value);
    }

    public static bool IsDarkMode
    {
        get => Preferences.Get(nameof(IsDarkMode), false);
        set => Preferences.Set(nameof(IsDarkMode), value);
    }

    public static int SelectedPrimaryColorIndex
    {
        get => Preferences.Get(nameof(SelectedPrimaryColorIndex), 0);
        set => Preferences.Set(nameof(SelectedPrimaryColorIndex), value);
    }

    public static PrimaryColorItem SelectedPrimaryColorItem
    {
        get => PreferencesHelpers.Get(nameof(SelectedPrimaryColorItem), default(PrimaryColorItem));
        set
        {
            PreferencesHelpers.Set(nameof(SelectedPrimaryColorItem), value);
            SelectedPrimaryColorIndex = value.Index;
        }
    }
}
