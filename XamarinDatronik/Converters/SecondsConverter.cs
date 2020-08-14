using System;
using System.Globalization;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.Converters
{
    public class SecondsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int seconds)
            {
                var format = (parameter != null && parameter is ElapsedTimeFormat dt) ? dt : ElapsedTimeFormat.MinSec;

                var timeSpan = TimeSpan.FromSeconds(seconds);

                switch (format)
                {
                    case ElapsedTimeFormat.MinSec:
                        return $"{timeSpan.TotalMinutes:00}:{timeSpan.Seconds:00}";

                    case ElapsedTimeFormat.HrMinSec:
                        return $"{timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";

                    case ElapsedTimeFormat.DayHrMinSec:
                        return $"{timeSpan.TotalDays:00}d {timeSpan.Hours:00}hr {timeSpan.Minutes:00}m {timeSpan.Seconds:00}s";

                    case ElapsedTimeFormat.Seconds:
                        return $"{timeSpan.Seconds:00}";

                    case ElapsedTimeFormat.Minutes:
                        return timeSpan.Minutes.ToString("00");

                    case ElapsedTimeFormat.Hours:
                        return timeSpan.Hours.ToString("00");

                    case ElapsedTimeFormat.TotalSeconds:
                        return timeSpan.TotalSeconds.ToString("00");

                    case ElapsedTimeFormat.TotalMinutes:
                        return timeSpan.TotalMinutes.ToString("00");

                    case ElapsedTimeFormat.TotalHours:
                        return timeSpan.TotalHours.ToString("00");

                    case ElapsedTimeFormat.TotalDays:
                        return timeSpan.TotalDays.ToString("00");
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
