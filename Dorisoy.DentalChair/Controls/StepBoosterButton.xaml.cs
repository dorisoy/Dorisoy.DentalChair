using System.Runtime.CompilerServices;

namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// �Զ���StepBoosterButton
/// </summary>
public partial class StepBoosterButton : ContentView
{
	public StepBoosterButton()
	{
		InitializeComponent();
        InputTextBox.SetBinding(Microsoft.Maui.Controls.Label.TextProperty, new Binding(nameof(Value), BindingMode.TwoWay, source: this));
    }

    public event EventHandler<double> OnValueChanged;

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), 
        typeof(double), 
        typeof(StepBoosterButton), 
        0.0,
        propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).Value = (double)newValue,
        defaultBindingMode: BindingMode.TwoWay
    );
    public double Value
    {
        get { return (double)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }



    public static readonly BindableProperty LabelProperty =
 BindableProperty.Create(nameof(Label), 
     typeof(string), 
     typeof(StepBoosterButton),
     string.Empty,
     propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).Label = (string)newValue,
     defaultBindingMode: BindingMode.TwoWay
 );
    public string Label
    {
        get { return (string)GetValue(LabelProperty); }
        set { SetValue(LabelProperty, value); }
    }


    public static readonly BindableProperty LeftCommandProperty =
           BindableProperty.Create(
               nameof(Command),
               typeof(ICommand),
               typeof(StepBoosterButton),
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
            typeof(StepBoosterButton),
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
        typeof(StepBoosterButton),
        null);
    public ICommand CenterCommand
    {
        get => (ICommand)GetValue(CenterCommandProperty);
        set => SetValue(CenterCommandProperty, value);
    }



    public event EventHandler ClickedLeft;
    public event EventHandler ClickedRight;

    public static readonly BindableProperty LeftIconProperty =
       BindableProperty.Create(nameof(LeftIcon),
           typeof(ImageSource),
           typeof(ImageSource),
           default(ImageSource),
           propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).LeftIcon = (ImageSource)newValue
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
       propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).RightIcon = (ImageSource)newValue
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



    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth),
            typeof(double),
            typeof(StepBoosterButton),
            20.0,
            propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).IconWidth = (double)newValue
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
            typeof(StepBoosterButton),
            32.0,
            propertyChanged: (bindable, oldValue, newValue) => ((StepBoosterButton)bindable).IconHeight = (double)newValue
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
              typeof(StepBoosterButton),
              Color.FromRgba("#FFFFFF"));
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set
        {
            SetValue(BorderColorProperty, value);
            MyStepBoosterButton.Stroke = value;
        }
    }

    public static new readonly BindableProperty BackgroundProperty = 
        BindableProperty.Create(nameof(Background),
            typeof(Color),
            typeof(StepBoosterButton),
            Color.FromRgba("#FFFFFF"));
    public new Color Background
    {
        get => (Color)GetValue(BackgroundProperty);
        set
        {
            SetValue(BackgroundProperty, value);
            MyStepBoosterButton.Background = value;
        }
    }



    public static new readonly BindableProperty WidthRequestProperty =
     BindableProperty.Create(nameof(WidthRequest),
         typeof(double),
         typeof(StepBoosterButton),
         90.0);
    public new double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set
        {
            SetValue(WidthRequestProperty, value);
            MyStepBoosterButton.WidthRequest = value;
        }
    }

    public static new readonly BindableProperty HeightRequestProperty =
    BindableProperty.Create(nameof(HeightRequest),
     typeof(double),
     typeof(StepBoosterButton),
     90.0);
    public new double HeightRequest
    {
        get => (double)GetValue(HeightRequestProperty);
        set
        {
            SetValue(HeightRequestProperty, value);
            MyStepBoosterButton.HeightRequest = value;
        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == LeftIconProperty.PropertyName) MyBorderLeftIcon.Source = LeftIcon;
        if (propertyName == RightIconProperty.PropertyName) MyBorderRightIcon.Source = RightIcon;

        if (propertyName == BorderColorProperty.PropertyName) MyStepBoosterButton.Stroke = BorderColor;
        if (propertyName == BackgroundProperty.PropertyName) MyStepBoosterButton.Background = Background;

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

        if (propertyName == ValueProperty.PropertyName)
        {
            InputTextBox.Text = Value.ToString();
            OnValueChanged?.Invoke(this, (double)Value);
        }

        if (propertyName == LabelProperty.PropertyName)
        {
            InputLabel.Text = Label.ToString();
        }
    }


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