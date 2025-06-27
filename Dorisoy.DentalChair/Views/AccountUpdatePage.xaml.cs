namespace Dorisoy.DentalChair.Views;
public partial class AccountUpdatePage : PopupPage
{
    public AccountUpdatePage()
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

    private async void SubmitButton_Clicked(object sender, EventArgs e)
    {
        await PopupNavigation.Instance.PopAsync();
    }
}
