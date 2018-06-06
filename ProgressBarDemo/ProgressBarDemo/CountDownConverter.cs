using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ProgressBarDemo
{
    public class CountDownConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double time = 0;
            double myTotalTime = ((MyLabel)parameter).TotalTime;
            double.TryParse(myTotalTime.ToString(), out var totalTime);
            double.TryParse(value.ToString(), out var progress);
            time = progress <= double.Epsilon ? totalTime : (totalTime - (totalTime * progress));
            var timeSpan = TimeSpan.FromMilliseconds(time);
            return $"{timeSpan.Minutes:00;00}:{timeSpan.Seconds:00;00}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
