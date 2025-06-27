using System.ComponentModel;
using System.Globalization;

namespace Dorisoy.DentalChair.Resources.Translations;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    private LocalizationResourceManager()
    {
        AppTranslations.Culture = CultureInfo.CurrentCulture;
    }

    public static LocalizationResourceManager Instance { get; } = new();

    public object this[string resourceKey] =>
        AppTranslations.ResourceManager.GetObject(resourceKey, AppTranslations.Culture) ?? Array.Empty<byte>();

    public static string Translate(string text)
    {
        var translation = AppTranslations.ResourceManager.GetString(text, AppTranslations.Culture);
        if (translation == null)
        {
            translation = text;
        }
        return translation;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public void SetCulture(CultureInfo culture)
    {
        AppTranslations.Culture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
