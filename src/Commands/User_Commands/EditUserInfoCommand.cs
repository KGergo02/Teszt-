using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Models;
using Teszt__.src.Views.User_Views;

namespace Teszt__.src.Commands.User_Commands
{
    public class EditUserInfoCommand : CommandBase
    {
        private DatabaseContext.User user;
        private UserProfileView window;

        public EditUserInfoCommand(DatabaseContext.User user)
        {
            this.user = user;
        }

        public EditUserInfoCommand(DatabaseContext.User user, UserProfileView window) : this(user)
        {
            this.window = window;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
