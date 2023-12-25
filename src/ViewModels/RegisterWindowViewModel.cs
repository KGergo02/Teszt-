using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Teszt__.src.Commands;
using Teszt__.src.Models;
using Teszt__.src.Services;
using Teszt__.src.Views;

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

        public InputField inputField;

        public SecureString Password1 { get; private set; }
        public SecureString Password2 { get; private set; }

        public Window RegisterWindow;

        public ICommand RegisterCommand { get; }

        public RegisterWindowViewModel(RegisterWindowView window)
        {
            RegisterWindow = window;

            inputField = window.inputField;

            RegisterCommand = new RegisterCommand(this);

            window.Closing += WindowService.OnWindowClosing;
        }

        public void SetPasswords(SecureString password1, SecureString password2)
        {
            Password1 = password1;
            Password2 = password2;
        }
    }
}
