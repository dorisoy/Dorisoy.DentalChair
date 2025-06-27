
namespace Dorisoy.DentalChair.Views.Onboardings;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}


    private async void Skip_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        //await Shell.Current.GoToAsync("..");
    }
}