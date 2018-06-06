using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgressBarDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();


            var model = new BindModel { TotalTime = 60000 };
            BindingContext = model;


            var updateRate = 1000 / 30f; // 30Hz
            double step = updateRate / model.TotalTime;
            Device.StartTimer(TimeSpan.FromMilliseconds(updateRate), () =>
            {
                if (progressBar.Progress < 100)
                {
                    Device.BeginInvokeOnMainThread(() => progressBar.Progress += step);
                    return true;
                }
                return false;
            });

           
        }
    }

    public class BindModel : INotifyPropertyChanged
    {
        double totalTime;
        public double TotalTime
        {
            set
            {
                totalTime = value;
                onPropertyChanged("TotalTime");
            }
            get
            {
                return totalTime;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
