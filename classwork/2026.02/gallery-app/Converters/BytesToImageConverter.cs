using System.Globalization;

namespace gallery_app.Converters;

public class BytesToImageConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value is not null) {
            var bytes = (byte[])value;
            var stream = new MemoryStream(bytes);
            return ImageSource.FromStream(() => stream);
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
