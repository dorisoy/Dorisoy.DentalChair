namespace Dorisoy.DentalChair.Views;

public partial class Scan3DPage : ContentPage
{
    public Scan3DPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ��ҳ�漴������ʱ����
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        StartAnimation();
        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    private void StartAnimation()
    {
        Dispatcher.Dispatch(async () =>
        {
            // ��ʼ����ֵ
            animatedImage.Opacity = 0;
            animatedImage.Scale = 0.5;
            var fadeInAnimation = animatedImage.FadeTo(1, 1000, Easing.CubicOut);
            // Ŀ������ֵΪ1�����ȱ����Ŵ�
            var scaleAnimation = animatedImage.ScaleTo(1, 1000, Easing.CubicOut);
            await Task.WhenAll(fadeInAnimation, scaleAnimation);
        });
    }
}