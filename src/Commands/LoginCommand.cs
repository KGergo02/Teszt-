using Teszt__.src.ViewModels;
using Teszt__.src.Views;
using System.Windows.Navigation;
using Teszt__.src.Views.Hallgato_Views;
using Teszt__.src.Views.Oktato_Views;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using static Teszt__.src.Models.DatabaseContext;
using DatabaseContext = Teszt__.src.DAL.DatabaseContext;

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

            User user = null;

            using (DatabaseContext database = new DatabaseContext())
            {
                user = database.GetUserByName(viewModel.Username);
            }

            if (user == null)
            {
                Message.Error("Nem létezik ilyen felhasználó!");

                viewModel.inputField.ChangeColor("username");

                return;
            }

            if (user.Name.ToUpper() == viewModel.Username.ToUpper() && user.Password == JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
            {
                if (admin)
                {
                    if (user.Admin)
                    {
                        // oktató view

                        Message.Success("Sikeres bejelentkezés!");

                        LoginWindow.Closing -= WindowService.OnWindowClosing;

                        LoginWindow.Close();

                        OktatoMainView window = new OktatoMainView();

                        window.DataContext = new OktatoMainViewModel(user, window, _navigationWindow);

                        _navigationWindow.Navigate(window);
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

                    LoginWindow.Closing -= WindowService.OnWindowClosing;

                    LoginWindow.Close();

                    _navigationWindow.Navigate(new HallgatoMainView()
                    {
                        DataContext = new HallgatoMainViewModel(user, _navigationWindow)
                    }
                    );
                }
            }
            else
            {
                Message.Error("Hibás felhasználónév vagy jelszó!");

                if(user.Name.ToUpper() != viewModel.Username.ToUpper())
                {
                    viewModel.inputField.ChangeColor("username");
                }

                if (user.Password != JelszoTitkosito.Encrypt(SecureStringConvert.ToString(viewModel.Password)))
                {
                    viewModel.inputField.ChangeColor("password");
                }
            }
        }
    }
}