using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Teszt__.src.DAL;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;

namespace Teszt__.src.Commands
{
    class BeforeLoginCommand : CommandBase
    {
        public Thread startLoading;

        public bool admin;

        public BeforeLoginCommand(bool admin)
        {
            this.admin = admin;
        }

        public override void Execute(object parameter)
        {
            LoginWindowView window = new LoginWindowView();

            window.DataContext = new LoginWindowViewModel(window, admin);

            window.ShowDialog();
        }
    }
}
