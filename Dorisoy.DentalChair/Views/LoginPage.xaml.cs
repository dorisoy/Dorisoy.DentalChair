namespace Dorisoy.DentalChair.Views;

/// <summary>
/// ��¼ҳ
/// </summary>
public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
        InitializeComponent();
    }

    private async void GoBack_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new DemoStartPage());
    }

    private async void ForgotPassword_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }
}