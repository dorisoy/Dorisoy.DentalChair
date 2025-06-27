namespace Dorisoy.DentalChair.Views;

public partial class AccountPage : ContentPage
{
    public AccountPage()
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
}