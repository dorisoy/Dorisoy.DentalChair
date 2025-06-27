using System.Diagnostics;
using System.Reflection;

namespace Dorisoy.DentalChair;

/// <summary>
/// 创建了一个附加属性，以标记当需要自动关联 ViewModel 时的处理逻辑
/// </summary>
public static class ViewModelLocator
{
    public static readonly BindableProperty AutoWireViewModelProperty =
        BindableProperty.CreateAttached(
            "AutoWireViewModel",
            typeof(bool),
            typeof(ViewModelLocator),
            default(bool),
            propertyChanged: OnAutoWireViewModelChanged);

    public static bool GetAutoWireViewModel(BindableObject bindable)
    {
        return (bool)bindable.GetValue(AutoWireViewModelProperty);
    }

    public static void SetAutoWireViewModel(BindableObject bindable, bool value)
    {
        bindable.SetValue(AutoWireViewModelProperty, value);
    }

    /// <summary>
    /// 通过 OnAutoWireViewModelChanged 方法，查找对应的 ViewModel 类型，实现自动绑定
    /// </summary>
    /// <param name="bindable"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        try
        {
            if (bindable is Element view && newValue is bool autoWire && autoWire)
            {
                var viewType = view.GetType();
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewPageName = viewName?.Replace("Views", "ViewModels");

                // 注：AppShell 在这里先这样特殊处理
                if (viewPageName == "Dorisoy.DentalChair.AppShell")
                    viewPageName = "Dorisoy.DentalChair.ViewModels.AppShellViewModel";

                var viewModelName = $"{viewPageName?.Replace("Page", "ViewModel")},{viewAssemblyName}";
                var viewModelType = Type.GetType(viewModelName);
                if (viewModelType != null)
                {
                    var viewModel = App.Services?.GetService(viewModelType);
                    view.BindingContext = viewModel;
                }
            }
        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
    }
}
