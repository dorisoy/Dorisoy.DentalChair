using CommunityToolkit.Maui.Core;
using System;

namespace Dorisoy.DentalChair.Converters
{
    public class IsDarkModeToStatusBarStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isDarkMode = value != null ? (bool)value : false;

            if (isDarkMode)
                return StatusBarStyle.LightContent;
            else 
                return StatusBarStyle.DarkContent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException ();
        }
    }
}
