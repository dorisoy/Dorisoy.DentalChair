using System.Collections;
using System.Diagnostics;

namespace Dorisoy.DentalChair.Views;

public partial class DentalImplantationPage : ContentPage
{
	public DentalImplantationPage()
	{
		InitializeComponent();
        // ��ҳ����ʾ֮����������
        //this.Appearing += (s, e) => StartAnimation();
    }

    /// <summary>
    /// ��ҳ�漴������ʱ����
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        StartAnimation();
        Debug.WriteLine("CarouselView Appearing,Item Count:" + ((ICollection)carouselView.ItemsSource).Count);
        carouselView.IsVisible = false;
        carouselView.IsVisible = true;

        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    Debug.WriteLine("CarouselView Appearing,Item Count:" + ((ICollection)carouselView.ItemsSource).Count);
    //    carouselView.IsVisible = false;
    //    carouselView.IsVisible = true;
    //}

    private void StartAnimation()
    {
        Dispatcher.Dispatch(async () =>
        {
            animatedImage.TranslationX = -402;
            var translateAnimation = animatedImage.TranslateTo(0, 0, 1000, Easing.CubicOut);
            var fadeInAnimation = animatedImage.FadeTo(1, 1000, Easing.CubicOut);
            await Task.WhenAll(translateAnimation, fadeInAnimation);
        });
    }

    /// <summary>
    /// �Ҽ��¼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LongBorderButton_ClickedLeft(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// ����¼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LongBorderButton_ClickedRight(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// �м��¼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LongBorderButton_ClickedCenter(object sender, EventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}