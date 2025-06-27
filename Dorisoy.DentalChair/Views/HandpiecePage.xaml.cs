namespace Dorisoy.DentalChair.Views;

public partial class HandpiecePage : ContentPage
{
	public HandpiecePage()
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

    private void StartAnimation()
    {
        Dispatcher.Dispatch(async () =>
        {
            // �趨��ʼ�� TranslationX����ʹͼƬ�������Ļ��
            animatedImage.TranslationX = -373;

            // ����һ��ͬʱ����λ�ƶ�����͸���ȶ���������
            var translateAnimation = animatedImage.TranslateTo(0, 0, 1000, Easing.CubicOut);
            var fadeInAnimation = animatedImage.FadeTo(1, 1000, Easing.CubicOut);

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

    /// <summary>
    /// �м��¼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LongBorderButton_ClickedCenter(object sender, EventArgs e)
    {

    }
}