using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties {
    internal class StringToStyleConverter : IValueConverter {
        public Style ApprovedStatus { get; set; }
        public Style DeniedStatus { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string username = (string)value;
            if (username == "admin") return ApprovedStatus;
            return DeniedStatus;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            var status = value as Style;

            if (status != ApprovedStatus) {
                return "admin";
            }

            return "user";
        }
    }
}
