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
using Teszt__.src.classes;

namespace Teszt__.src.views
{
    
    public partial class LoginWindow : Window
    {
        public bool admin;

        public LoginWindow(bool admin)
        {
            this.admin = admin;

            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(TB_username.Text == String.Empty || TB_password.Password == String.Empty)
            {
                Kiiras.Hiba("Nem töltöttél ki minden mezőt!");

                return;
            }

            List<Dictionary<string, string>> users = Database.getAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if(users[i]["name"] != TB_username.Text || users[i]["password"] != JelszoTitkosito.Encrypt(TB_password.Password))
                {
                    Kiiras.Hiba("Hibás felhasználónév vagy jelszó!");

                    return;
                }
            }

            Kiiras.Siker("Sikeres bejelentkezés!");

            if(admin)
            {
                // admin view
            }
            else
            {
                // hallgató view
            }

            this.Close();
        }
    }
}
