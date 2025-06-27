
namespace Dorisoy.DentalChair.Helpers;

/// <summary>
/// 用于服务获取辅助器
/// </summary>
public static class ServiceHelper
{
    /// <summary>
    /// 获取服务
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    public static TService GetService<TService>() => Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
#else
            null;
#endif
}
