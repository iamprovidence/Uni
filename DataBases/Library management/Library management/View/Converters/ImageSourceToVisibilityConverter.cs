using System;
using System.Windows;
using System.Windows.Data;

namespace Library_management.View.Converters
{
    /// <summary>
    /// Has been used in ImageButton, to hide space in buttons without image
    /// </summary>
    [ValueConversion(sourceType: typeof(System.Windows.Media.ImageSource), targetType: typeof(Visibility))]
    class ImageSourceToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
