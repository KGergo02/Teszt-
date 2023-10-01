using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Views;

namespace Teszt__.src.Commands
{
    class HallgatoLoginCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            LoginWindowView window = new LoginWindowView(false);

            window.ShowDialog();
        }
    }
}
