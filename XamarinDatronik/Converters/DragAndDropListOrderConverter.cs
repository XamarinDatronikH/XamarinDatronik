using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.Converters
{
    public class DragAndDropListOrderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
