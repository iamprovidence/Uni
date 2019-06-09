using System.Windows.Data;

namespace Library_management.View.Converters
{
    [ValueConversion(sourceType: typeof(int?), targetType: typeof(string))]
    public class IntToStingConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is int?) || !((int?)value).HasValue) return string.Empty;
            return value.ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is string) || string.IsNullOrWhiteSpace((string)value)) return null;

            int intValue;
            bool isNumeric = int.TryParse((string)value, out intValue);
            if (!isNumeric) return null;

            return intValue;
        }
    }
}
