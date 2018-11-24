namespace DiffieHellman.View.Converter
{
    class BigIntegerToStringConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return string.Empty;
            return value.ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Numerics.BigInteger result;
            if (value is string && System.Numerics.BigInteger.TryParse((string)value, out result))
            {
                return result;
            }
            return null;
        }
    }
}
