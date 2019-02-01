using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace SnakeGame
{
    /// <summary>
    /// Converts boolean value to visibility
    /// </summary>
    public class BooleanToVisibiltyConverter : BaseValueConverter<BooleanToVisibiltyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
                return Visibility.Hidden;
            else if ((bool)value == true)
                return Visibility.Visible;
            else
            {
                Debugger.Break();
                return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
