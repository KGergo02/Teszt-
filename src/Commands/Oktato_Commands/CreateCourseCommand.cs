using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using Teszt__.src.Models;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class CreateCourseCommand : CommandBase
    {
        private NavigationWindow _navigationWindow;

        private User _user;

        public CreateCourseCommand(User user, NavigationWindow navigationWindow)
        {
            _user = user;

            _navigationWindow = navigationWindow;
        }
        public override void Execute(object parameter)
        {         

            _navigationWindow.Navigate(new OktatoMainView()
            {
                DataContext = new OktatoMainViewModel(_user, new OktatoMainView(), _navigationWindow)
            });
        }
    }
}
