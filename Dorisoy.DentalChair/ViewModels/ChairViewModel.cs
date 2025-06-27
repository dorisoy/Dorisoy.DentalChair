using CommunityToolkit.Mvvm.Messaging;
using Dorisoy.DentalChair.Messages;
using System.Diagnostics;

namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 椅位控制视图模型
/// </summary>
public partial class ChairViewModel : BaseViewModel
{
    private static bool isLightOpen;
    [ObservableProperty]
    private ObservableCollection<TransactionData> _recentTransactions;

    [ObservableProperty]
    private UserInfo _userInfo;

    [ObservableProperty]
    private double demoNumber;

    [ObservableProperty]
    private Color gaugeColor;

    [ObservableProperty]
    private double sliderMax;

    [ObservableProperty]
    private string countdownLabel;

    [ObservableProperty]
    private string remainingTime;

    [ObservableProperty]
    private DateTime countdown;

    [ObservableProperty]
    private double percent;

    [ObservableProperty]
    private int totaSeconds;

    [ObservableProperty]
    private double remainingSeconds;

    public ChairViewModel(SettingsService settingsService,
        DatabaseService databaseService, DentalChairCommunicationService DentalChairCommunicationService) : base(settingsService, databaseService)
    {
        this.DentalChairCommunicationService = DentalChairCommunicationService;
        WeakReferenceMessenger.Default.Register<StatusDataChangeMessage>(this, (r, m) =>
        {
            //TODO:解析必要数据
        });
    }

    public override async Task UnregisterAsync()
    {
        WeakReferenceMessenger.Default.Unregister<StatusDataChangeMessage>(this);
        await Task.CompletedTask;
    }

    public override async Task LoadDataAsync()
    {
        await Task.Delay(500);
        UserInfo = MockServices.Instance.GetUserInfo;
        RecentTransactions = new ObservableCollection<TransactionData>(MockServices.Instance.GetTransactions);
        Countdown = DateTime.Now.AddMinutes(0).AddSeconds(0);
        CountdownLabel = "Start";
        RemainingTime = "00:00";
    }

    private System.Threading.Timer _timer;
    private Stopwatch _stopwatch;
    private double _targetTimeInSeconds;
    private int _tickCount = 0;
    private const int TicksPerSecond = 2;
    private readonly DentalChairCommunicationService DentalChairCommunicationService;

    public void SetupTimer(Action call, Action stop, int minutes, int seconds)
    {
        TotaSeconds = minutes * 60 + seconds;
        _targetTimeInSeconds = TotaSeconds;

        var state = new TimerState
        {
            // 不需要重复执行
            //OnStart = () => call?.Invoke(),
            OnStop = () => stop?.Invoke()
        };

        // 执行开始动画
        call?.Invoke();

        CountdownLabel = "Start";

        _stopwatch = new Stopwatch();
        // 确保在启动前
        _stopwatch.Start();

        // 更频繁的间隔时间
        _timer = new System.Threading.Timer(OnTimedEvent, state, 0, 500);
    }

    public class TimerState
    {
        public Action? OnStart { get; set; }
        public Action? OnStop { get; set; }
    }

    private async void OnTimedEvent(object? state)
    {
        _tickCount++;

        // 使用 Stopwatch 来获取经过的时间
        double elapsedSeconds = _stopwatch.Elapsed.TotalSeconds;
        RemainingSeconds = _targetTimeInSeconds - elapsedSeconds;

        if (RemainingSeconds >= 0)
        {
            //从 0 ~ 100%
            //Percent = (elapsedSeconds / TotaSeconds) * 100;

            //从 100 ~ 0%
            Percent = (RemainingSeconds / TotaSeconds) * 100;
            if (Percent < 0)
            {
                Percent = 0;
            }

            // 在整秒时进行处理
            if (_tickCount >= TicksPerSecond)
            {
                _tickCount = 0;// 重置计数器
                if (Application.Current != null)
                {
                    await Application.Current.Dispatcher.DispatchAsync(() =>
                    {
                        TimeSpan timeSpan = TimeSpan.FromSeconds(RemainingSeconds);
                        RemainingTime = timeSpan.ToString(@"mm\:ss");
                    });
                }
            }
        }
        else
        {
            //从 0 ~ 100%
            //Percent = 100;
            //从 100 ~ 0%

            Percent = 0;
            RemainingTime = "00:00";

            _timer?.Dispose();
            _stopwatch?.Stop();

            if (state is TimerState timerState)
            {
                timerState?.OnStop?.Invoke();
            }

            if (Application.Current != null)
            {
                await Application.Current.Dispatcher.DispatchAsync(() =>
                {
                    CountdownLabel = "Completed";
                });
            }
        }
    }

    /// <summary>
    /// 升
    /// </summary>
    [RelayCommand]
    private void ChairUp()
    {
        DentalChairCommunicationService.ChairControlUp();
    }

    /// <summary>
    /// 降
    /// </summary>
    [RelayCommand]
    private void ChairDown()
    {
        DentalChairCommunicationService.ChairControlDown();
    }

    /// <summary>.
    /// 停
    /// </summary>
    [RelayCommand]
    private void ChairStop()
    {
        DentalChairCommunicationService.ChairControlStop();
    }

    /// <summary>
    /// 俯
    /// </summary>
    [RelayCommand]
    private void ChairControlProne()
    {
        DentalChairCommunicationService.ChairControlProne();
    }

    /// <summary>
    /// 仰
    /// </summary>
    [RelayCommand]
    private void ChairControlUpward()
    {
        DentalChairCommunicationService.ChairControlUpward();
    }

    /// <summary>
    /// 器械盘：升
    /// </summary>
    [RelayCommand]
    private void InstrumentTrayUp()
    {
        DentalChairCommunicationService.InstrumentTrayUp();
    }

    /// <summary>
    /// 器械盘：降
    /// </summary>
    [RelayCommand]
    private void InstrumentTrayDown()
    {
        DentalChairCommunicationService.InstrumentTrayDown();
    }

    /// <summary>
    /// 器械盘：停
    /// </summary>
    [RelayCommand]
    private void InstrumentTrayStop()
    {
        DentalChairCommunicationService.InstrumentTrayStop();
    }

    /// <summary>
    /// 椅位：急救位
    /// </summary>
    [RelayCommand]
    private void ChairControlFirstAid()
    {
        DentalChairCommunicationService.ChairControlFirstAid(0, 0);
    }

    /// <summary>
    /// 椅位：0
    /// </summary>
    [RelayCommand]
    private void ChairControl0()
    {
        DentalChairCommunicationService.ChairControl0(0, 0);
    }

    /// <summary>
    /// 椅位：1
    /// </summary>
    [RelayCommand]
    private void ChairControl1()
    {
        DentalChairCommunicationService.ChairControl1(1, 1);
    }

    /// <summary>
    /// 椅位：2
    /// </summary>
    [RelayCommand]
    private void ChairControl2()
    {
        DentalChairCommunicationService.ChairControl2(2, 2);
    }

    /// <summary>
    /// 椅位：3
    /// </summary>
    [RelayCommand]
    private void ChairControl3()
    {
        DentalChairCommunicationService.ChairControl3(3, 3);
    }

    /// <summary>
    /// 开关灯
    /// </summary>
    [RelayCommand]
    private void LightTurnOnOff()
    {
        if (isLightOpen)
            DentalChairCommunicationService.LightTurnOff();
        else
            DentalChairCommunicationService.LightTurnOn();
        isLightOpen = !isLightOpen;
    }

    /// <summary>
    /// 水杯加热
    /// </summary>
    [RelayCommand]
    private void HotWaterOn()
    {
        DentalChairCommunicationService.HotWaterOn();
    }
}
