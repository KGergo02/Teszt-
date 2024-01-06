using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.Commands.Hallgato_Commands
{
    class CloseResultWindowCommand : CommandBase
    {
        public ResultView Window;

        public CloseResultWindowCommand(ResultView window)
        {
            Window = window;
        }

        public override void Execute(object parameter)
        {
            Window.Close();
        }
    }
}
