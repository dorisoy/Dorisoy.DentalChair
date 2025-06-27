namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 用于根管治疗视图模型
/// </summary>
public partial class RootcanalViewModel : BaseViewModel
{
    [ObservableProperty]
    private double _torque;

    [ObservableProperty]
    private double _rotationRate;


    public RootcanalViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        RotationRate = 1500;
        Torque = 0.06;
    }

    [RelayCommand]
    private void IncreaseRotation()
    {
        if (RotationRate < 1500)
            RotationRate += 100;
    }

    [RelayCommand]
    private void ReduceRotation()
    {
        if (RotationRate > 0)
            RotationRate -= 100;
    }

    [RelayCommand]
    private void IncreaseTorque()
    {
        if (Torque < 0.2)
            Torque = Math.Round(Torque + 0.01, 2);
    }

    [RelayCommand]
    private void ReduceTorque()
    {
        if (Torque > 0.06)
            Torque = Math.Round(Torque - 0.01, 2);
    }
}
