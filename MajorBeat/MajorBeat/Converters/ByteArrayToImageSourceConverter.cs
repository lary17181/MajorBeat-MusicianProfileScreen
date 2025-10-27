using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorBeat.Converters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] byteArray && byteArray.Length > 0)
            {
                
                return ImageSource.FromStream(() => new MemoryStream(byteArray));
            }

            
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Não é usado para exibição de imagem
            throw new NotImplementedException();
        }
    }
}
