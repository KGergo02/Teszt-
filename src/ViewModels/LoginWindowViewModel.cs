using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        public SecureString Password { get; private set; }

        public Window LoginWindow;

        public ICommand LoginCommand
        {
            get;
        }

        public void SetPassword(SecureString password)
        {
            Password = password;
        }

        public LoginWindowViewModel(LoginWindowView window, bool admin)
        {           
            LoginCommand = new LoginCommand(this, window, admin);
        }
    }
}
