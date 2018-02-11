using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using Ui.Properties;

namespace Ui.Views.Converters
{
    public class NullToStoreImageConverter : BaseConverter, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                return value;
            }
            else
            {
                return ImageToByte(Resources.defaultUser);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(Resources.defaultUser))
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
