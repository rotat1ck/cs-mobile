using System.Globalization;

namespace practice7 {
    internal class DateOnlyConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((DateOnly)value).ToDateTime(TimeOnly.MinValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DateOnly.FromDateTime((DateTime)value);
        }
    }
}
