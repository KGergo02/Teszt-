using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Teszt__.src.Models;
using Teszt__.src.ViewModels.User_ViewModels;
using Teszt__.src.Views.User_Views;

namespace Teszt__.src.Commands.User_Commands
{
    class ShowUserProfileCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            UserProfileView profileView = new UserProfileView();

            profileView.DataContext = new UserProfileViewModel(profileView);
           
            profileView.ShowDialog();
        }
    }
}
