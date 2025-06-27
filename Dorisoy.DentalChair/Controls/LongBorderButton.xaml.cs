namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// �Զ���LongBorderButton�ؼ�
/// </summary>
public partial class LongBorderButton : ContentView
{
    public LongBorderButton()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ���ѡ�����ԣ�ָʾ����Ƿ�ѡ��
    /// </summary>
    public static readonly BindableProperty LeftSelectedProperty =
        BindableProperty.Create(
            nameof(LeftSelectedProperty),
            typeof(bool),
            typeof(LongBorderButton),
            false,
            propertyChanged: OnLeftSelectedPropertyChanged);

    /// <summary>
    /// �Ҳ�ѡ�����ԣ�ָʾ�Ҳ��Ƿ�ѡ��
    /// </summary>
    public static readonly BindableProperty RightSelectedProperty =
        BindableProperty.Create(
            nameof(RightSelectedProperty),
            typeof(bool),
            typeof(LongBorderButton),
            false,
            propertyChanged: OnRightSelectedPropertyChanged);

    /// <summary>
    /// �Ƿ�ѡ�����
    /// </summary>
    public bool LeftSelected
    {
        get => (bool)GetValue(LeftSelectedProperty);
        set => SetValue(LeftSelectedProperty, value);
    }

    /// <summary>
    /// �Ƿ�ѡ���Ҳ�
    /// </summary>
    public bool RightSelected
    {
        get => (bool)GetValue(RightSelectedProperty);
        set => SetValue(RightSelectedProperty, value);
    }

    /// <summary>
    /// ѡ�б�����ɫ
    /// </summary>
    public Color SelectedBackgroundColor { get; set; } = Color.FromArgb("#F8B544");

    /// <summary>
    /// Ĭ�ϱ�����ɫ
    /// </summary>
    public Color DefaultBackgroundColor { get; set; } = Color.FromArgb("#FFFFFF");

    /// <summary>
    /// �����������
    /// </summary>
    public static readonly BindableProperty LeftCommandProperty =
           BindableProperty.Create(
               nameof(Command),
               typeof(ICommand),
               typeof(LongBorderButton),
               null);

    /// <summary>
    /// �󶨵���ఴť����
    /// </summary>
    public ICommand LeftCommand
    {
        get => (ICommand)GetValue(LeftCommandProperty);
        set => SetValue(LeftCommandProperty, value);
    }

    /// <summary>
    /// �Ҽ���������
    /// </summary>
    public static readonly BindableProperty RightCommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// �󶨵��Ҳఴť����
    /// </summary>
    public ICommand RightCommand
    {
        get => (ICommand)GetValue(RightCommandProperty);
        set => SetValue(RightCommandProperty, value);
    }

    /// <summary>
    /// �м����������
    /// </summary>
    public static readonly BindableProperty CenterCommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// �󶨵��м䰴ť����
    /// </summary>
    public ICommand CenterCommand
    {
        get => (ICommand)GetValue(CenterCommandProperty);
        set => SetValue(CenterCommandProperty, value);
    }

    /// <summary>
    /// ���������������
    /// </summary>
    public static readonly BindableProperty LeftPressedCommandProperty =
    BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(LongBorderButton),
        null);

    /// <summary>
    /// �󶨵������������
    /// </summary>
    public ICommand LeftPressedCommand
    {
        get => (ICommand)GetValue(LeftPressedCommandProperty);
        set => SetValue(LeftPressedCommandProperty, value);
    }
 
    /// <summary>
    /// ���̧����������
    /// </summary>
    public static readonly BindableProperty LeftReleasedCommandProperty =
        BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// �󶨵����̧������
    /// </summary>
    public ICommand LeftReleasedCommand
    {
        get => (ICommand)GetValue(LeftReleasedCommandProperty);
        set => SetValue(LeftReleasedCommandProperty, value);
    }


    /// <summary>
    /// �Ҽ���������
    /// </summary>
    public static readonly BindableProperty RightPressedCommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// ���Ҽ���������
    /// </summary>
    public ICommand RightPressedCommand
    {
        get => (ICommand)GetValue(RightPressedCommandProperty);
        set => SetValue(RightPressedCommandProperty, value);
    }
    /// <summary>
    /// �Ҽ�̧������
    /// </summary>
    public static readonly BindableProperty RightReleasedCommandProperty =
        BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// ���Ҽ�̧������
    /// </summary>
    public ICommand RightReleasedCommand
    {
        get => (ICommand)GetValue(RightReleasedCommandProperty);
        set => SetValue(RightReleasedCommandProperty, value);
    }

    /// <summary>
    /// �������¼�
    /// </summary>
    public event EventHandler? ClickedLeft;
    /// <summary>
    /// �Ҽ�����¼�
    /// </summary>
    public event EventHandler? ClickedRight;

    /// <summary>
    /// ���ͼ������
    /// </summary>
    public static readonly BindableProperty LeftIconProperty =
       BindableProperty.Create(nameof(LeftIcon),
           typeof(ImageSource),
           typeof(ImageSource),
           default(ImageSource),
           propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).LeftIcon = (ImageSource)newValue
       );

    /// <summary>
    /// ��ఴť��ͼ��
    /// </summary>
    public ImageSource LeftIcon
    {
        get { return (ImageSource)GetValue(LeftIconProperty); }
        set
        {
            SetValue(LeftIconProperty, value);
            MyBorderLeftIcon.Source = value;
        }
    }

    /// <summary>
    /// �Ҽ�ͼ������
    /// </summary>
    public static readonly BindableProperty RightIconProperty =
   BindableProperty.Create(nameof(RightIcon),
       typeof(ImageSource),
       typeof(ImageSource),
       default(ImageSource),
       propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).RightIcon = (ImageSource)newValue
   );

    /// <summary>
    /// �Ҳఴť��ͼ��
    /// </summary>
    public ImageSource RightIcon
    {
        get { return (ImageSource)GetValue(RightIconProperty); }
        set
        {
            SetValue(RightIconProperty, value);
            MyBorderRightIcon.Source = value;
        }
    }

    /// <summary>
    /// �м�ͼ������
    /// </summary>
    public static readonly BindableProperty CenterIconProperty =
    BindableProperty.Create(nameof(CenterIcon),
    typeof(ImageSource),
    typeof(ImageSource),
    default(ImageSource),
    propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).CenterIcon = (ImageSource)newValue
);

    /// <summary>
    /// �м䰴ť��ͼ��
    /// </summary>
    public ImageSource CenterIcon
    {
        get { return (ImageSource)GetValue(CenterIconProperty); }
        set
        {
            SetValue(CenterIconProperty, value);
            MyBorderCenterIcon.Source = value;
        }
    }

    /// <summary>
    /// ͼ���������
    /// </summary>
    public static readonly BindableProperty IconWidthProperty =
        BindableProperty.Create(nameof(IconWidth),
            typeof(double),
            typeof(LongBorderButton),
            20.0,
            propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).IconWidth = (double)newValue
        );

    /// <summary>
    /// ͼ�����
    /// </summary>
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

    /// <summary>
    /// ͼ��߶�����
    /// </summary>
    public static readonly BindableProperty IconHeightProperty =
        BindableProperty.Create(nameof(IconHeight),
            typeof(double),
            typeof(LongBorderButton),
            32.0,
            propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).IconHeight = (double)newValue
        );

    /// <summary>
    /// ͼ��߶�
    /// </summary>
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

    /// <summary>
    /// �м�ͼ���������
    /// </summary>
    public static readonly BindableProperty CenterIconWidthProperty =
    BindableProperty.Create(nameof(CenterIconWidth),
        typeof(double),
        typeof(LongBorderButton),
        50.0,
        propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).CenterIconWidth = (double)newValue
    );

    /// <summary>
    /// �м�ͼ�����
    /// </summary>
    public double CenterIconWidth
    {
        get { return (double)GetValue(CenterIconWidthProperty); }
        set
        {
            SetValue(CenterIconWidthProperty, value);
            MyBorderCenterIcon.WidthRequest = value;
        }
    }

    /// <summary>
    /// �м�ͼ��߶�����
    /// </summary>
    public static readonly BindableProperty CenterIconHeightProperty =
        BindableProperty.Create(nameof(CenterIconHeight),
            typeof(double),
            typeof(LongBorderButton),
            50.0,
            propertyChanged: (bindable, oldValue, newValue) => ((LongBorderButton)bindable).CenterIconHeight = (double)newValue
        );

    /// <summary>
    /// �м�ͼ��߶�
    /// </summary>
    public double CenterIconHeight
    {
        get { return (double)GetValue(CenterIconHeightProperty); }
        set
        {
            SetValue(CenterIconHeightProperty, value);
            MyBorderCenterIcon.HeightRequest = value;
        }
    }

    /// <summary>
    /// ��౳��ɫ����
    /// </summary>
    public static readonly BindableProperty LeftBackgroundProperty =
    BindableProperty.Create(nameof(LeftBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// ��౳��ɫ
    /// </summary>
    public Color LeftBackground
    {
        get => (Color)GetValue(LeftBackgroundProperty);
        set
        {
            SetValue(LeftBackgroundProperty, value);
            MyLeftBorder.Background = value;
        }
    }

    /// <summary>
    /// �м䱳��ɫ����
    /// </summary>
    public static readonly BindableProperty CenterBackgroundProperty =
    BindableProperty.Create(nameof(CenterBackground),
    typeof(Color),
    typeof(LongSpliterButton),
    Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// �м䱳��ɫ
    /// </summary>
    public Color CenterBackground
    {
        get => (Color)GetValue(CenterBackgroundProperty);
        set
        {
            SetValue(CenterBackgroundProperty, value);
            MyCenterBorder.Background = value;
        }
    }

    /// <summary>
    /// �Ҳ౳��ɫ����
    /// </summary>
    public static readonly BindableProperty RightBackgroundProperty =
    BindableProperty.Create(nameof(RightBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// �Ҳ౳��ɫ
    /// </summary>
    public Color RightBackground
    {
        get => (Color)GetValue(RightBackgroundProperty);
        set
        {
            SetValue(RightBackgroundProperty, value);
            MyRightBorder.Background = value;
        }
    }

    /// <summary>
    /// �߿���ɫ����
    /// </summary>
    public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create(nameof(BorderColor),
              typeof(Color),
              typeof(LongBorderButton),
              Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// �߿���ɫ
    /// </summary>
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set
        {
            SetValue(BorderColorProperty, value);
            MyLongBorderButton.Stroke = value;
        }
    }

    /// <summary>
    /// ����ɫ����
    /// </summary>
    public static new readonly BindableProperty BackgroundProperty =
        BindableProperty.Create(nameof(Background),
            typeof(Color),
            typeof(LongBorderButton),
            Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// ������ɫ
    /// </summary>
    public new Color Background
    {
        get => (Color)GetValue(BackgroundProperty);
        set
        {
            SetValue(BackgroundProperty, value);
            MyLongBorderButton.Background = value;
        }
    }

    /// <summary>
    /// �ؼ�������������
    /// </summary>
    public static new readonly BindableProperty WidthRequestProperty =
     BindableProperty.Create(nameof(WidthRequest),
         typeof(double),
         typeof(LongBorderButton),
         90.0);

    /// <summary>
    /// �ؼ���������
    /// </summary>
    public new double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set
        {
            SetValue(WidthRequestProperty, value);
            MyLongBorderButton.WidthRequest = value;
        }
    }

    /// <summary>
    /// �ؼ��߶���������
    /// </summary>
    public static new readonly BindableProperty HeightRequestProperty =
    BindableProperty.Create(nameof(HeightRequest),
     typeof(double),
     typeof(LongBorderButton),
     90.0);

    /// <summary>
    /// �ؼ��߶�����
    /// </summary>
    public new double HeightRequest
    {
        get => (double)GetValue(HeightRequestProperty);
        set
        {
            SetValue(HeightRequestProperty, value);
            MyLongBorderButton.HeightRequest = value;
        }
    }

    /// <summary>
    /// ��Ӧ���Ա仯������UI
    /// </summary>
    /// <param name="propertyName"></param>
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == LeftIconProperty.PropertyName) MyBorderLeftIcon.Source = LeftIcon;
        if (propertyName == RightIconProperty.PropertyName) MyBorderRightIcon.Source = RightIcon;
        if (propertyName == CenterIconProperty.PropertyName) MyBorderCenterIcon.Source = CenterIcon;

        if (propertyName == BorderColorProperty.PropertyName) MyLongBorderButton.Stroke = BorderColor;
        if (propertyName == BackgroundProperty.PropertyName) MyLongBorderButton.Background = Background;

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
    /// �Ҳఴť����¼�����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLeftBorderTapped(object sender, TappedEventArgs e)
    {
        ClickedLeft?.Invoke(this, TappedEventArgs.Empty);
        if (LeftCommand?.CanExecute(null) ?? false)
        {
            LeftCommand.Execute(null);
        }
    }

    /// <summary>
    /// ��ఴť����¼�����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnRightBorderTapped(object sender, TappedEventArgs e)
    {
        ClickedRight?.Invoke(this, TappedEventArgs.Empty);
        if (RightCommand?.CanExecute(null) ?? false)
        {
            RightCommand.Execute(null);
        }
    }

    /// <summary>
    /// ������������߼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Left_TouchBehavior_CurrentTouchStatusChanged(object sender, CommunityToolkit.Maui.Core.TouchStatusChangedEventArgs e)
    {
        if (e.Status == CommunityToolkit.Maui.Core.TouchStatus.Started)
        {
            if (LeftPressedCommand?.CanExecute(null) ?? false)
            {
                LeftPressedCommand?.Execute(null);
            }
        }
        else
        {
            if (LeftReleasedCommand?.CanExecute(null) ?? false)
            {
                LeftReleasedCommand?.Execute(null);
            }
        }
    }

    /// <summary>
    /// �Ҽ����������߼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Right_TouchBehavior_CurrentTouchStatusChanged(object sender, CommunityToolkit.Maui.Core.TouchStatusChangedEventArgs e)
    {
        if (e.Status == CommunityToolkit.Maui.Core.TouchStatus.Started)
        {
            if (RightPressedCommand?.CanExecute(null) ?? false)
            {
                RightPressedCommand?.Execute(null);
            }
        }
        else
        {
            if (RightReleasedCommand?.CanExecute(null) ?? false)
            {
                RightReleasedCommand?.Execute(null);
            }
        }
    }


    /// <summary>
    /// �����ɴ�������ʱ����
    /// -------------------
    /// ����⵽һ�������Ĵ����������ʱ���á�����ζ�Ŵ��������Ѿ�����������������״̬�仯
    /// ���ڴ�����������������ɺ���߼�����������������ɡ�������ɵȣ�ͨ������ָ����Ļ̧����һ�����������γɺ�ִ��
    /// �����ڼ�����ʶ���������¼��������¼����򻬶����ƵĽ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Left_TouchBehavior_TouchGestureCompleted(object sender, CommunityToolkit.Maui.Core.TouchGestureCompletedEventArgs e)
    {
        //TODO
    }

    /// <summary>
    /// �Ҽ���ɴ�������ʱ����
    /// -------------------
    /// ����⵽һ�������Ĵ����������ʱ���á�����ζ�Ŵ��������Ѿ�����������������״̬�仯
    /// ���ڴ�����������������ɺ���߼�����������������ɡ�������ɵȣ�ͨ������ָ����Ļ̧����һ�����������γɺ�ִ��
    /// �����ڼ�����ʶ���������¼��������¼����򻬶����ƵĽ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Right_TouchBehavior_TouchGestureCompleted(object sender, CommunityToolkit.Maui.Core.TouchGestureCompletedEventArgs e)
    {
        //TODO
    }

    /// <summary>
    /// �������ѡ�еı�����ɫ
    /// </summary>
    /// <param name="bindable"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private static void OnLeftSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LongBorderButton border)
        {
            var button = border.MyLeftBorder;
            button.BackgroundColor = border.LeftSelected ? border.SelectedBackgroundColor : border.DefaultBackgroundColor;
        }
    }

    /// <summary>
    /// �����Ҳ�ѡ�еı�����ɫ
    /// </summary>
    /// <param name="bindable"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private static void OnRightSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LongBorderButton border)
        {
            var button = border.MyRightBorder;
            button.BackgroundColor = border.RightSelected ? border.SelectedBackgroundColor : border.DefaultBackgroundColor;
        }
    }

}