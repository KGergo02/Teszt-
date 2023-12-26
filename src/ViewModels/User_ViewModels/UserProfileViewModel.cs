using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands.User_Commands;
using Teszt__.src.Models;
using Teszt__.src.Views.User_Views;

namespace Teszt__.src.ViewModels.User_ViewModels
{
    public class UserProfileViewModel : ViewModelBase
    {
        public UserProfileViewModel(DatabaseContext.User user, UserProfileView window ,NavigationWindow navigationWindow)
        {
            EditUserInfoCommand = new EditUserInfoCommand(user, window);

            DeleteUserCommand = new DeleteUserCommand(user, window, navigationWindow);
        }

        public ICommand EditUserInfoCommand { get; }
        public ICommand DeleteUserCommand { get; }
    }
}
