using System;
using Microsoft.Maui.Controls;

namespace Dorisoy.DentalChair.Views;

public partial class LockPopup : PopupPage
{
    public LockPopup()
    {
        InitializeComponent();
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await PopupNavigation.Instance.PopAsync();
    }

    /// <summary>
    /// �����رմ���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void TouchBehavior_LongPressCompleted(object sender, CommunityToolkit.Maui.Core.LongPressCompletedEventArgs e)
    {
        await PopupNavigation.Instance.PopAsync();
    }

    /// <summary>
    /// �رմ���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void TouchBehavior_TouchGestureCompleted(object sender, CommunityToolkit.Maui.Core.TouchGestureCompletedEventArgs e)
    {
        await PopupNavigation.Instance.PopAsync();
    }
}