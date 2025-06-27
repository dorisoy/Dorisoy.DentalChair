
namespace Dorisoy.DentalChair.Views.Onboardings;

public partial class StartBackgroundPage : ContentPage
{
	public StartBackgroundPage()
	{
		InitializeComponent();
	}

    private async void Skip_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}