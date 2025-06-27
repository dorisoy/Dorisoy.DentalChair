using Newtonsoft.Json.Linq;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// ����һ��AlarmClock�ؼ�
/// </summary>
public partial class GaugeView : ContentView
{
    private readonly GraphicsView? _graphicsView;

    private GaugeBase? GaugeDrawable => _graphicsView?.Drawable as GaugeBase;


    public static readonly BindableProperty GaugeTypeProperty =
        BindableProperty.Create(nameof(GaugeType), 
            typeof(GaugeTypes), 
            typeof(GaugeTypes),
            default(GaugeTypes), 
            propertyChanged: OnGaugeTypeChanged);

    public GaugeTypes GaugeType
    {
        get { return (GaugeTypes)GetValue(GaugeTypeProperty); }
        set { SetValue(GaugeTypeProperty, value); }
    }

    public static readonly BindableProperty GaugeMinimumProperty =
           BindableProperty.Create(nameof(GaugeMinimum),
               typeof(double),
               typeof(double), 
               default(double), 
               propertyChanged: OnGaugeMinimumChanged);

    /// <summary>
    /// ��Сֵ
    /// </summary>
    public double GaugeMinimum
    {
        get { return (double)GetValue(GaugeMinimumProperty); }
        set { SetValue(GaugeMinimumProperty, value); }
    }

    public static readonly BindableProperty GaugeMaximumProperty =
            BindableProperty.Create(nameof(GaugeMaximum),
                typeof(double), 
                typeof(double), 
                default(double), 
                propertyChanged: OnGaugeMaximumChanged);

    /// <summary>
    /// ���ֵ
    /// </summary>
    public double GaugeMaximum
    {
        get { return (double)GetValue(GaugeMaximumProperty); }
        set { SetValue(GaugeMaximumProperty, value); }
    }




    /// <summary>
    /// �����ʿ���
    /// </summary>
    public static readonly BindableProperty GaugeStrokeSizeProperty =
        BindableProperty.Create(nameof(GaugeStrokeSize), 
            typeof(float), 
            typeof(float),
            default(float), 
            propertyChanged: OnStrokeSizeChanged);
    public float GaugeStrokeSize
    {
        get { return (float)GetValue(GaugeStrokeSizeProperty); }
        set { SetValue(GaugeStrokeSizeProperty, value); }
    }


    public static readonly BindableProperty GaugeColorProperty =
        BindableProperty.Create(nameof(GaugeColor), 
            typeof(Color), 
            typeof(Color), 
            Microsoft.Maui.Graphics.Colors.Red,
            propertyChanged: OnGaugeColorChanged);
    public Color GaugeColor
    {
        get { return (Color)GetValue(GaugeColorProperty); }
        set { SetValue(GaugeColorProperty, value); }
    }



    public static readonly BindableProperty LabelColorProperty =
        BindableProperty.Create(nameof(LabelColor), 
            typeof(Color),
            typeof(Color), 
            Microsoft.Maui.Graphics.Colors.LightGrey,
            propertyChanged: OnLabelColorChanged);
    public Color LabelColor
    {
        get { return (Color)GetValue(LabelColorProperty); }
        set { SetValue(LabelColorProperty, value); }
    }


    public static readonly BindableProperty LabelSizeProperty =
    BindableProperty.Create(nameof(LabelSize),
        typeof(int), 
        typeof(int),
        default(int), 
        propertyChanged: OnLabelSizeChanged);
    public int LabelSize
    {
        get { return (int)GetValue(LabelSizeProperty); }
        set { SetValue(LabelSizeProperty, value); }
    }



    public static readonly BindableProperty GaugeBackgroundColorProperty =
       BindableProperty.Create(nameof(GaugeBackgroundColor), 
           typeof(Color), 
           typeof(Color), 
           Microsoft.Maui.Graphics.Colors.LightGrey, 
           propertyChanged: OnBackgroundColorChanged);
    public Color GaugeBackgroundColor
    {
        get { return (Color)GetValue(GaugeBackgroundColorProperty); }
        set { SetValue(GaugeBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty IsLabelShownProperty =
       BindableProperty.Create(nameof(IsLabelShown), 
           typeof(bool), 
           typeof(bool),
           true, 
           propertyChanged: OnLabelShownChanged);

    public bool IsLabelShown
    {
        get { return (bool)GetValue(IsLabelShownProperty); }
        set { SetValue(IsLabelShownProperty, value); }
    }


    /// <summary>
    /// ����ֵ
    /// </summary>
    public static readonly BindableProperty GaugeValueProperty =
        BindableProperty.Create(nameof(GaugeValue),
            typeof(double),
            typeof(double),
            default(double),
            propertyChanged: OnGaugeValueChanged);
    public double GaugeValue
    {
        get { return (double)GetValue(GaugeValueProperty); }
        set { SetValue(GaugeValueProperty, value); }
    }
    private static void OnGaugeValueChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
        {
            //gaugeView.SetGaugeDrawableValue((double)newvalue);
            gaugeView.SetAnimateValueChange((double)oldvalue, (double)newvalue);
        }
    }

    private void SetGaugeDrawableValue(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeValue = value;

        _graphicsView?.Invalidate();
    }

    /// <summary>
    /// ʹ�� Animation ����ʵ��һ���ӳ�ʼ�Ƕȵ�Ŀ��Ƕȵ�ƽ������
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private void SetAnimateValueChange(double oldValue, double newValue)
    {
        var animation = new Animation(v =>
        {
            if (GaugeDrawable != null)
                GaugeDrawable.AnimatedStart = CalculateStartAngle(v);

            // ˢ����ͼ�Ա��ػ�
            _graphicsView?.Invalidate();


        }, oldValue, newValue);

        animation.Commit(this, "GaugeAnimation", length: 500, easing: Easing.Linear);
    }

    private double CalculateStartAngle(double value)
    {
        double range = GaugeMaximum - GaugeMinimum;
        return 359.999f - (value - GaugeMinimum) / range * 359.999f;
    }


    public static readonly BindableProperty GaugeUnitProperty =
        BindableProperty.Create(nameof(GaugeValue), 
            typeof(string),
            typeof(string), 
            default(string), 
            propertyChanged: OnGaugeUnitChanged);
    public string GaugeUnit
    {
        get { return (string)GetValue(GaugeUnitProperty); }
        set { SetValue(GaugeUnitProperty, value); }
    }
    private static void OnGaugeUnitChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableUnit((string)newvalue);
    }


    public static readonly BindableProperty GaugeWidthProperty = BindableProperty.Create(nameof(GaugeWidth),
        typeof(double),
        typeof(double),
        default(double),
        propertyChanged: OnGaugeWidthChanged);
    public double GaugeWidth
    {
        get { return (double)GetValue(GaugeWidthProperty); }
        set { SetValue(GaugeWidthProperty, value); }
    }


    public static readonly BindableProperty GaugeHeightProperty = BindableProperty.Create(nameof(GaugeHeight),
    typeof(double),
    typeof(double),
    default(double),
    propertyChanged: OnGaugeHeightChanged);
    public double GaugeHeight
    {
        get { return (double)GetValue(GaugeHeightProperty); }
        set { SetValue(GaugeHeightProperty, value); }
    }



    private static void OnGaugeWidthChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableWidth((double)newvalue);
    }

    private static void OnGaugeHeightChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableHeight((double)newvalue);
    }


    public int Minutes { get; set; }
    public int Seconds { get; set; }


    /// <summary>
    /// ����ʱʱ��
    /// </summary>
    public static readonly BindableProperty GaugeCountdownProperty = BindableProperty.Create(nameof(GaugeCountdown),
        typeof(DateTime),
        typeof(DateTime),
        default(DateTime),
        propertyChanged: OnGaugeCountdownChanged);
    public DateTime GaugeCountdown
    {
        get { return (DateTime)GetValue(GaugeCountdownProperty); }
        set { SetValue(GaugeCountdownProperty, value); }
    }
    private static void OnGaugeCountdownChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        gaugeView?.SetGaugeCountdown((DateTime)newvalue);
    }
    private void SetGaugeCountdown(DateTime value)
    {
        if (GaugeDrawable != null)
        {
            GaugeDrawable.Countdown = value;
            GaugeDrawable.Minutes = value.Minute;
            GaugeDrawable.Seconds = value.Second;
        }

        _graphicsView?.Invalidate();
    }


    /// <summary>
    /// ״̬��ǩ
    /// </summary>
    public static readonly BindableProperty GaugeCountdownLabelProperty = BindableProperty.Create(nameof(GaugeCountdownLabel), 
        typeof(string), 
        typeof(string), 
        default(string), 
        propertyChanged: OnGaugeCountdownLabelChanged);
    public string GaugeCountdownLabel
    {
        get { return (string)GetValue(GaugeCountdownLabelProperty); }
        set { SetValue(GaugeCountdownLabelProperty, value); }
    }
    private static void OnGaugeCountdownLabelChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        gaugeView?.SetGaugeCountdownLabel((string)newvalue);
    }
    private void SetGaugeCountdownLabel(string value)
    {
        if (GaugeDrawable != null)
        {
            GaugeDrawable.CountdownLabel = value;
            this.gaugeCountdownLabel.Text = value;
        }

        _graphicsView?.Invalidate();
    }


    /// <summary>
    /// ʣ��ʱ�� remainingTime
    /// </summary>
    public static readonly BindableProperty GaugeRemainingTimeProperty = BindableProperty.Create(nameof(GaugeRemainingTime), 
        typeof(string),
        typeof(string),
        default(string),
        propertyChanged: OnGaugeRemainingTimeChanged);
    public string GaugeRemainingTime
    {
        get { return (string)GetValue(GaugeRemainingTimeProperty); }
        set { SetValue(GaugeRemainingTimeProperty, value); }
    }
    private static void OnGaugeRemainingTimeChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        gaugeView?.SetGaugeRemainingTime((string)newvalue);
    }
    private void SetGaugeRemainingTime(string value)
    {
        if (GaugeDrawable != null)
        {
            GaugeDrawable.RemainingTime = value;
            this.gaugeRemainingTime.Text = value;
        }

        _graphicsView?.Invalidate();
    }



    /// <summary>
    /// �Զ��嶨ʱ���ؼ�
    /// </summary>
    public GaugeView()
    {
        InitializeComponent();

        this.BindingContext = this;

        _graphicsView = this.graphicsView;

        //currentValue = 0;
        SetGaugeType(GaugeType);

        InnerInitialize();
    }


    /// <summary>
    /// ��ʼ��
    /// </summary>
    private void InnerInitialize()
    {
        //SetGaugeCountdown(GaugeCountdown);
        //SetGaugeRemainingTime(GaugeRemainingTime);
        //SetGaugeCountdownLabel(GaugeCountdownLabel);
        SetGaugeColor(GaugeColor);
        SetLabelColor(LabelColor);
        SetLabelSize(LabelSize);
        SetBackgroundColor(GaugeBackgroundColor);
        SetLabelShown(IsLabelShown);
        SetGaugeDrawableMaximum(GaugeMaximum);
        SetGaugeDrawableMinimum(GaugeMinimum);
    }

    private static void OnGaugeTypeChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
        {
            gaugeView.SetGaugeType((GaugeTypes)newvalue);
            gaugeView.InnerInitialize();
        }

    }

    private void SetGaugeType(GaugeTypes newType)
    {
        if (_graphicsView != null)
        {
            switch (newType)
            {
                case GaugeTypes.Curved:
                    _graphicsView.Drawable = new CurvedGauge();
                    break;
                case GaugeTypes.Horizontal:
                    _graphicsView.Drawable = new HorizontalGauge();
                    break;
                case GaugeTypes.HorizontalSymmetric:
                    _graphicsView.Drawable = new HorizontalSymmetricGauge();
                    break;
                default:
                    throw new NotImplementedException($"No drawable is implemented for {newType}");
            }
        }
    }

    private static void OnGaugeMinimumChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableMinimum((double)newvalue);
    }

    private void SetGaugeDrawableMinimum(double minimum)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeMinimum = minimum;

        _graphicsView?.Invalidate();
    }

    private static void OnGaugeMaximumChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeDrawableMaximum((double)newvalue);
    }

    private static void OnStrokeSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetStrokeSize((float)newvalue);
    }
    private void SetStrokeSize(float size)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeStrokeSize = size;

        _graphicsView?.Invalidate();
    }

    private void SetGaugeDrawableMaximum(double maximum)
    {
        if (GaugeDrawable != null && maximum > 0)
        {
            GaugeDrawable.GaugeMaximum = maximum;
            //GaugeDrawable.AnimatedStart = maximum;
        }

        _graphicsView?.Invalidate();
    }


    private void SetGaugeDrawableUnit(string unit)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeUnit = unit;

        _graphicsView?.Invalidate();
    }
    private void SetGaugeDrawableWidth(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.Width = value;

        if (_graphicsView != null)
        {
            _graphicsView.WidthRequest = value;
            _graphicsView.Invalidate();
        }
    }
    private void SetGaugeDrawableHeight(double value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.Height = value;

        if (_graphicsView != null)
        {
            _graphicsView.HeightRequest = value;
            _graphicsView.Invalidate();
        }
    }

    private static void OnGaugeColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetGaugeColor((Color)newvalue);
    }

    private void SetGaugeColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.GaugeColor = value;
        _graphicsView?.Invalidate();
    }

    private static void OnLabelColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetLabelColor((Color)newvalue);
    }

    private void SetLabelColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.LabelColor = value;

        _graphicsView?.Invalidate();
    }


    private static void OnLabelSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        if (gaugeView != null)
            gaugeView.SetLabelSize((int)newvalue);
    }
    private void SetLabelSize(int value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.LabelSize = value;
        _graphicsView?.Invalidate();
    }

    private static void OnBackgroundColorChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        gaugeView?.SetBackgroundColor((Color)newvalue);
    }

    private void SetBackgroundColor(Color value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.BackgroundColor = value;

        _graphicsView?.Invalidate();
    }

    private static void OnLabelShownChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var gaugeView = bindable as GaugeView;
        gaugeView?.SetLabelShown((bool)newvalue);
    }

    private void SetLabelShown(bool value)
    {
        if (GaugeDrawable != null)
            GaugeDrawable.IsLabelShown = value;
        _graphicsView?.Invalidate();
    }
}