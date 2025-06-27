
namespace Dorisoy.DentalChair.Views.Onboardings;

public partial class DemoStartPage : ContentPage
{
    public DemoStartPage()
    {
        InitializeComponent();
    }

    private async void Skip_Clicked(object sender, EventArgs e)
    {
        var page = App.Services?.GetService<LoginPage>();
        if (page != null)
        {
            await Navigation.PushAsync(page);
        }
    }
}