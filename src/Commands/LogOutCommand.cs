using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

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
            _navigationWindow.Source = new Uri("MainWindowView.xaml", UriKind.Relative);
        }
    }
}
