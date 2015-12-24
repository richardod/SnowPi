using System;
using Windows.UI.Xaml.Data;

namespace SnowPi.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof (bool))
                throw new ArgumentException("Target must be a boolean", nameof(targetType));

            return !(bool) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}