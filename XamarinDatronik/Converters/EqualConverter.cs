﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinDatronik.Converters
{
    public class EqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value.Equals(parameter);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
