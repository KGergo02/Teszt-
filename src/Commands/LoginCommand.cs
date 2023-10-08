using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.Models;
using Teszt__.src.Views;
using Teszt__.src.Services;

namespace Teszt__.src.Commands
{
    class LoginCommand : CommandBase
    {
        public bool admin;

        LoginWindowViewModel viewModel;

        LoginWindowView LoginWindow;

        private readonly Navigation _navigation;

        private readonly NavigationService _navigationService;

        public LoginCommand(LoginWindowViewModel viewModel, LoginWindowView window, bool admin,
            Navigation navigation, NavigationService navigationService)
        {
            this.admin = admin;

            this.viewModel = viewModel;

            LoginWindow = window;
            
            _navigation = navigation;
            
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.Username == null || viewModel.Password == null || SecureStringConvert.ToString(viewModel.Password) == null)
            {
                Kiiras.Hiba("Nem töltöttél ki minden mezőt!");

                return;
            }

            Dictionary<string, string> user = Database.getUserByName(viewModel.Username);

            if(user["name"] == viewModel.Username && user["password"] == JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
            {
                if (admin)
                {
                    if(Convert.ToBoolean(user["admin"]) == true)
                    {
                        // oktató view

                        Kiiras.Siker("Sikeres bejelentkezés!");

                        LoginWindow.Close();
                    }
                    else
                    {
                        Kiiras.Hiba("Nem vagy oktató!");
                    }
                }
                else
                {
                    // hallgató view

                    Kiiras.Siker("Sikeres bejelentkezés!");

                    LoginWindow.Close();
                }
            }
            else
            {
                Kiiras.Hiba("Hibás felhasználónév vagy jelszó!");
            }
        }
    }
}
