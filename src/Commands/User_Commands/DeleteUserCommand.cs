using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.Views.User_Views;
using NavigationService = Teszt__.src.Services.NavigationService;

namespace Teszt__.src.Commands.User_Commands
{
    public class DeleteUserCommand : CommandBase
    {
        private Models.DatabaseContext.User user;
        
        private UserProfileView window;

        public DeleteUserCommand(ref Models.DatabaseContext.User user)
        {
            this.user = user;
        }

        public DeleteUserCommand(ref Models.DatabaseContext.User user, UserProfileView window)
        {
            this.user = user;
            this.window = window;
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult result = Message.Question("Biztosan törölni szeretnéd a fiókodat?");

            if(result == MessageBoxResult.Yes)
            {
                DatabaseContext.DeleteUser(user);
                
                Message.Success("Fiók sikeresen törölve!");

                NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

                window.Close();

                NavigationService.NavigateToHomePage();
            }
        }
    }
}
