using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.Services;

namespace Teszt__.src.Commands
{
    class LogOutCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

            NavigationService.NavigateToHomePage();
        }
    }
}
