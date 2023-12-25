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
            MessageBoxResult result = Message.Question("Biztosan ki szeretnél jelentkezni?");

            if (result.Equals(MessageBoxResult.Yes))
            {
                _navigationWindow.Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

                _navigationWindow.Source = new Uri("MainWindowView.xaml", UriKind.Relative);
            }
        }
    }
}
