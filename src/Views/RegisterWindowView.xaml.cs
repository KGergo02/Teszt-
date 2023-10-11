using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Teszt__.src.ViewModels;


namespace Teszt__.src.Views
{
    public partial class RegisterWindowView : Window
    {
        public SecureString Password1;
        
        public SecureString Password2;

        public RegisterWindowView()
        {
            InitializeComponent();

            Password1 = TB_password1.SecurePassword;

            Password2 = TB_password2.SecurePassword;
        }

        private void TB_password1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterWindowViewModel viewModel)
            {
                viewModel.SetPasswords(TB_password1.SecurePassword, TB_password2.SecurePassword);
            }
        }

        private void TB_password2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterWindowViewModel viewModel)
            {
                viewModel.SetPasswords(TB_password1.SecurePassword, TB_password2.SecurePassword);
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && DataContext is RegisterWindowViewModel viewModel)
            {
                viewModel.SetPasswords(TB_password1.SecurePassword, TB_password2.SecurePassword);

                viewModel.RegisterCommand.Execute(this);
            }
        }
    }
}
