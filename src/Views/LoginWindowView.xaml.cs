using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Teszt__.src.Commands;
using Teszt__.src.Models;
using Teszt__.src.ViewModels;

namespace Teszt__.src.Views
{
    
    public partial class LoginWindowView : Window
    {
        public InputField inputField;
        
        public LoginWindowView()
        {
            InitializeComponent();

            inputField = new InputField();

            inputField += new Dictionary<string, TextBox>
            {
                {"username", TB_username }
            };

            inputField += new Dictionary<string, PasswordBox>
            {
                {"password", TB_password}
            };
        }

        private void TB_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginWindowViewModel viewModel)
            {
                viewModel.SetPassword(TB_password.SecurePassword);
            }
        }


        private void SendLoginData(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && DataContext is LoginWindowViewModel viewModel)
            {
                viewModel.SetPassword(TB_password.SecurePassword);

                viewModel.LoginCommand.Execute(this);
            }
        }
    }
}
