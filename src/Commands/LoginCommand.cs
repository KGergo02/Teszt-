using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;
using Teszt__.src.DAL;
using System.Windows.Navigation;
using Teszt__.src.Views.Hallgato_Views;
using Teszt__.src.Views.Oktato_Views;
using Teszt__.src.Services;
using Teszt__.src.Models;

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
                Message.Error("Nem töltöttél ki minden mezőt!");

                if(viewModel.Username == null)
                {
                    viewModel.inputField.ChangeColor("username");
                }

                if(viewModel.Password == null)
                {
                    viewModel.inputField.ChangeColor("password");
                }

                return;
            }

            Database database = new Database();

            User user = database.GetUserByName(viewModel.Username);

            if (user == null)
            {
                Message.Error("Nem létezik ilyen felhasználó!");

                viewModel.inputField.ChangeColor("username");

                return;
            }

            if (user.name.ToUpper() == viewModel.Username.ToUpper() && user.password == JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
            {
                if (admin)
                {
                    if (user.admin)
                    {
                        // oktató view

                        Message.Success("Sikeres bejelentkezés!");

                        LoginWindow.Close();

                        _navigationWindow.Navigate(new OktatoMainView());
                    }
                    else
                    {
                        Message.Error("Nem vagy oktató!");

                        viewModel.inputField.ChangeColor("username");
                    }
                }
                else
                {
                    // hallgató view

                    Message.Success("Sikeres bejelentkezés!");

                    LoginWindow.Close();

                    _navigationWindow.Navigate(new HallgatoMainView());
                }
            }
            else
            {
                Message.Error("Hibás felhasználónév vagy jelszó!");

                if(user.name.ToUpper() != viewModel.Username.ToUpper())
                {
                    viewModel.inputField.ChangeColor("username");
                }

                if (user.password != JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
                {
                    viewModel.inputField.ChangeColor("password");
                }
            }
        }
    }
}