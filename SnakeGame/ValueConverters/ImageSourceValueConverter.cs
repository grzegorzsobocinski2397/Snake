using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ImageSourceValueConverter : BaseValueConverter<ImageSourceValueConverter>
    {
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
            throw new NotImplementedException();
        }

       
    }
}
