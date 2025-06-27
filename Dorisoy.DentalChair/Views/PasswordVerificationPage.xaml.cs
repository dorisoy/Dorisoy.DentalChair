namespace Dorisoy.DentalChair.Views;

public partial class PasswordVerificationPage : ContentPage
{
	public PasswordVerificationPage()
	{
		InitializeComponent();
	}

    private async void GoBack_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ContinueButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChangePasswordPage());
    }
}