namespace Dorisoy.DentalChair.Views;

public partial class SettingPage : ContentPage
{
    public SettingPage()
	{
        InitializeComponent();
    }

    /// <summary>
    /// ��ҳ�漴������ʱ����
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    private void TapGestureRecognizer_BackTapped(object sender, TappedEventArgs e)
    {
        var window = App.Window;
        if (window != null)
        {
            window.Page = new AppShell();
        }
    }
}