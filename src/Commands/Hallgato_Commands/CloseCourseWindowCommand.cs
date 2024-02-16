using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.Commands.Hallgato_Commands
{
    public class CloseCourseWindowCommand : CommandBase
    {
        private CourseView Window;

        public CloseCourseWindowCommand(CourseView window)
        {
            this.Window = window;
        }

        public override void Execute(object parameter)
        {
            Window.Close();
        }
    }
}
