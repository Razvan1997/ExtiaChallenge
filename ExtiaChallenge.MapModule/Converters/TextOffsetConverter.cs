using System;
using System.Globalization;
using System.Windows.Data;

namespace ExtiaChallenge.MapModule.Converters
{
    public class TextOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value + 25; // Offset-ul pentru a plasa textul sub elipsă
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
