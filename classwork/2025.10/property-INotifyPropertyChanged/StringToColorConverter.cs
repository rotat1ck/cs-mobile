using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace property_INotifyPropertyChanged {
    internal class StringToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture) {

            if (Color.TryParse(value.ToString(), out var color)) {
                return color;
            } else {
                return Colors.Black;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture) {

            return ((Color)value).ToHex();
        }
    }
}
