namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// �Զ���MultipleBorderButton
/// </summary>
public partial class MultipleBorderButton : ContentView
{
	public MultipleBorderButton()
	{
		InitializeComponent();
    }

    public static readonly BindableProperty LeftCommandProperty =
         BindableProperty.Create(
             nameof(Command),
             typeof(ICommand),
             typeof(LongBorderButton),
             null);
    public ICommand LeftCommand
    {
        get => (ICommand)GetValue(LeftCommandProperty);
        set => SetValue(LeftCommandProperty, value);
    }

    public static readonly BindableProperty RightCommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);
    public ICommand RightCommand
    {
        get => (ICommand)GetValue(RightCommandProperty);
        set => SetValue(RightCommandProperty, value);
    }

    public static readonly BindableProperty CenterCommandProperty =
    BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(LongBorderButton),
        null);
    public ICommand CenterCommand
    {
        get => (ICommand)GetValue(CenterCommandProperty);
        set => SetValue(CenterCommandProperty, value);
    }

    public event EventHandler ClickedLeft;
    public event EventHandler ClickedCenter;
    public event EventHandler ClickedRight;

    public static readonly BindableProperty LeftIconProperty =
       BindableProperty.Create(nameof(LeftIcon),
           typeof(ImageSource),
           typeof(ImageSource),
           default(ImageSource),
           propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).LeftIcon = (ImageSource)newValue
       );
    public ImageSource LeftIcon
    {
        get { return (ImageSource)GetValue(LeftIconProperty); }
        set 
        { 
            SetValue(LeftIconProperty, value);
            MyBorderLeftIcon.Source = value;
        }
    }

    public static readonly BindableProperty RightIconProperty =
   BindableProperty.Create(nameof(RightIcon),
       typeof(ImageSource),
       typeof(ImageSource),
       default(ImageSource),
       propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).RightIcon = (ImageSource)newValue
   );
    public ImageSource RightIcon
    {
        get { return (ImageSource)GetValue(RightIconProperty); }
        set 
        { 
            SetValue(RightIconProperty, value);
            MyBorderRightIcon.Source = value;
        }
    }

    public static readonly BindableProperty CenterIconProperty =
BindableProperty.Create(nameof(CenterIcon),
   typeof(ImageSource),
   typeof(ImageSource),
   default(ImageSource),
   propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).CenterIcon = (ImageSource)newValue
);
    public ImageSource CenterIcon
    {
        get { return (ImageSource)GetValue(CenterIconProperty); }
        set 
        { 
            SetValue(CenterIconProperty, value);
            MyBorderCenterIcon.Source = value;
        }
    }


    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth),
            typeof(double),
            typeof(MultipleBorderButton),
            20.0,
            propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).IconWidth = (double)newValue
        );
    public double IconWidth
    {
        get { return (double)GetValue(IconWidthProperty); }
        set 
        { 
            SetValue(IconWidthProperty, value);
            MyBorderLeftIcon.WidthRequest = value;
            MyBorderRightIcon.WidthRequest = value;
        }
    }

    public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(nameof(IconHeight),
            typeof(double),
            typeof(MultipleBorderButton),
            32.0,
            propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).IconHeight = (double)newValue
        );
    public double IconHeight
    {
        get { return (double)GetValue(IconHeightProperty); }
        set 
        { 
            SetValue(IconHeightProperty, value);
            MyBorderLeftIcon.HeightRequest = value;
            MyBorderRightIcon.HeightRequest = value;
        }
    }



    public static readonly BindableProperty CenterIconWidthProperty =
    BindableProperty.Create(nameof(CenterIconWidth),
        typeof(double),
        typeof(MultipleBorderButton),
        50.0,
        propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).CenterIconWidth = (double)newValue
    );
    public double CenterIconWidth
    {
        get { return (double)GetValue(CenterIconWidthProperty); }
        set 
        {
            SetValue(CenterIconWidthProperty, value);
            MyBorderCenterIcon.WidthRequest = value;
        }
    }

    public static readonly BindableProperty CenterIconHeightProperty =
        BindableProperty.Create(nameof(CenterIconHeight),
            typeof(double),
            typeof(MultipleBorderButton),
            50.0,
            propertyChanged: (bindable, oldValue, newValue) => ((MultipleBorderButton)bindable).CenterIconHeight = (double)newValue
        );
    public double CenterIconHeight
    {
        get { return (double)GetValue(CenterIconHeightProperty); }
        set 
        {
            SetValue(CenterIconHeightProperty, value);
            MyBorderCenterIcon.HeightRequest = value;
        }
    }

    public static readonly BindableProperty LeftBackgroundProperty =
    BindableProperty.Create(nameof(LeftBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));
        public Color LeftBackground
        {
            get => (Color)GetValue(LeftBackgroundProperty);
            set
            {
                SetValue(LeftBackgroundProperty, value);
                MyLeftBorder.Background = value;
            }
        }


    public static readonly BindableProperty CenterBackgroundProperty =
    BindableProperty.Create(nameof(CenterBackground),
    typeof(Color),
    typeof(LongSpliterButton),
    Color.FromRgba("#FFFFFF"));
        public Color CenterBackground
        {
            get => (Color)GetValue(CenterBackgroundProperty);
            set
            {
                SetValue(CenterBackgroundProperty, value);
                MyCenterBorder.Background = value;
            }
        }


    public static readonly BindableProperty RightBackgroundProperty =
    BindableProperty.Create(nameof(RightBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));
    public Color RightBackground
    {
        get => (Color)GetValue(RightBackgroundProperty);
        set
        {
            SetValue(RightBackgroundProperty, value);
            MyRightBorder.Background = value;
        }
    }





    public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create(nameof(BorderColor), 
              typeof(Color),
              typeof(MultipleBorderButton),
              Color.FromRgba("#FFFFFF"));
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set
        {
            SetValue(BorderColorProperty, value);
            MyMultipleBorderButton.Stroke = value;
        }
    }

    public static new readonly BindableProperty BackgroundProperty = 
        BindableProperty.Create(nameof(Background),
            typeof(Color),
            typeof(MultipleBorderButton),
            Color.FromRgba("#FFFFFF"));
    public new Color Background
    {
        get => (Color)GetValue(BackgroundProperty);
        set
        {
            SetValue(BackgroundProperty, value);
            MyMultipleBorderButton.Background = value;
        }
    }



    public static new readonly BindableProperty WidthRequestProperty =
     BindableProperty.Create(nameof(WidthRequest),
         typeof(double),
         typeof(MultipleBorderButton),
         90.0);
    public new double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set
        {
            SetValue(WidthRequestProperty, value);
            MyMultipleBorderButton.WidthRequest = value;
        }
    }

    public static new readonly BindableProperty HeightRequestProperty =
    BindableProperty.Create(nameof(HeightRequest),
     typeof(double),
     typeof(MultipleBorderButton),
     90.0);
    public new double HeightRequest
    {
        get => (double)GetValue(HeightRequestProperty);
        set
        {
            SetValue(HeightRequestProperty, value);
            MyMultipleBorderButton.HeightRequest = value;
        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == LeftIconProperty.PropertyName) MyBorderLeftIcon.Source = LeftIcon;
        if (propertyName == RightIconProperty.PropertyName) MyBorderRightIcon.Source = RightIcon;
        if (propertyName == CenterIconProperty.PropertyName) MyBorderCenterIcon.Source = CenterIcon;

        if (propertyName == BorderColorProperty.PropertyName) MyMultipleBorderButton.Stroke = BorderColor;
        if (propertyName == BackgroundProperty.PropertyName) MyMultipleBorderButton.Background = Background;


        if (propertyName == CenterBackgroundProperty.PropertyName)
        {
            MyCenterBorder.Background = CenterBackground;
        }

        if (propertyName == LeftBackgroundProperty.PropertyName)
        {
            MyLeftBorder.Background = LeftBackground;
        }

        if (propertyName == RightBackgroundProperty.PropertyName)
        {
            MyRightBorder.Background = RightBackground;
        }

        if (propertyName == CenterIconWidthProperty.PropertyName)
        {
            MyBorderCenterIcon.WidthRequest = CenterIconWidth;
            MyBorderCenterIcon.HeightRequest = CenterIconHeight;
        }

        if (propertyName == IconWidthProperty.PropertyName)
        {
            MyBorderLeftIcon.WidthRequest = IconWidth;
            MyBorderRightIcon.WidthRequest = IconWidth;
        }

        if (propertyName == IconHeightProperty.PropertyName)
        {
            MyBorderLeftIcon.HeightRequest = IconHeight;
            MyBorderRightIcon.HeightRequest = IconHeight;
        }
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


    /// <summary>
    /// �Ҽ�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLeftBorderTapped(object sender, TappedEventArgs e)
    {
        ClickedLeft?.Invoke(this, EventArgs.Empty);
        if (LeftCommand?.CanExecute(null) ?? false)
        {
            LeftCommand.Execute(null);
        }
    }

    /// <summary>
    /// �м�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCenterBorderTapped(object sender, TappedEventArgs e)
    {
        ClickedCenter?.Invoke(this, EventArgs.Empty);
        if (CenterCommand?.CanExecute(null) ?? false)
        {
            CenterCommand.Execute(null);
        }
    }

    /// <summary>
    /// ���
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnRightBorderTapped(object sender, TappedEventArgs e)
    {
        ClickedRight?.Invoke(this, EventArgs.Empty);
        if (RightCommand?.CanExecute(null) ?? false)
        {
            RightCommand.Execute(null);
        }
    }
}