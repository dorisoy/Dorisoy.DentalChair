using SimpleToolkit.SimpleShell.Extensions;

#if WINDOWS

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;

#endif

namespace Dorisoy.DentalChair;
public partial class AppShell : SimpleToolkit.SimpleShell.SimpleShell,INotifyPropertyChanged
{
    private IList<Image>? _svgSpliters;
    public AppShell()
    {
        InitializeComponent();

        this.Loaded += AppShell_Loaded;

        // 注册路由
        Routing.RegisterRoute(nameof(DemoStartPage), typeof(DemoStartPage));
        Routing.RegisterRoute(nameof(MobileTopupPage), typeof(MobileTopupPage));
        Routing.RegisterRoute(nameof(RootcanalPage), typeof(RootcanalPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
        Routing.RegisterRoute(nameof(DentalImplantationPage), typeof(DentalImplantationPage));
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));

        // 页面过度效果
        this.SetTransition(Transitions.CustomPlatformTransition);
    }

    /// <summary>
    /// 初始时控制 svgSpliters 特殊样式
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void AppShell_Loaded(object? sender, EventArgs e)
    {
        try
        {
            if (BindingContext is BaseViewModel viewModel)
                await viewModel.LoadDataAsync();

            _svgSpliters = ViewHelper.FindChildrenByStyleId<Image>(tabBar, "svgSpliter");
            if (_svgSpliters != null && _svgSpliters.Any())
            {
                _svgSpliters[0].IsVisible = false;
                _svgSpliters[1].IsVisible = false;
            }
        }
        catch (Exception)
        { }

        InitializeTimer();
    }


    private IDispatcherTimer? timer;
    private void InitializeTimer()
    {
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            systemTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        };
        timer.Start();
    }


    /// <summary>
    /// 通知提醒
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnNotification_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new NotificationsPage());
    }


    /// <summary>
    /// 当前shellItem
    /// </summary>
    private BaseShellItem? shellItem;


    /// <summary>
    /// Tab导航
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void ShellItemButtonClicked(object sender, TappedEventArgs e)
    {
        BaseShellItem? bs = null;

        if (sender is Microsoft.Maui.Controls.Grid button)
        {
            bs = button.BindingContext as BaseShellItem;
        }

        if (sender is Microsoft.Maui.Controls.Image img)
        {
            bs = img.BindingContext as BaseShellItem;
        }

        if (bs != null)
        {
            if (_svgSpliters != null && _svgSpliters.Any())
            {
                if (bs.Route.Equals("IMPL_ChairPage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = false;
                    _svgSpliters[2].IsVisible = true;
                    _svgSpliters[3].IsVisible = true;
                    _svgSpliters[4].IsVisible = true;
                    _svgSpliters[5].IsVisible = true;
                }
                else if (bs.Route.Equals("IMPL_HandpiecePage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = false;
                    _svgSpliters[2].IsVisible = false;
                    _svgSpliters[3].IsVisible = true;
                    _svgSpliters[4].IsVisible = true;
                    _svgSpliters[5].IsVisible = true;
                }
                else if (bs.Route.Equals("IMPL_Scan3DPage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = true;
                    _svgSpliters[2].IsVisible = false;
                    _svgSpliters[3].IsVisible = false;
                    _svgSpliters[4].IsVisible = true;
                    _svgSpliters[5].IsVisible = true;
                }
                else if (bs.Route.Equals("IMPL_RootcanalPage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = true;
                    _svgSpliters[2].IsVisible = true;
                    _svgSpliters[3].IsVisible = true;
                    _svgSpliters[4].IsVisible = false;
                    _svgSpliters[5].IsVisible = true;
                }
                else if (bs.Route.Equals("IMPL_DentalImplantationPage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = true;
                    _svgSpliters[2].IsVisible = true;
                    _svgSpliters[3].IsVisible = true;
                    _svgSpliters[4].IsVisible = false;
                    _svgSpliters[5].IsVisible = false;
                }
                else if (bs.Route.Equals("IMPL_AccountPage"))
                {
                    _svgSpliters[0].IsVisible = false;
                    _svgSpliters[1].IsVisible = true;
                    _svgSpliters[2].IsVisible = true;
                    _svgSpliters[3].IsVisible = true;
                    _svgSpliters[4].IsVisible = true;
                    _svgSpliters[5].IsVisible = false;
                }
            }

            // 如果新选项卡不是当前选项卡，请导航到该选项卡
            if (!CurrentState.Location.OriginalString.Contains(bs.Route))
            {
                await GoToAsync($"///{bs.Route}");
            }
        }
    }

    /// <summary>
    /// 回退
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await GoToAsync("..");
    }

    /// <summary>
    /// 右侧栏菜单折叠
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (rightSliderMenu.IsVisible)
        {
            mianLayout.ColumnDefinitions.Clear();
            mianLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            rightSliderMenu.IsVisible = false;
            // 移出动画
            //var translateTask = rightSliderMenu.TranslateTo(this.Width, 0, 500, Easing.CubicOut);
            await rightSliderMenu.FadeTo(0, 500, Easing.CubicOut);
        }
        else
        {
            mianLayout.ColumnDefinitions.Clear();
            mianLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8.2, GridUnitType.Star) });
            mianLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.8, GridUnitType.Star) });
            rightSliderMenu.IsVisible = true;
            // 移入动画
            //var translateTask = rightSliderMenu.TranslateTo(0, 0, 500, Easing.CubicIn);
            await rightSliderMenu.FadeTo(1, 500, Easing.CubicIn);
        }
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
#if WINDOWS
           if(Microsoft.Maui.Controls.Application.Current!= null)
           {
               var window = Microsoft.Maui.Controls.Application.Current.Windows[0].Handler.PlatformView as Microsoft.UI.Xaml.Window;
               var hwnd = WindowNative.GetWindowHandle(window);
               var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
               var appWindow = AppWindow.GetFromWindowId(windowId);
               if (appWindow != null)
               {
                   appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

                   var presenter = appWindow.Presenter as OverlappedPresenter;
                   if (presenter != null)
                   {
                       presenter.SetBorderAndTitleBar(false,false);
                   }
               }
           }
#endif
    }

    /// <summary>
    /// 渐入渐出闪烁动画
    /// </summary>
    /// <param name="control"></param>
    private void StartFlashingAnimation(View? control)
    {
        if (control != null)
        {
            var animation = new Animation(
                callback: v => control.Opacity = v,
                start: 1.0,   // Fully opaque
                end: 0.0,     // Fully transparent
                easing: Easing.Linear);

            animation = new Animation
           {
               { 0,0.5,new Animation(v => control.Opacity = v,1,0,Easing.SinIn) },
               { 0.5,1,new Animation(v => control.Opacity = v,0,1,Easing.SinOut) }
           };

            animation.Commit(this, "FlashingAnimation", length: 1000, repeat: () => true);
        }
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPointerPressed(object sender, EventArgs e)
    {
        if (sender is Border control)
        {
            control.Background = Color.FromArgb("#F8B544");
        }
    }

    /// <summary>
    /// 抬起
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPointerReleased(object sender, EventArgs e)
    {
        if (sender is Border control)
        {
            control.Background = Color.FromArgb("#FFFFFF");
        }
    }

    /// <summary>
    /// 闹钟测试1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Tap_AlarmClock1(object sender, EventArgs e)
    {
        var control = sender as BorderButton;
        if (control != null)
        {
            AlarmClock(control, 10);
        }
    }

    /// <summary>
    /// 闹钟测试2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Tap_AlarmClock2(object sender, EventArgs e)
    {
        var control = sender as BorderButton;
        if (control != null)
        {
            AlarmClock(control, 30);
        }
    }

    private bool _isAnimating = false;

    /// <summary>
    /// 闹钟控制
    /// </summary>
    private void AlarmClock(BorderButton control, int t)
    {
        // 如果动画已经在进行
        if (_isAnimating)
        {
            return;
        }

        // 开始动画时设定标志为 true
        _isAnimating = true;

        // 获取当前的页面
        var currentPage = Shell.Current.CurrentPage as ChairPage;
        if (currentPage?.BindingContext is ChairViewModel viewModel)
        {
            viewModel.SetupTimer(() =>
            {
                /*
                 从动画的开始（0）到结束（1.0）全程运行该缩放动画。
                 动画的目标是 AnimateButton.Scale 属性从 0.8 缩小到 1
                 使用 Easing.CubicInOut 进行缓动
                */
                // 添加动画
                var animation = new Animation
                    {
                        //{ 0,1.0,new Animation(v => control.Scale = v , 0.5,1,Easing.CubicInOut)},
                        //{ 0,1.0,new Animation(v => control.Opacity = v , 0.8,1,Easing.CubicInOut)},
                        { 0,1.0,new Animation(v => { control.Background = Color.Parse("#F8B544");})},
                        { 0.5,1.0,new Animation(v => { control.Background = Color.Parse("#FFFFFF");})}
                    };
                animation.Commit(this,
                    "FlashingAnimation",
                    length: 1000,
                    repeat: () => _isAnimating,
                    finished: (v, c) =>
                    {
                        //动画恢复到原始状态
                        //control.Scale = 1;
                    });
            },
            () =>
            {
                _isAnimating = false;
            }, 0, t);
        }
    }


    /// <summary>
    /// 导航系统设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SettingTab_Tapped(object sender, TappedEventArgs e)
    {
        if (App.Window == null) return;
        App.Window.Page = new NavigationPage(new SettingPage());
    }

    /// <summary>
    /// 锁屏页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void LockTab_Tapped(object sender, TappedEventArgs e)
    {
        var isAlreadyOpen = PopupNavigation.Instance.PopupStack.Any(p => p is LockPopup);
        if (!isAlreadyOpen)
            await PopupNavigation.Instance.PushAsync(new LockPopup());
    }
}
