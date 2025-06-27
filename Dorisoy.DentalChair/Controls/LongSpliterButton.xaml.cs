namespace Dorisoy.DentalChair.Controls;

/// <summary>
/// �Զ���� LongSpliterButton �ؼ�
/// </summary>
public partial class LongSpliterButton : ContentView
{
    public LongSpliterButton()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ��ʾ��ఴť�Ƿ�ѡ�е�����
    /// </summary>
    public static readonly BindableProperty LeftSelectedProperty =
        BindableProperty.Create(
            nameof(LeftSelectedProperty),
            typeof(bool),
            typeof(LongBorderButton),
            false,
            propertyChanged: OnLeftSelectedPropertyChanged);

    /// <summary>
    /// ��ʾ�Ҳఴť�Ƿ�ѡ�е�����
    /// </summary>
    public static readonly BindableProperty RightSelectedProperty =
        BindableProperty.Create(
            nameof(RightSelectedProperty),
            typeof(bool),
            typeof(LongBorderButton),
            false,
            propertyChanged: OnRightSelectedPropertyChanged);

    /// <summary>
    /// ��ఴť�Ƿ�ѡ��
    /// </summary>
    public bool LeftSelected
    {
        get => (bool)GetValue(LeftSelectedProperty);
        set => SetValue(LeftSelectedProperty, value);
    }

    /// <summary>
    /// �Ҳఴť�Ƿ�ѡ��
    /// </summary>
    public bool RightSelected
    {
        get => (bool)GetValue(RightSelectedProperty);
        set => SetValue(RightSelectedProperty, value);
    }

    /// <summary>
    /// ѡ��ʱ�ı�����ɫ
    /// </summary>
    public Color SelectedBackgroundColor { get; set; } = Color.FromArgb("#F8B544");

    /// <summary>
    /// Ĭ�ϱ�����ɫ
    /// </summary>
    public Color DefaultBackgroundColor { get; set; } = Color.FromArgb("#FFFFFF");

    /// <summary>
    /// ��ఴť����������
    /// </summary>
    public static readonly BindableProperty LeftCommandProperty =
         BindableProperty.Create(
             nameof(Command),
             typeof(ICommand),
             typeof(LongBorderButton),
             null);

    /// <summary>
    /// ��ఴť�󶨵�����
    /// </summary>
    public ICommand LeftCommand
    {
        get => (ICommand)GetValue(LeftCommandProperty);
        set => SetValue(LeftCommandProperty, value);
    }

    /// <summary>
    /// �Ҳఴť����������
    /// </summary>
    public static readonly BindableProperty RightCommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(LongBorderButton),
            null);

    /// <summary>
    /// �Ҳఴť�󶨵�����
    /// </summary>
    public ICommand RightCommand
    {
        get => (ICommand)GetValue(RightCommandProperty);
        set => SetValue(RightCommandProperty, value);
    }

    /// <summary>
    /// �м䰴ť����������
    /// </summary>
    public static readonly BindableProperty CenterCommandProperty =
    BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(LongBorderButton),
        null);

    /// <summary>
    /// �м䰴ť�󶨵�����
    /// </summary>
    public ICommand CenterCommand
    {
        get => (ICommand)GetValue(CenterCommandProperty);
        set => SetValue(CenterCommandProperty, value);
    }

    /// <summary>
    /// ��ఴť����¼�
    /// </summary>
    public event EventHandler ClickedLeft;

    /// <summary>
    /// �Ҳఴť����¼�
    /// </summary>
    public event EventHandler ClickedRight;

    /// <summary>
    /// ���ͼ�������
    /// </summary>
    public static readonly BindableProperty LeftIconProperty =
       BindableProperty.Create(nameof(LeftIcon),
           typeof(ImageSource),
           typeof(ImageSource),
           default(ImageSource),
           propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).LeftIcon = (ImageSource)newValue
       );

    /// <summary>
    /// ���ͼ��
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
    /// �Ҳ�ͼ�������
    /// </summary>
    public static readonly BindableProperty RightIconProperty =
   BindableProperty.Create(nameof(RightIcon),
       typeof(ImageSource),
       typeof(ImageSource),
       default(ImageSource),
       propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).RightIcon = (ImageSource)newValue
   );

    /// <summary>
    /// �Ҳ�ͼ��
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
    /// ���ͼ����Ȱ�����
    /// </summary>
    public static readonly BindableProperty LeftIconWidthProperty =
        BindableProperty.Create(nameof(LeftIconWidth),
            typeof(double),
            typeof(LongSpliterButton),
            20.0,
            propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).LeftIconWidth = (double)newValue
        );

    /// <summary>
    /// ���ͼ�����
    /// </summary>
    public double LeftIconWidth
    {
        get { return (double)GetValue(LeftIconWidthProperty); }
        set
        {
            SetValue(LeftIconWidthProperty, value);
            MyBorderLeftIcon.WidthRequest = value;
        }
    }

    /// <summary>
    /// �Ҳ�ͼ����Ȱ�����
    /// </summary>
    public static readonly BindableProperty RightIconWidthProperty =
     BindableProperty.Create(nameof(RightIconWidth),
         typeof(double),
         typeof(LongSpliterButton),
         20.0,
         propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).RightIconWidth = (double)newValue
     );

    /// <summary>
    /// �Ҳ�ͼ�����
    /// </summary>
    public double RightIconWidth
    {
        get { return (double)GetValue(RightIconWidthProperty); }
        set
        {
            SetValue(RightIconWidthProperty, value);
            MyBorderRightIcon.WidthRequest = value;
        }
    }

    /// <summary>
    /// ���ͼ��߶Ȱ�����
    /// </summary>
    public static readonly BindableProperty LeftIconHeightProperty =
        BindableProperty.Create(nameof(LeftIconHeight),
            typeof(double),
            typeof(LongSpliterButton),
            32.0,
            propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).LeftIconHeight = (double)newValue
        );

    /// <summary>
    /// ���ͼ��߶�
    /// </summary>
    public double LeftIconHeight
    {
        get { return (double)GetValue(LeftIconHeightProperty); }
        set
        {
            SetValue(LeftIconHeightProperty, value);
            MyBorderLeftIcon.HeightRequest = value;
        }
    }

    /// <summary>
    /// �Ҳ�ͼ��߶Ȱ�����
    /// </summary>
    public static readonly BindableProperty RightIconHeightProperty =
    BindableProperty.Create(nameof(RightIconHeight),
        typeof(double),
        typeof(LongSpliterButton),
        32.0,
        propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).RightIconHeight = (double)newValue
    );

    /// <summary>
    /// �Ҳ�ͼ��߶�
    /// </summary>
    public double RightIconHeight
    {
        get { return (double)GetValue(RightIconHeightProperty); }
        set
        {
            SetValue(RightIconHeightProperty, value);
            MyBorderRightIcon.HeightRequest = value;
        }
    }

    /// <summary>
    /// �߿���ɫ������
    /// </summary>
    public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create(nameof(BorderColor),
              typeof(Color),
              typeof(LongSpliterButton),
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
            MyLongSpliterButton.Stroke = value;
        }
    }

    /// <summary>
    /// ������ɫ������
    /// </summary>
    public static new readonly BindableProperty BackgroundProperty =
        BindableProperty.Create(nameof(Background),
            typeof(Color),
            typeof(LongSpliterButton),
            Color.FromRgba("#00FFFFFF"));

    /// <summary>
    /// ������ɫ
    /// </summary>
    public new Color Background
    {
        get => (Color)GetValue(BackgroundProperty);
        set
        {
            SetValue(BackgroundProperty, value);
            MyLongSpliterButton.Background = value;
        }
    }

    /// <summary>
    /// �м䱳����ɫ������
    /// </summary>
    public static readonly BindableProperty CenterBackgroundProperty =
    BindableProperty.Create(nameof(CenterBackground),
    typeof(Color),
    typeof(LongSpliterButton),
    Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// �м䲿�ֱ�����ɫ
    /// </summary>
    public Color CenterBackground
    {
        get => (Color)GetValue(CenterBackgroundProperty);
        set
        {
            SetValue(CenterBackgroundProperty, value);
            //MyCenterBorder.Background = value;
        }
    }

    /// <summary>
    /// ��౳����ɫ������
    /// </summary>
    public static readonly BindableProperty LeftBackgroundProperty =
    BindableProperty.Create(nameof(LeftBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// ��౳����ɫ
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
    /// �Ҳ౳����ɫ������
    /// </summary>
    public static readonly BindableProperty RightBackgroundProperty =
    BindableProperty.Create(nameof(RightBackground),
        typeof(Color),
        typeof(LongSpliterButton),
        Color.FromRgba("#FFFFFF"));

    /// <summary>
    /// �Ҳ౳����ɫ
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
    /// �ؼ����Ȱ�����
    /// </summary>
    public static new readonly BindableProperty WidthRequestProperty =
     BindableProperty.Create(nameof(WidthRequest),
         typeof(double),
         typeof(LongSpliterButton),
         90.0);

    /// <summary>
    /// �ؼ�����
    /// </summary>
    public new double WidthRequest
    {
        get => (double)GetValue(WidthRequestProperty);
        set
        {
            SetValue(WidthRequestProperty, value);
            MyLongSpliterButton.WidthRequest = value;
        }
    }

    /// <summary>
    /// �ؼ��߶Ȱ�����
    /// </summary>
    public static new readonly BindableProperty HeightRequestProperty =
    BindableProperty.Create(nameof(HeightRequest),
     typeof(double),
     typeof(LongSpliterButton),
     90.0);

    /// <summary>
    /// �ؼ��߶�
    /// </summary>
    public new double HeightRequest
    {
        get => (double)GetValue(HeightRequestProperty);
        set
        {
            SetValue(HeightRequestProperty, value);
            MyLongSpliterButton.HeightRequest = value;
        }
    }

    /// <summary>
    /// �ָ�����ʾ״̬������
    /// </summary>
    public static readonly BindableProperty ShowSpliterProperty = BindableProperty.Create(nameof(ShowSpliter),
           typeof(bool),
           typeof(LongSpliterButton),
           true,
           propertyChanged: (bindable, oldValue, newValue) => ((LongSpliterButton)bindable).ShowSpliter = (bool)newValue,
           defaultBindingMode: BindingMode.TwoWay
       );

    /// <summary>
    /// �Ƿ���ʾ�ָ���
    /// </summary>
    public bool ShowSpliter
    {
        get { return (bool)GetValue(ShowSpliterProperty); }
        set { SetValue(ShowSpliterProperty, value); }
    }

    /// <summary>
    /// ����������������
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
    /// ���̧�����������
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
    /// �Ҽ��������������
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
    /// �Ҽ�̧�����������
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

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == LeftIconProperty.PropertyName)
            MyBorderLeftIcon.Source = LeftIcon;

        if (propertyName == RightIconProperty.PropertyName)
            MyBorderRightIcon.Source = RightIcon;

        if (propertyName == BorderColorProperty.PropertyName)
            MyLongSpliterButton.Stroke = BorderColor;

        if (propertyName == BackgroundProperty.PropertyName)
        {
            MyLongSpliterButton.Background = Background;
        }

        if (propertyName == ShowSpliterProperty.PropertyName)
        {
            MyCenterBorder.IsVisible = ShowSpliter;
        }

        if (propertyName == LeftBackgroundProperty.PropertyName)
        {
            MyLeftBorder.Background = LeftBackground;
        }

        if (propertyName == RightBackgroundProperty.PropertyName)
        {
            MyRightBorder.Background = RightBackground;
        }

        if (propertyName == LeftIconWidthProperty.PropertyName)
        {
            MyBorderLeftIcon.WidthRequest = LeftIconWidth;
        }
        if (propertyName == RightIconWidthProperty.PropertyName)
        {
            MyBorderRightIcon.WidthRequest = RightIconWidth;
        }

        if (propertyName == LeftIconHeightProperty.PropertyName)
        {
            MyBorderLeftIcon.HeightRequest = LeftIconHeight;
        }
        if (propertyName == RightIconHeightProperty.PropertyName)
        {
            MyBorderRightIcon.HeightRequest = RightIconHeight;
        }
    }

    /// <summary>
    /// ��ఴť�����仯����
    /// </summary>
    /// <param name="sender">�����¼��Ķ���</param>
    /// <param name="e">�¼�����</param>
    private void Left_TouchBehavior_CurrentTouchStatusChanged(object sender, CommunityToolkit.Maui.Core.TouchStatusChangedEventArgs e)
    {


        switch (e.Status)
        {
            case CommunityToolkit.Maui.Core.TouchStatus.Started:
                // ������ʼʱ�Ĵ����߼�
                if (LeftPressedCommand?.CanExecute(null) ?? false)
                {
                    LeftPressedCommand?.Execute(null);
                }
                break;
            default:
                // ��������ʱ�Ĵ����߼�
                if (LeftReleasedCommand?.CanExecute(null) ?? false)
                {
                    LeftReleasedCommand?.Execute(null);
                }
                break;
        }
    }

    /// <summary>
    /// �Ҳఴť�����仯����
    /// </summary>
    /// <param name="sender">�����¼��Ķ���</param>
    /// <param name="e">�¼�����</param>
    private void Right_TouchBehavior_CurrentTouchStatusChanged(object sender, CommunityToolkit.Maui.Core.TouchStatusChangedEventArgs e)
    {
        switch (e.Status)
        {
            case CommunityToolkit.Maui.Core.TouchStatus.Started:
                // ������ʼʱ�Ĵ����߼�
                if (RightPressedCommand?.CanExecute(null) ?? false)
                {
                    RightPressedCommand?.Execute(null);
                }
                break;
            default:
                // ��������ʱ�Ĵ����߼�
                if (RightReleasedCommand?.CanExecute(null) ?? false)
                {
                    RightReleasedCommand?.Execute(null);
                }
                break;
        }
    }

    /// <summary>
    /// �����ѡ�����Ա仯ʱ���±�����ɫ
    /// </summary>
    /// <param name="bindable">�󶨵Ķ���</param>
    /// <param name="oldValue">��ֵ</param>
    /// <param name="newValue">��ֵ</param>
    private static void OnLeftSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LongSpliterButton border)
        {
            var button = border.MyLeftBorder;
            button.BackgroundColor = border.LeftSelected ? border.SelectedBackgroundColor : border.DefaultBackgroundColor;
        }
    }

    /// <summary>
    /// ���Ҳ�ѡ�����Ա仯ʱ���±�����ɫ
    /// </summary>
    /// <param name="bindable">�󶨵Ķ���</param>
    /// <param name="oldValue">��ֵ</param>
    /// <param name="newValue">��ֵ</param>
    private static void OnRightSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LongSpliterButton border)
        {
            var button = border.MyRightBorder;
            button.BackgroundColor = border.RightSelected ? border.SelectedBackgroundColor : border.DefaultBackgroundColor;
        }
    }

    private void OnLeftBorderTapped(object sender, TappedEventArgs e)
    {
        if (LeftCommand?.CanExecute(null) ?? false)
        {
            LeftCommand.Execute(null);
        }
    }

    private void OnRightBorderTapped(object sender, TappedEventArgs e)
    {
        if (RightCommand?.CanExecute(null) ?? false)
        {
            RightCommand.Execute(null);
        }
    }
}