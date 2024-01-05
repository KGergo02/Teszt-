using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Models;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.User_ViewModels;
using Teszt__.src.Views.User_Views;

namespace Teszt__.src.Commands.User_Commands
{
    public class EditUserInfoCommand : CommandBase
    {
        private UserProfileView window;


        public EditUserInfoCommand(UserProfileView window)
        {
            this.window = window;
        }

        public override void Execute(object parameter)
        {
            EditUserInfoView window = new EditUserInfoView();

            window.DataContext = new EditUserInfoViewModel(window);

            this.window.Close();

            window.ShowDialog();
        }
    }
}
