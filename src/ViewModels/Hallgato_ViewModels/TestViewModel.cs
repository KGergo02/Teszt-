using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands.Hallgato_Commands;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.ViewModels.Hallgato_ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        private TimeSpan _remainingTime { get; set; }

        public DockPanel MainDockPanel;

        private Test Test { get; set; }

        private TestView Window { get; set; }

        public TimeSpan RemainingTime
        {
            get { return _remainingTime; }
            set
            {
                _remainingTime = value;
                OnPropertyChanged(nameof(RemainingTime));
            }
        }

        public TestViewModel(Test test, TestView window)
        {
            RemainingTime = TimeSpan.FromSeconds(10);

            MainDockPanel = window.mainDockPanel;

            Test = test;

            Window = window;

            SendTestAnswersCommand = new SendTestAnswersCommand(test, window);

            QuestionService.CreateQuestionCards(test, ref MainDockPanel, window);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Interval = 1000;

            timer.Tick += UpdateRemainingTime;

            timer.Start();
        }

        public void UpdateRemainingTime(object sender, EventArgs e)
        {
            RemainingTime = RemainingTime.Add(TimeSpan.FromSeconds(-1));

            if(RemainingTime.Equals(TimeSpan.Zero))
            {
                ((System.Windows.Forms.Timer)sender).Stop();

                TestService.EndTest(Test, Window);
            }
        }

        public ICommand SendTestAnswersCommand { get; }
    }
}
