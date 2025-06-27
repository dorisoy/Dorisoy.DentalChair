using System.Reflection;

namespace Dorisoy.DentalChair.Services;

/// <summary>
/// 用于表示导航服务
/// </summary>
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// 导航到指定页面
    /// </summary>
    /// <param name="page"></param>
    public void NavigationPage(Page? page)
    {
        if (App.Window == null)
            return;

        if (page != null)
        {
            App.Window.Page = new NavigationPage(page);
        }
    }

    /// <summary>
    /// 导航到指定名称的页面
    /// </summary>
    /// <param name="pageName"></param>
    public void NavigationPage(string pageName)
    {
        if (App.Window == null)
            return;

        var page = GetPageInstance(pageName);
        if (page != null)
        {
            App.Window.Page = new NavigationPage(page);
        }
    }

    /// <summary>
    /// 异步导航到指定名称的页面
    /// </summary>
    /// <param name="pageName"></param>
    /// <returns></returns>
    public async Task NavigateToPageAsync(string pageName)
    {
        var mainPage = Application.Current?.Windows[0]?.Page;
        if (mainPage != null)
        {
            var page = GetPageInstance(pageName);
            if (page != null)
            {
                await mainPage.Navigation.PushAsync(page);
            }
        }
    }

    /// <summary>
    /// 获取页面实例
    /// </summary>
    /// <param name="pageName"></param>
    /// <returns></returns>
    private Page? GetPageInstance(string pageName)
    {
        // 获取应用程序集
        var assembly = Assembly.GetExecutingAssembly();

        // 页面命名空间在 Dorisoy.DentalChair.Views 下
        var fullTypeName = $"Dorisoy.DentalChair.Views.{pageName}";

        // 获取对应的类型
        var pageType = assembly.GetType(fullTypeName);
        if (pageType != null)
        {
            // 从服务提供者创建实例
            return _serviceProvider.GetService(pageType) as Page;
        }

        Console.WriteLine($"Page not found for the name:{pageName}");

        return null;
    }


    //private Type GetViewModelType(Type pageType)
    //{
    //    // e.g.,LoginPage -> LoginViewModel
    //    var viewModelName = pageType.Name.Replace("Page", "ViewModel");
    //    return Type.GetType($"{pageType.Namespace}.ViewModels.{viewModelName}");
    //}
}
