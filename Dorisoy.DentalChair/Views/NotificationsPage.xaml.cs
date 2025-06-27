namespace Dorisoy.DentalChair.Views;
public partial class NotificationsPage : ContentPage
{
    public NotificationsPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 在页面即将出现时触发
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    private async void OnClose_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
