using System;
using System.Diagnostics;
using System.Globalization;

namespace SnakeGame
{
    /// <summary>
    /// Converts <see cref="ApplicationPage"/> into a page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.StartPage:
                    return new StartPage();
                case ApplicationPage.GamePage:
                    return new GamePage();
                default:
                    Debugger.Break();
                    return null;
            };

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
