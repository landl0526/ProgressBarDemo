using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProgressBarDemo
{
    public class MyLabel : Label
    {
        public double TotalTime
        {
            set { SetValue(TotalTimeProperty, value); }
            get { return (double)GetValue(TotalTimeProperty); }
        }
        public static readonly BindableProperty TotalTimeProperty = BindableProperty.Create(nameof(TotalTime), typeof(double), typeof(MyLabel), default(double));
    }
}
