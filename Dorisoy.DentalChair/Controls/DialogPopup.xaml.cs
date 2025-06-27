namespace Dorisoy.DentalChair.Views;

public partial class DialogPopup : PopupPage
{
    public DialogPopup(string title)
    {
        Title = title;
        InitializeComponent();
        BindingContext = this;
        // ��������ʱ
        StartCountdown();
    }

    /// <summary>
    /// ����ʱ�رյ���
    /// </summary>
    private async void StartCountdown()
    {
        await Task.Delay(2000);
        await ClosePopup();
    }

    /// <summary>
    /// �����رմ���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void TouchBehavior_LongPressCompleted(object sender, CommunityToolkit.Maui.Core.LongPressCompletedEventArgs e)
    {
        await ClosePopup();
    }

    /// <summary>
    /// �رյ���
    /// </summary>
    /// <returns></returns>
    private async Task ClosePopup()
    {
        await PopupNavigation.Instance.PopAsync();
    }
}