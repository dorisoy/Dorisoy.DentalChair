namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// �Զ���BorderButton
/// </summary>
public partial class BorderButton : ContentView
{
	public BorderButton()
	{
		InitializeComponent();
    }

    public event EventHandler? Clicked;

    public static readonly BindableProperty IconProperty =
       BindableProperty.Create(nameof(Icon),
           typeof(ImageSource),
           typeof(ImageSource),
           default(ImageSource),
           propertyChanged: (bindable, oldValue, newValue) => ((BorderButton)bindable).Icon = (ImageSource)newValue
       );
    public ImageSource Icon
    {
        get { return (ImageSource)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth),
            typeof(double),
            typeof(BorderButton),
            50.0,
            propertyChanged: (bindable, oldValue, newValue) => ((BorderButton)bindable).IconWidth = (double)newValue
        );
    public double IconWidth
    {
        get { return (double)GetValue(IconWidthProperty); }
        set { SetValue(IconWidthProperty, value); }
    }

    public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(nameof(IconHeight),
            typeof(double),
            typeof(BorderButton),
            50.0,
            propertyChanged: (bindable, oldValue, newValue) => ((BorderButton)bindable).IconHeight = (double)newValue
        );
    public double IconHeight
    {
        get { return (double)GetValue(IconHeightProperty); }
        set { SetValue(IconHeightProperty, value); }
    }

    public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create(nameof(BorderColor), 
              typeof(Color),
              typeof(BorderButton),
              Color.FromRgba("#FFFFFF"));
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set
        {
            SetValue(BorderColorProperty, value);
            MyBorderButton.Stroke = value;
        }
    }

    public static new readonly BindableProperty BackgroundProperty = 
        BindableProperty.Create(nameof(Background),
            typeof(Color),
            typeof(BorderButton),
            Color.FromRgba("#FFFFFF"));
    public new Color Background
    {
        get => (Color)GetValue(BorderColorProperty);
        set
        {
            SetValue(BorderColorProperty, value);
            MyBorderButton.Background = value;
        }
    }

    public static new readonly BindableProperty WidthRequestProperty =
     BindableProperty.Create(nameof(WidthRequest),
         typeof(double),
         typeof(BorderButton),
         90.0);
    public new double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set
        {
            SetValue(WidthRequestProperty, value);
            MyBorderButton.WidthRequest = value;
        }
    }

    public static new readonly BindableProperty HeightRequestProperty =
    BindableProperty.Create(nameof(HeightRequest),
     typeof(double),
     typeof(BorderButton),
     90.0);
    public new double HeightRequest
    {
        get => (double)GetValue(HeightRequestProperty);
        set
        {
            SetValue(HeightRequestProperty, value);
            MyBorderButton.HeightRequest = value;
        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == IconProperty.PropertyName)
        {
            MyBorderIcon.Source = Icon;
        }

        if (propertyName == IconWidthProperty.PropertyName)
        {
            MyBorderIcon.WidthRequest = IconWidth;
        }

        if (propertyName == IconHeightProperty.PropertyName)
        {
            MyBorderIcon.HeightRequest = IconHeight;
        }

        //OnValueChanged?.Invoke(this, (int)Value);
    }

    /// <summary>
    /// �ṩ�򵥵��ӳ٣���ģ�ⴥ���ͷ�Ч��
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //private void OnBorderTapped(object sender, TappedEventArgs e)
    //{
    //    if (sender is Border control && Application.Current != null)
    //    {
    //        control.Background = Color.FromArgb("#EEEEEE");
    //        Application.Current.Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(150), () =>
    //        {
    //            control.Background = Color.FromArgb("#FFFFFF");
    //        });
    //    }
    //}

    //TapGestureRecognizer.Tapped="OnBorderTapped"

    //private void OnBorderTapped(object sender, TappedEventArgs e)
    //{
    //    Clicked?.Invoke(this, EventArgs.Empty);
    //}

    private void TouchBehavior_LongPressCompleted(object sender, CommunityToolkit.Maui.Core.LongPressCompletedEventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}