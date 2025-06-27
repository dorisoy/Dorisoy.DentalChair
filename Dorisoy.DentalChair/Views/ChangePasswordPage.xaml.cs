namespace Dorisoy.DentalChair.Views;

/// <summary>
/// ��������
/// </summary>
public partial class ChangePasswordPage : ContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
	}

    private async void GoBack_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
 
    }
}