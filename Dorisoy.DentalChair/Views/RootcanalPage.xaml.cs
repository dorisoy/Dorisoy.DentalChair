using Microsoft.Maui.Controls;

namespace Dorisoy.DentalChair.Views;
public partial class RootcanalPage : ContentPage
{
	public RootcanalPage()
	{
		InitializeComponent();

        animatedTorque.TranslationX = -257;
        //animatedTorque.Opacity = 0;

        //animatedRotationRate_Ellipse1.Opacity = 0;
        //animatedRotationRate_Ellipse2.Opacity = 0;

        animatedRotationRate.TranslationY = -257;
        //animatedRotationRate.Opacity = 0;

     
    }


    /// <summary>
    /// ��ҳ�漴������ʱ����
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        OnPageAppearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    private void OnPageAppearing()
    {
        Dispatcher.Dispatch(async () =>
        {
            animatedTorque.TranslationX = -257;
            //animatedTorque.Opacity = 0;

            //animatedRotationRate_Ellipse1.Opacity = 0;
            //animatedRotationRate_Ellipse2.Opacity = 0;

            animatedRotationRate.TranslationY = -257;
            //animatedRotationRate.Opacity = 0;

            //����߽���
            var tan1 = animatedTorque.TranslateTo(0, 0, 1000, Easing.CubicOut);
            var fan1 = animatedTorque.FadeTo(1, 1000, Easing.CubicOut);


            //���ϱ߽���
            var tan2 = animatedRotationRate.TranslateTo(0, 0, 1000, Easing.CubicOut);
            var fan2 = animatedRotationRate.FadeTo(1, 1000, Easing.CubicOut);

            //var e3 = animatedRotationRate_Ellipse1.FadeTo(1, 1000, Easing.CubicOut);
            //var e4 = animatedRotationRate_Ellipse2.FadeTo(1, 1000, Easing.CubicOut);

            await Task.WhenAll(tan1, tan2);
        });
    }
}