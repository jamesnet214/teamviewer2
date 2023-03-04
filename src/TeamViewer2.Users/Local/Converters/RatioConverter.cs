using System;
using System.Globalization;
using System.Windows.Data;

namespace TeamViewer2.Users.Local.Converters
{
    public class RatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            double ratio = System.Convert.ToDouble(parameter);
            double width = System.Convert.ToDouble(value);

            return width * ratio;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
