
namespace Dorisoy.DentalChair.ViewModels;

/// <summary>
/// 用于内口扫描视图模型
/// </summary>
public partial class Scan3DViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<CardData>? _myCardLists;

    public Scan3DViewModel(SettingsService settingsService,
        DatabaseService databaseService) : base(settingsService, databaseService)
    {
        //LoadData();
    }

    //void LoadData()
    //{
    //    Task.Run(async () =>
    //    {
    //        IsBusy = true;
    //        // await api call;
    //        await Task.Delay(1000);
    //        Application.Current.Dispatcher.Dispatch(() =>
    //        {
    //            MyCardLists = new ObservableCollection<CardData>(EwalletServices.Instance.GetMyCards);
    //            IsBusy = false;
    //        });
    //    });
    //}



}
