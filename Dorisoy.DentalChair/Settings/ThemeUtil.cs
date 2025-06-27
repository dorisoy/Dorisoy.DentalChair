namespace Dorisoy.DentalChair.Settings;
public static class ThemeUtil
{
    public static void ApplyDarkTheme(this ResourceDictionary resources)
    {
        if (resources != null && Application.Current != null)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                var lightTheme = mergedDictionaries.OfType<LightTheme>().FirstOrDefault();
                if (lightTheme != null)
                {
                    mergedDictionaries.Remove(lightTheme);
                }
                mergedDictionaries.Add(new DarkTheme());
            }
        }
    }

    public static void ApplyLightTheme(this ResourceDictionary resources)
    {
        if (resources != null && Application.Current != null)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                var darkTheme = mergedDictionaries.OfType<DarkTheme>().FirstOrDefault();
                if (darkTheme != null)
                {
                    mergedDictionaries.Remove(darkTheme);
                }
                mergedDictionaries.Add(new LightTheme());
            }
        }
    }

    public static void ApplyColorSet(int index)
    {
        switch (index)
        {
            case 0:
                ApplyColorSet1();
                break;
            case 1:
                ApplyColorSet2();
                break;
        }
    }

    public static void ApplyColorSet1()
    {
        if (Application.Current != null)
        {
            Application.Current.Resources.TryGetValue("ThemePrimaryColorOption1", out var primaryColorOption1);
            Application.Current.Resources["LinearGradientStartColor"] = Color.FromArgb("#313F4A");
            Application.Current.Resources["LinearGradientEndColor"] = Color.FromArgb("#000000");
            Application.Current.Resources["PrimaryColor"] = (Color)primaryColorOption1;
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromArgb("#313F4A");
        }
    }

    public static void ApplyColorSet2()
    {
        if (Application.Current != null)
        {
            Application.Current.Resources.TryGetValue("ThemePrimaryColorOption2", out var primaryColorOption2);
            Application.Current.Resources["LinearGradientStartColor"] = Color.FromArgb("#313F4A");
            Application.Current.Resources["LinearGradientEndColor"] = Color.FromArgb("#000000");
            Application.Current.Resources["PrimaryColor"] = (Color)primaryColorOption2;
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromArgb("#313F4A");
        }
    }
}
