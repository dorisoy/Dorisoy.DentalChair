using Dorisoy.DentalChair.Protocols;
using System.Diagnostics;

#if __ANDROID__

using ACR = Android.Content.Res;
using AG = Android.Graphics;

#endif

namespace Dorisoy.DentalChair;

public partial class App : Application
{
    private readonly DatabaseService _databaseService;
    private readonly SettingsService _settingsService;

    /// <summary>
    /// 获取服务提供
    /// </summary>
    public static IServiceProvider? Services { get; private set; }

    /// <summary>
    /// 定义一个静态的 Window 属性
    /// </summary>
    public static Window? Window { get; private set; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="services"></param>
    /// <param name="databaseService"></param>
    public App(IServiceProvider services, SettingsService settingsService, DatabaseService databaseService)
    {
        Services = services;
        _databaseService = databaseService;
        _settingsService = settingsService;

        InitializeComponent();

        // 未捕获到异常
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            var exception = e.ExceptionObject as Exception;
            Debug.WriteLine("Unhandled exception:" + exception?.ToString());
        };

        #region 自定义Handlers

        //Borderless entry
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(AG.Color.Transparent);
                handler.PlatformView.BackgroundTintList = ACR.ColorStateList.ValueOf(AG.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.White.CGColor;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                handler.PlatformView.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                handler.PlatformView.UnderlineThickness = new Windows.UI.Xaml.Thickness(0);
#endif
            }
        });

        //Borderless editor
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(BorderlessEditor), (handler, view) =>
        {
            if (view is BorderlessEditor)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(AG.Color.Transparent);
                handler.PlatformView.BackgroundTintList = ACR.ColorStateList.ValueOf(AG.Color.Transparent);
#elif __IOS__ || __MACCATALYST__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.White.CGColor;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;                
                handler.PlatformView.BorderThickness = new Thickness(0);
#endif
            }
        });

        //Picker
        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(BorderlessPicker), (handler, view) =>
        {
            if (view is BorderlessPicker)
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = ACR.ColorStateList.ValueOf(AG.Color.Transparent);
#elif __IOS__ || __MACCATALYST__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.White.CGColor;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;                
                handler.PlatformView.BorderThickness = new Thickness(0);
#endif

            }
        });

        #endregion

    }


    /// <summary>
    /// 在这里处理主题切换
    /// </summary>
    protected override void OnStart()
    {
        
        ThemeUtil.ApplyColorSet(AppSettings.SelectedPrimaryColorIndex);

        // 使用后台任务初始化种子用户
        Task.Run(async () => await CreateSeedUserAsync(_databaseService)).ConfigureAwait(false);
        
    }

    /// <summary>
    /// 应用程序进入后台时
    /// </summary>
    protected override void OnSleep()
    {
        // 关闭数据库连接
        //_databaseService.CloseConnection().Wait();
    }

    /// <summary>
    /// 应用程序从后台恢复时
    /// </summary>
    protected override void OnResume()
    {
        // 如果需要，重新打开连接
        //_databaseService.ReopenConnection();
    }

    /// <summary>
    /// 在 .NET 7 之后，启动窗口可以像这样在App.xaml.cs页面上轻松调整大小
    /// </summary>
    /// <param name="activationState"></param>
    /// <returns></returns>
    protected override Window CreateWindow(IActivationState? activationState)
    {
        // 默认页
        var startPage = new NavigationPage(new DemoStartPage());

        // 创建窗口
        Window = new Window(startPage)
        {
            Width = 1920,
            Height = 720
        };

        // BONUS -> Center the window
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

#if WINDOWS
        Window.X = (displayInfo.Width / displayInfo.Density - Window.Width) / 2;
        Window.Y = (displayInfo.Height / displayInfo.Density - Window.Height) / 2;
#endif
        return Window;
    }

    /// <summary>
    /// 全局对话框
    /// </summary>
    public static async void Dialog(string msg)
    {
        var isAlreadyOpen = PopupNavigation.Instance.PopupStack.Any(p => p is DialogPopup);
        if (!isAlreadyOpen)
            await PopupNavigation.Instance.PushAsync(new DialogPopup(msg));
    }

    /// <summary>
    /// 初始化种子用户
    /// </summary>
    /// <param name="databaseService"></param>
    /// <returns></returns>
    private static async Task CreateSeedUserAsync(DatabaseService databaseService)
    {
        try
        {
            var db = databaseService.GetConnection();
            // 检查是否已有种子用户
            var existingUser = await db.Table<User>()
                .FirstOrDefaultAsync(u => u.Name == Constants.UserNameDefault);
            if (existingUser == null)
            {
                // 创建种子用户
                var seedUser = new User
                {
                    Name = Constants.UserNameDefault,
                    Password = Constants.PasswordDefault,
                    Sex = "male",
                    CreatedAt = DateTime.Now
                };
                await db.InsertAsync(seedUser);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
