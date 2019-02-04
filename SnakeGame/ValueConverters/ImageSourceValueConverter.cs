using System;
using System.Globalization;

namespace SnakeGame
{
    public class ImageSourceValueConverter : BaseValueConverter<ImageSourceValueConverter>
    {
        /// <summary>
        /// Converts <see cref="SnakeMovement"/> to a image source string
        /// </summary>
        /// <param name="value">Current SnakeMovement</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">String informing of which button was pressed</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var button = (string)parameter;
            var movement = (SnakeMovement)value;

            if (movement == SnakeMovement.Up && button == "Up")
                return "/Resources/Images/ButtonPressed.png";
            else if (movement== SnakeMovement.Down && button == "Down")
                return "/Resources/Images/ButtonPressed.png";
            else if (movement == SnakeMovement.Left && button == "Left")
                return "/Resources/Images/ButtonPressed.png";
            else if (movement == SnakeMovement.Right && button == "Right")
                return "/Resources/Images/ButtonPressed.png";
            else
                return  "/Resources/Images/Button.png";
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

       
    }
}
