using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Teszt__.src.ViewModels;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Services
{
    public static class TestService
    {
        public static void TestLabelClickedEvent(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            
            Test test = (Test)label.Tag;

            MessageBoxResult result = Message.Question($"Biztos indítani szeretnéd a {test.Name} nevű tesztet?");
            
            if(result == MessageBoxResult.Yes)
            {
                CheckTimeOfTest(test);
            }
        }

        public static async void CheckTimeOfTest(Test test)
        {
            DateTime currentTime = await UserService.GetCurrentTimeAsync();

            List<string> startTestTimes = test.StartTime.Split(':').ToList();
            
            List<string> endTestTimes = test.EndTime.Split(':').ToList();

            List<string> date = test.Date.Replace(" ", "").Split('.').ToList();

            DateTime testDate = new DateTime(
                Convert.ToInt32(date[0]),
                Convert.ToInt32(date[1]),
                Convert.ToInt32(date[2])
                );

            DateTime startDateTime = new DateTime(
                testDate.Year,
                testDate.Month, 
                testDate.Day, 
                Convert.ToInt32(startTestTimes[0]), 
                Convert.ToInt32(startTestTimes[1]), 
                0
                );

            DateTime endDateTime = new DateTime(
                testDate.Year,
                testDate.Month,
                testDate.Day,
                Convert.ToInt32(endTestTimes[0]),
                Convert.ToInt32(endTestTimes[1]),
                0
                );

            if(startDateTime <= currentTime && currentTime < endDateTime)
            {
                StartTest(test);
            }
            else if(startDateTime > currentTime)
            {
                Message.Error($"A kezdési idő előtt a teszt nem indítható!\n\nIndítható:\n{test.Date.Replace(" ", "")} ({test.StartTime} - {test.EndTime})");
            }
            else if(currentTime > endDateTime)
            {
                Message.Error($"A teszt határideje lejárt!");
            }
        }

        public static void StartTest(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
