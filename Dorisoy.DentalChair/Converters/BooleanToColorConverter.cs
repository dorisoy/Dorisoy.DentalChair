﻿namespace Dorisoy.DentalChair.Converters;


public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isSelected)
        {
            return isSelected ? Color.FromArgb("#007BC9") : Color.FromArgb("#00000000");
        }
        return Color.FromArgb("#00000000");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class BooleanToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter == null || Application.Current == null)
        {
            return Color.FromArgb("#00000000");
        }

        switch (parameter.ToString())
        {
            case "0" when (bool)value:
                return Color.FromRgba(255, 255, 255, 0.6);
            case "1" when (bool)value:
                return Color.FromArgb("#FF4A4A");
            case "2" when (bool)value:
                return Color.FromArgb("#FF4A4A");
            case "2":
                return Color.FromArgb("#ced2d9");
            case "3" when (bool)value:
                Application.Current.Resources.TryGetValue("Gray500", out var focusVal);
                return (Color)focusVal;
            case "3":
                Application.Current.Resources.TryGetValue("Gray300", out var val);
                return (Color)val;
            case "4" when (bool)value:
                Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                return (Color)retVal;
            case "4":
                Application.Current.Resources.TryGetValue("Gray600", out var outVal);
                return (Color)outVal;
            case "5" when (bool)value:
                Application.Current.Resources.TryGetValue("Green", out var retGreen);
                return (Color)retGreen;
            case "5":
                Application.Current.Resources.TryGetValue("Red", out var retRed);
                return (Color)retRed;
            case "6" when (bool)value:
                Application.Current.Resources.TryGetValue("Gray300", out var gray300);
                return (Color)gray300;
            case "6":
                Application.Current.Resources.TryGetValue("Secondary", out var secondary);
                return (Color)secondary;
            case "7" when !(bool)value:
                Application.Current.Resources.TryGetValue("Gray100", out var gray100);
                return (Color)gray100;
            case "8" when (bool)value:
                Application.Current.Resources.TryGetValue("PrimaryColor", out var primary);
                return (Color)primary;
            case "8":
                Application.Current.Resources.TryGetValue("White", out var graywhite);
                return (Color)graywhite;
            default:
                return Color.FromArgb("#00000000");
        }
    }

    /// <summary>
    /// This method is used to convert the color to bool.
    /// </summary>
    /// <param name="value">Gets the value.</param>
    /// <param name="targetType">Gets the target type.</param>
    /// <param name="parameter">Gets the parameter.</param>
    /// <param name="culture">Gets the culture.</param>
    /// <returns>Returns the string.</returns>        
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}