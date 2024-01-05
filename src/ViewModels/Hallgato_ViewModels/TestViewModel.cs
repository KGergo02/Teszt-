using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.ViewModels.Hallgato_ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        private TimeSpan _remainingTime { get; set; }

        public TimeSpan RemainingTime
        {
            get { return _remainingTime; }
            set
            {
                _remainingTime = value;
                OnPropertyChanged(nameof(RemainingTime));
            }
        }

        public TestViewModel(Test test)
        {
            RemainingTime = TimeSpan.FromSeconds(10);

            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(0.8999999999);

            timer.Tick += UpdateRemainingTime;

            timer.Start();
        }

        public void UpdateRemainingTime(object sender, EventArgs e)
        {
            RemainingTime = RemainingTime.Add(TimeSpan.FromSeconds(-1));

            if(RemainingTime.Equals(TimeSpan.Zero))
            {
                ((DispatcherTimer)sender).Stop();

                Message.Success("A teszt befejeződött!");

                NavigationService.GetNavigationWindow().Closing -= WindowService.OnTestClosing;
                
                NavigationService.NavigateToHallgatoView();
            }
        }
    }
}
