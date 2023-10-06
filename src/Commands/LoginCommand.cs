using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.Models;
using Teszt__.src.Views;

namespace Teszt__.src.Commands
{
    class LoginCommand : CommandBase
    {
        public bool admin;

        LoginWindowViewModel viewModel;

        LoginWindowView LoginWindow;

        public LoginCommand(LoginWindowViewModel viewModel, LoginWindowView window ,bool admin)
        {
            this.admin = admin;

            this.viewModel = viewModel;

            LoginWindow = window;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.Username == null || viewModel.Password == null || SecureStringConvert.ToString(viewModel.Password) == null)
            {
                Kiiras.Hiba("Nem töltöttél ki minden mezőt!");

                return;
            }

            List<Dictionary<string, string>> users = Database.getAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if(users[i]["name"] == viewModel.Username && users[i]["password"] == JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
                {
                    Kiiras.Siker("Sikeres bejelentkezés!");

                    LoginWindow.Close();

                    if (admin)
                    {
                        // admin view
                    }
                    else
                    {
                        // hallgató view
                    }

                    return;
                }
            }

            Kiiras.Hiba("Hibás felhasználónév vagy jelszó!");
            
        }
    }
}
