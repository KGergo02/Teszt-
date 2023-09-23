using System;
using System.Collections.Generic;
using System.Linq;
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
using Teszt__.src.classes;

namespace Teszt__.src.views
{
    
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private string error = "";

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            error = "";

            ClearErrorColors();

            CheckIfUserExists();

            CheckForEmptyInputs();

            CheckMatchingPassword();

            CheckEmail();

            if(error != "")
            {
                Kiiras.Hiba(error);
            }
            else
            {
                Database.Execute($"INSERT INTO `users` (`id`, `name`, `password`, `email`, `admin`) VALUES ('', '{TB_username.Text}', '{JelszoTitkosito.Titkosit(TB_password1.Password)}', '{TB_email.Text}', '0');");

                Kiiras.Siker("A regisztráció sikeres volt!");

                this.Close();
            }
        }

        private void CheckIfUserExists()
        {
            List<Dictionary<string, string>> users = Database.getAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i]["name"].Contains(TB_username.Text) && TB_username.Text != String.Empty)
                {
                    error += "Már létezik ilyen felhasználó!\n";

                    TB_username.Background = Brushes.Red;

                    break;
                }
            }
        }

        private void ClearErrorColors()
        {
            TB_username.Background = Brushes.White;

            TB_password1.Background = Brushes.White;

            TB_password2.Background = Brushes.White;

            TB_email.Background = Brushes.White;
        }

        private void CheckForEmptyInputs()
        {
            List<TextBox> textboxes = new List<TextBox>();
            
            List<PasswordBox> passwordboxes = new List<PasswordBox>();
            
            textboxes.Add(TB_username);
            
            textboxes.Add(TB_email);
            
            passwordboxes.Add(TB_password1);
            
            passwordboxes.Add(TB_password2);

            bool foundError = false;

            foreach(TextBox item in textboxes)
            {
                if(item.Text == String.Empty)
                {
                    item.Background = Brushes.Red;

                    foundError = true;
                }
            }

            foreach (PasswordBox item in passwordboxes)
            {
                if(item.Password == String.Empty)
                {
                    item.Background = Brushes.Red;

                    foundError = true;
                }
            }
            
            if(foundError)
            {
                error += "Nem töltöttél ki minden mezőt!\n";
            }
        }

        private void CheckMatchingPassword()
        {
            if(TB_password1.Password != TB_password2.Password)
            {
                TB_password1.Background = Brushes.Red;

                TB_password2.Background = Brushes.Red;

                error += "A két jelszó nem egyezik!\n";
            }
        }

        private void CheckEmail()
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(pattern);

            if(regex.Matches(TB_email.Text).Count == 0)
            {
                error += "Az email hibás formátumban van, használd így: example@example.com\n";

                TB_email.Background = Brushes.Red;
            }
        }
    }
}
