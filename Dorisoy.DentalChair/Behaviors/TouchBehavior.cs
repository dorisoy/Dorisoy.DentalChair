using System.Diagnostics;

namespace Dorisoy.DentalChair.Behaviors;

public class TouchBehavior : Behavior<Border>
{
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TouchBehavior));

    protected override void OnAttachedTo(Border bindable)
    {
        base.OnAttachedTo(bindable);

        var recognizer = new PointerGestureRecognizer();
        recognizer.PointerPressed += OnPointerPressed;
        recognizer.PointerReleased += OnPointerReleased;

        bindable.GestureRecognizers.Add(recognizer);
    }

    protected override void OnDetachingFrom(Border bindable)
    {
        base.OnDetachingFrom(bindable);

        var recognizer = (PointerGestureRecognizer?)bindable.GestureRecognizers.FirstOrDefault();
        if (recognizer != null)
        {
            recognizer.PointerPressed -= OnPointerPressed;
            recognizer.PointerReleased -= OnPointerReleased;
            bindable.GestureRecognizers.Remove(recognizer);
        }
    }

    void OnPointerPressed(object? sender, PointerEventArgs e)
    {
        Debug.WriteLine("Pointer Pressed");
    }

    void OnPointerReleased(object? sender, PointerEventArgs e)
    {
        Debug.WriteLine("Pointer Released");
    }
}
