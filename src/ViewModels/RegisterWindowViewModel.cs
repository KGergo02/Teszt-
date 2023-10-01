using System;
using System.Security;
using System.Windows.Input;
using Teszt__.src.Commands;

namespace Teszt__.src.ViewModels
{
    public class RegisterWindowViewModel : ViewModelBase
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public SecureString Password1 { get; private set; }
        public SecureString Password2 { get; private set; }

        public ICommand RegisterCommand { get; }

        public RegisterWindowViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        public void SetPasswords(SecureString password1, SecureString password2)
        {
            Password1 = password1;
            Password2 = password2;
        }
    }
}
