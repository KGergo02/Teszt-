using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;

namespace Teszt__.src.Commands
{
    class RegisterLabelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            RegisterWindowView window = new RegisterWindowView();

            window.DataContext = new RegisterWindowViewModel(window);

            window.ShowDialog();
        }
    }
}
