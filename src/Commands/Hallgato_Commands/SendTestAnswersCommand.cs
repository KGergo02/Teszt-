using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Commands.Hallgato_Commands
{
    class SendTestAnswersCommand : CommandBase
    {
        private Test test;
        private TestView window;

        public SendTestAnswersCommand(Test test, TestView window)
        {
            this.test = test;
            this.window = window;
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult result = Message.Question("Biztos befejezed a teszt írását?");

            if(result == MessageBoxResult.Yes)
            {
                TestService.EndTest(test, window);
            }
        }
    }
}
