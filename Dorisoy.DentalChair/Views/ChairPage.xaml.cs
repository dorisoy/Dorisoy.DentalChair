namespace Dorisoy.DentalChair.Views;

public partial class ChairPage : ContentPage
{
	public ChairPage()
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

        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.LoadDataAsync();
        }
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            await viewModel.UnregisterAsync();
        }
    }

    private void StartAnimation()
    {
        Dispatcher.Dispatch(async () =>
        {
            animatedGaugeView.TranslationX = -257;
            var translateAnimation = animatedGaugeView.TranslateTo(0, 0, 1000, Easing.CubicOut);
            var fadeInAnimation = animatedGaugeView.FadeTo(1, 1000, Easing.CubicOut);
            // ͬʱ������������
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
}