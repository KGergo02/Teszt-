using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.Models;
using Teszt__.src.Views;
using Teszt__.src.DAL;
using System.Windows.Navigation;
using Teszt__.src.Views.Hallgato_Views;
using Teszt__.src.Views.Oktato_Views;

namespace Teszt__.src.Commands
{
    public class LoginCommand : CommandBase
    {
        public bool admin;

        private LoginWindowViewModel viewModel;

        private LoginWindowView LoginWindow;

        private NavigationWindow _navigationWindow;

        public LoginCommand(LoginWindowViewModel viewModel, LoginWindowView window, bool admin, NavigationWindow navWindow)
        {
            this.admin = admin;

            this.viewModel = viewModel;

            LoginWindow = window;

            this._navigationWindow = navWindow;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.Username == null || viewModel.Password == null || SecureStringConvert.ToString(viewModel.Password) == null)
            {
                Kiiras.Hiba("Nem töltöttél ki minden mezőt!");

                return;
            }

            Dictionary<string, string> user = Database.getUserByName(viewModel.Username);

            if (user == null)
            {
                Kiiras.Hiba("Hibás felhasználónév vagy jelszó!");

                return;
            }

            if (user["name"] == viewModel.Username && user["password"] == JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
            {
                if (admin)
                {
                    if (Convert.ToBoolean(user["admin"]) == true)
                    {
                        // oktató view

                        Kiiras.Siker("Sikeres bejelentkezés!");

                        LoginWindow.Close();

                        _navigationWindow.Navigate(new OktatoMainView());

                        _navigationWindow.RemoveBackEntry();
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

                    _navigationWindow.Navigate(new HallgatoMainView());

                    _navigationWindow.RemoveBackEntry();
                }
            }
            else
            {
                Kiiras.Hiba("Hibás felhasználónév vagy jelszó!");
            }
        }
    }
}