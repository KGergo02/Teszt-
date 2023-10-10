using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;

namespace Teszt__.src.Commands
{
    class BeforeLoginCommand : CommandBase
    {
        private NavigationWindow _navigationWindow;

        public bool admin;

        public BeforeLoginCommand(NavigationWindow window, bool admin)
        {
            _navigationWindow = window;

            this.admin = admin;
        }

        public override void Execute(object parameter)
        {
            LoginWindowView window = new LoginWindowView();

            window.DataContext = new LoginWindowViewModel(window, admin, _navigationWindow);

            window.ShowDialog();
        }
    }
}
