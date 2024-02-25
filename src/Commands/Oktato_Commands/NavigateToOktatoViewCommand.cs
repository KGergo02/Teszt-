using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Services;

namespace Teszt__.src.Commands.Oktato_Commands
{
    public class NavigateToOktatoViewCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

            NavigationService.NavigateToOktatoView();
        }
    }
}
