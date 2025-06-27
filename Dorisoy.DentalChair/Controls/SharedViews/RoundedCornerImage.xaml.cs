namespace Dorisoy.DentalChair.Controls;
public partial class RoundedCornerImage : Border
{

    public RoundedCornerImage()
    {
        InitializeComponent();
    }

    public static BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(ImageSource),
                typeof(RoundedCornerImage),
                defaultValue: null
            );

    public ImageSource Source
    {
        get { return (ImageSource)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }

    public static BindableProperty CornerRadiusProperty =
       BindableProperty.Create(
           nameof(CornerRadius),
           typeof(Double),
           typeof(RoundedCornerImage),
           defaultValue: 10.0
       );

    public Double CornerRadius
    {
        get { return (Double)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }
}