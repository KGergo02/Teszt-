using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Teszt__.src.Services;

namespace Teszt__.src.Commands
{
    class LogOutCommand : CommandBase
    {
        private NavigationWindow _navigationWindow;

        public LogOutCommand(NavigationWindow navigationWindow)
        {
            _navigationWindow = navigationWindow;
        }

        public override void Execute(object parameter)
        {
            _navigationWindow.Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

            Services.NavigationService.NavigateToHomePage(_navigationWindow);
        }
    }
}
