using System.Reflection;
using System.Resources;

namespace Dorisoy.DentalChair.Resources.Translations;

[ContentProperty(nameof(Text))]
public class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string Text { get; set; }
    public IValueConverter Converter { get; set; }

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Text}]",
            Source = LocalizationResourceManager.Instance,
            Converter = Converter
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}
