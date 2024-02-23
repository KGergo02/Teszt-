using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.ViewModels.Hallgato_ViewModels;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.Commands.Hallgato_Commands
{
    public class CourseCommand : CommandBase
    {
        private bool mode;

        public CourseCommand(bool mode)
        {
            this.mode = mode;
        }

        public override void Execute(object parameter)
        {
            CourseView window = new CourseView();

            window.DataContext = new CourseViewModel(mode,window);

            window.ShowDialog();
        }
    }
}
