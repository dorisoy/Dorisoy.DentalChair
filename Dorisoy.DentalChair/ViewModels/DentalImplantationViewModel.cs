namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 种植机视图模型
/// </summary>
public partial class DentalImplantationViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Boarding> _boardings;

    [ObservableProperty]
    private int _position = 0;

    [ObservableProperty]
    private double _torque;

    [ObservableProperty]
    private double _rotationRate;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get
        {
            return _selectedIndex;
        }
        set
        {
            _selectedIndex = value;
            //UpdateListViewData();
        }
    }

    public DentalImplantationViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        RotationRate = 6000;
        Torque = 0.06;

        Boardings = new ObservableCollection<Boarding>();
        CreateBoardingCollection();
    }

    [RelayCommand]
    private void Increase()
    {
        RotationRate += 100;
    }

    [RelayCommand]
    private void Reduce()
    {
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

    void CreateBoardingCollection()
    {
        Boardings = new ObservableCollection<Boarding>
        {
            new() {Title = "T1"},
            new() {Title = "T2"},
            new() {Title = "T3"}
        };
    }
}
