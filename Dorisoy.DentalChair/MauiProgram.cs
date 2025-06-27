#if WINDOWS

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
using Microsoft.UI.Dispatching;

#endif

#if ANDROID

using AndroidX.Core.View;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.OS;
using AView = Android.Views.View;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

#endif

using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using PanCardView;
using RGPopup.Maui.Extensions;
using SimpleToolkit.SimpleShell;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Dorisoy.DentalChair.Protocols;

namespace Dorisoy.DentalChair
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();

            // 使用 UseDatabase 扩展
            //builder.Services.UseDatabase();

            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()

            // 启用SkiaSharp
            .UseSkiaSharp()
            .UseSkiaSharp(true)

            // 启用SimpleShell
            .UseSimpleShell()

            .UseCardsView()
            .RegisterServices()
            .UseMauiRGPopup(config =>
            {
                config.BackPressHandler = null;
                config.FixKeyboardOverlap = true;
            })
            .RegisterViews()
            .RegisterViewModels()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("ionicons.ttf", "IonIcons");
                fonts.AddFont("icon.ttf", "MauiKitIcons");
            })
            .ConfigureLifecycleEvents(events =>
             {
#if ANDROID
                 events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                 static void MakeStatusBarTranslucent(Android.App.Activity activity)
                 {
                     //activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);
                     activity.Window?.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
                     //activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                     activity.Window?.SetNavigationBarColor(Android.Graphics.Color.Black);
                 }
#endif
             });

            builder.Services.AddLocalization();

#if WINDOWS

            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                        //https://github.com/dotnet/maui/issues/7751
                        window.ExtendsContentIntoTitleBar = false;
                        winuiAppWindow.SetPresenter(AppWindowPresenterKind.Default);


                        //https://github.com/dotnet/maui/issues/6976
                        //var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(win32WindowsId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);

                        //int width = displayArea.WorkArea.Width * 2 / 3;
                        //int height = displayArea.WorkArea.Height - 10;

                         // 通过 DispatcherQueue 在 UI 线程上执行操作
                        var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
                        dispatcherQueue.TryEnqueue(() =>
                        {
                            // 设置最大化状态
                            var presenter = winuiAppWindow.Presenter as OverlappedPresenter;
                            if (presenter != null)
                            {
                                // 禁止窗口缩放
                                presenter.IsResizable = false;
                                presenter.IsMaximizable = false;
                                // 设置窗口为无边框
                                //presenter.SetBorderAndTitleBar(false,false);
                            }
                        });
                        
                        //var cp = winuiAppWindow.Position;
                        //cp.X = ((displayArea.WorkArea.Width - winuiAppWindow.Size.Width) / 2);
                        //cp.Y = ((displayArea.WorkArea.Height - winuiAppWindow.Size.Height) / 2);
                        //winuiAppWindow.Move(cp);

                        //winuiAppWindow.Resize(new SizeInt32(1920,720));
                    });
                });
            });

            /*
              builder.ConfigureLifecycleEvents(events =>
                {
                    events.AddWindows(wndLifeCycleBuilder =>
                    {
                        wndLifeCycleBuilder.OnWindowCreated(window =>
                        {
                            IntPtr hWnd = WindowNative.GetWindowHandle(window);
                            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
                            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);


                            //https://github.com/dotnet/maui/issues/7751
                            window.ExtendsContentIntoTitleBar = false; // must be false or else you see some of the buttons
                            appWindow.SetPresenter(AppWindowPresenterKind.Default);


                          
                            // 全屏模式设置（以下代码可能需要根据实现的不同版本进行修改）
                            //appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

                            // 通过 DispatcherQueue 在 UI 线程上执行操作
                            var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
                            dispatcherQueue.TryEnqueue(() =>
                            {
                                // 设置最大化状态
                                var presenter = appWindow.Presenter as OverlappedPresenter;
                                if (presenter != null)
                                {
                                    // 设置窗口最大化
                                    presenter.Maximize();
                                }
                            });
                        });

                    });
                });
            */
#endif
            return builder.Build();
        }


        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="mauiAppBuilder"></param>
        /// <returns></returns>
        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            // 注册导航服务
            mauiAppBuilder.Services.AddSingleton<INavigationService,NavigationService>();
            mauiAppBuilder.Services.AddSingleton<SettingsService>();
            mauiAppBuilder.Services.AddSingleton<DatabaseService>();
            mauiAppBuilder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            mauiAppBuilder.Services.AddSingleton<DentalChairCommunicationService>();
            return mauiAppBuilder;
        }

        /// <summary>
        /// 注册视图模型
        /// </summary>
        /// <param name="mauiAppBuilder"></param>
        /// <returns></returns>
        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<AccountViewModel>();
            mauiAppBuilder.Services.AddTransient<ChairViewModel>();
            mauiAppBuilder.Services.AddTransient<ChangePasswordViewModel>();
            mauiAppBuilder.Services.AddTransient<DentalImplantationViewModel>();
            mauiAppBuilder.Services.AddTransient<ForgotPasswordViewModel>();
            mauiAppBuilder.Services.AddTransient<HandpieceViewModel>();
            mauiAppBuilder.Services.AddTransient<MobileTopupViewModel>();
            mauiAppBuilder.Services.AddTransient<NotificationsViewModel>();
            mauiAppBuilder.Services.AddTransient<PasswordVerificationViewModel>();
            mauiAppBuilder.Services.AddTransient<RootcanalViewModel>();
            mauiAppBuilder.Services.AddTransient<Scan3DViewModel>();
            mauiAppBuilder.Services.AddTransient<DemoWalkthroughViewModel>();
            mauiAppBuilder.Services.AddTransient<AccountViewModel>();
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            mauiAppBuilder.Services.AddTransient<AppShellViewModel>();
            mauiAppBuilder.Services.AddTransient<PrivacyPolicyViewModel>();
            mauiAppBuilder.Services.AddTransient<ThemeSettingsPopupViewModel>();

            return mauiAppBuilder;
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <param name="mauiAppBuilder"></param>
        /// <returns></returns>
        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<AccountUpdatePage>();
            mauiAppBuilder.Services.AddTransient<ChairPage>();
            mauiAppBuilder.Services.AddTransient<ChangePasswordPage>();
            mauiAppBuilder.Services.AddTransient<DentalImplantationPage>();
            mauiAppBuilder.Services.AddTransient<ForgotPasswordPage>();
            mauiAppBuilder.Services.AddTransient<HandpiecePage>();
            mauiAppBuilder.Services.AddTransient<LockPopup>();
            mauiAppBuilder.Services.AddTransient<MobileTopupPage>();
            mauiAppBuilder.Services.AddTransient<NotificationsPage>();
            mauiAppBuilder.Services.AddTransient<PasswordVerificationPage>();
            mauiAppBuilder.Services.AddTransient<RootcanalPage>();
            mauiAppBuilder.Services.AddTransient<Scan3DPage>();
            mauiAppBuilder.Services.AddTransient<DemoStartPage>();
            mauiAppBuilder.Services.AddTransient<AccountPage>();
            mauiAppBuilder.Services.AddTransient<SettingPage>();
            mauiAppBuilder.Services.AddTransient<LoginPage>();
            mauiAppBuilder.Services.AddTransient<AppShell>();

            return mauiAppBuilder;
        }

 
    }
}
