using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands;
using Teszt__.src.Views;

namespace Teszt__.src.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public LoginWindowViewModel(LoginWindowView window, bool admin, NavigationWindow navigationWindow)
        {
            LoginCommand = new LoginCommand(this, window, admin, navigationWindow);
        }

        public SecureString Password { get; private set; }

        public ICommand LoginCommand
        {
            get;
        }

        public void SetPassword(SecureString password)
        {
            Password = password;
        }
    }
}
