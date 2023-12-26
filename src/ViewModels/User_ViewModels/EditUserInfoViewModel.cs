using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teszt__.src.Commands.User_Commands;
using Teszt__.src.Models;
using Teszt__.src.Services;
using Teszt__.src.Views.User_Views;

namespace Teszt__.src.ViewModels.User_ViewModels
{
    public class EditUserInfoViewModel : ViewModelBase
    {
        private DatabaseContext.User user;
        
        private EditUserInfoView window;

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

        public EditUserInfoViewModel(ref DatabaseContext.User user, EditUserInfoView window)
        {
            this.user = user;
            
            this.window = window;

            inputField = window.inputField;
            
            window.Closing += WindowService.OnWindowClosing;

            _username = user.Name;

            _email = user.Email;

            inputField.passwordBoxes["password1"].Password = JelszoTitkosito.Decrypt(user.Password);
            
            inputField.passwordBoxes["password2"].Password = JelszoTitkosito.Decrypt(user.Password);

            UpdateUserInfoCommand = new UpdateUserInfoCommand(ref user, inputField, window);
        }

        public void SetPasswords(SecureString password1, SecureString password2)
        {
            Password1 = password1;
            Password2 = password2;
        }

        public ICommand UpdateUserInfoCommand { get; }
    }
}
