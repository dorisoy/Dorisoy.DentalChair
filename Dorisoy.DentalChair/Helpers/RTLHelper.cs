using Microsoft.Maui.Controls.Shapes;

namespace Dorisoy.DentalChair.Helpers;

/// <summary>
/// 此类用于根据文本方向（从左到右或从右到左）设置边距或内边距。
/// </summary>
public static class RTLHelper
{
    #region 可绑定属性

    /// <summary>
    /// 获取或设置 MarginProperty。
    /// </summary>
    public static readonly BindableProperty MarginProperty = BindableProperty.CreateAttached(
        "Margin", typeof(Thickness), typeof(RTLHelper), ZeroThickness, propertyChanged: OnMarginPropertyChanged);

    /// <summary>
    /// 获取或设置 PaddingProperty。
    /// </summary>
    public static readonly BindableProperty PaddingProperty = BindableProperty.CreateAttached(
        "Padding", typeof(Thickness), typeof(RTLHelper), ZeroThickness, propertyChanged: OnPaddingPropertyChanged);

    /// <summary>
    /// 获取或设置 CornerRadiusProperty。
    /// </summary>
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.CreateAttached(
        "CornerRadius", typeof(Thickness), typeof(RTLHelper), ZeroThickness, propertyChanged: OnCornerRadiusPropertyChanged);

    #endregion

    #region 私有字段

    /// <summary>
    /// 用于存储零厚度的字段。
    /// </summary>
    private static readonly Thickness ZeroThickness = 0;

    #endregion

    #region 方法

    /// <summary>
    /// 获取边距的值。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <returns>返回边距</returns>
    public static Thickness GetMargin(BindableObject bindable)
    {
        return (Thickness)bindable?.GetValue(MarginProperty);
    }

    /// <summary>
    /// 获取内边距的值。
    /// </summary>
    /// <param name="bindable">布局</param>
    /// <returns>返回内边距。</returns>
    public static Thickness GetPadding(BindableObject bindable)
    {
        return (Thickness)bindable?.GetValue(PaddingProperty);
    }

    /// <summary>
    /// 获取圆角的值。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <returns>返回圆角。</returns>
    public static Thickness GetCornerRadius(BindableObject bindable)
    {
        return (Thickness)bindable?.GetValue(CornerRadiusProperty);
    }

    /// <summary>
    /// 设置边距的值。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <param name="value">边距</param>
    public static void SetMargin(BindableObject bindable, Thickness value)
    {
        if (value != ZeroThickness)
        {
            bindable?.SetValue(MarginProperty, value);
        }
        else
        {
            bindable?.ClearValue(MarginProperty);
        }
    }

    /// <summary>
    /// 设置内边距的值。
    /// </summary>
    /// <param name="bindable">布局</param>
    /// <param name="value">内边距</param>
    public static void SetPadding(BindableObject bindable, Thickness value)
    {
        if (value != ZeroThickness)
        {
            bindable?.SetValue(PaddingProperty, value);
        }
        else
        {
            bindable?.ClearValue(PaddingProperty);
        }
    }

    /// <summary>
    /// 设置圆角的值。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <param name="value">圆角</param>
    public static void SetCornerRadius(BindableObject bindable, Thickness value)
    {
        if (value != ZeroThickness)
        {
            bindable?.SetValue(CornerRadiusProperty, value);
        }
        else
        {
            bindable?.ClearValue(CornerRadiusProperty);
        }
    }

    /// <summary>
    /// 当边距属性的值发生更改时调用。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <param name="oldValue">旧值</param>
    /// <param name="newValue">新值</param>
    private static void OnMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (!(bindable is View view))
        {
            return;
        }

        var previousMargin = (Thickness)oldValue;
        var currentMargin = (Thickness)newValue;

        UpdateMargin(view);

        if (currentMargin != ZeroThickness)
        {
            if (previousMargin == ZeroThickness)
            {
                OnElementAttached(view);
            }
        }
        else
        {
            OnElementDetached(view);
        }
    }

    /// <summary>
    /// 当内边距属性的值发生更改时调用。
    /// </summary>
    /// <param name="bindable">布局</param>
    /// <param name="oldValue">旧值</param>
    /// <param name="newValue">新值</param>
    private static void OnPaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (!(bindable is Layout layout))
        {
            return;
        }

        var previousPadding = (Thickness)oldValue;
        var currentPadding = (Thickness)newValue;

        UpdatePadding(layout);

        if (currentPadding != ZeroThickness)
        {
            if (previousPadding == ZeroThickness)
            {
                OnElementAttached(layout);
            }
        }
        else
        {
            OnElementDetached(layout);
        }
    }

    /// <summary>
    /// 当圆角属性的值发生更改时调用。
    /// </summary>
    /// <param name="bindable">视图</param>
    /// <param name="oldValue">旧值</param>
    /// <param name="newValue">新值</param>
    private static void OnCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (!(bindable is View view))
        {
            return;
        }

        var previousCornerRadius = (Thickness)oldValue;
        var currentCornerRadius = (Thickness)newValue;

        UpdateCornerRadius(view);

        if (currentCornerRadius != ZeroThickness)
        {
            if (previousCornerRadius == ZeroThickness)
            {
                OnElementAttached(view);
            }
        }
        else
        {
            OnElementDetached(view);
        }
    }

    /// <summary>
    /// 当文本方向变化时更新边距值。
    /// </summary>
    /// <param name="view">视图</param>
    private static void UpdateMargin(VisualElement view)
    {
        var controller = (IVisualElementController)view;
        var margin = GetMargin(view);

        if (margin != ZeroThickness)
        {
            if (controller.EffectiveFlowDirection == EffectiveFlowDirection.RightToLeft)
            {
                margin = new Thickness(margin.Right, margin.Top, margin.Left, margin.Bottom);
            }

            view.SetValue(View.MarginProperty, margin);
        }
        else
        {
            view.ClearValue(View.MarginProperty);
        }
    }

    /// <summary>
    /// 当文本方向变化时更新内边距。
    /// </summary>
    /// <param name="layout">布局</param>
    private static void UpdatePadding(View layout)
    {
        var controller = (IVisualElementController)layout;
        var padding = GetPadding(layout);

        if (padding != ZeroThickness)
        {
            if (controller.EffectiveFlowDirection == EffectiveFlowDirection.RightToLeft)
            {
                padding = new Thickness(padding.Right, padding.Top, padding.Left, padding.Bottom);
            }

            layout.SetValue(Layout.PaddingProperty, padding);
        }
        else
        {
            layout.ClearValue(Layout.PaddingProperty);
        }
    }

    /// <summary>
    /// 当文本方向变化时更新圆角值。
    /// </summary>
    /// <param name="view">视图</param>
    private static void UpdateCornerRadius(View view)
    {
        var controller = (IVisualElementController)view;
        var cornerRadius = GetCornerRadius(view);

        if (cornerRadius != ZeroThickness)
        {
            if (controller.EffectiveFlowDirection == EffectiveFlowDirection.RightToLeft)
            {
                cornerRadius = new Thickness(cornerRadius.Top, cornerRadius.Left, cornerRadius.Bottom, cornerRadius.Right);
            }

            if (view is Frame)
            {
                //view.SetValue(Frame.CornerRadiusProperty,cornerRadius);
            }
            else if (view is RoundRectangle)
            {
                //view.SetValue(RoundRectangle.CornerRadiusProperty,cornerRadius);
            }
        }
        else
        {
            if (view is Frame)
            {
                //view.ClearValue(Frame.CornerRadiusProperty);
            }
            else if (view is RoundRectangle)
            {
                //view.ClearValue(RoundRectangle.CornerRadiusProperty);
            }
        }
    }

    /// <summary>
    /// 当文本方向变化时更新边距。
    /// </summary>
    /// <param name="sender">视图</param>
    /// <param name="e">属性更改事件参数</param>
    private static void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (sender is View view)
        {
            if (e.PropertyName == VisualElement.FlowDirectionProperty.PropertyName)
            {
                UpdateMargin(view);
                UpdatePadding(view);
                UpdateCornerRadius(view);
            }
        }
    }

    /// <summary>
    /// 当视图添加到主视图时调用。
    /// </summary>
    /// <param name="element">视图</param>
    private static void OnElementAttached(View element)
    {
        element.PropertyChanged += OnElementPropertyChanged;
    }

    /// <summary>
    /// 从视图分离时调用。
    /// </summary>
    /// <param name="element">视图</param>
    private static void OnElementDetached(View element)
    {
        element.PropertyChanged -= OnElementPropertyChanged;
    }

    #endregion
}