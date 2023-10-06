using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Teszt__.src.ViewModels;
using Teszt__.src.Models;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Teszt__.src.Commands
{
    public class RegisterCommand : CommandBase
    {
        private RegisterWindowViewModel viewModel;

        public string error = "";

        public RegisterCommand(RegisterWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            error = "";

            CheckIfUserExists();

            CheckForEmptyInputs();

            CheckMatchingPassword();

            CheckEmail();

            if (error != "")
            {
                Kiiras.Hiba(error);
            }
            else
            {
                Database.Execute($"INSERT INTO `users` (`id`, `name`, `password`, `email`, `admin`) VALUES ('', '{viewModel.Username}', '{JelszoTitkosito.Encrypt(SecureStringToString(viewModel.Password1))}', '{viewModel.Email}', '0');");

                Kiiras.Siker("A regisztráció sikeres volt!");

                viewModel.RegisterWindow.Close();
            }            
        }

        private string SecureStringToString(SecureString secureString)
        {
            if(viewModel.Password1 != null && viewModel.Password2 != null)
            {
                return SecureStringConvert.ToString(secureString);
            }
            else
            {
                return "";
            }
        }

        private void CheckIfUserExists()
        {
            List<Dictionary<string, string>> users = Database.getAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i]["name"] == viewModel.Username && viewModel.Username != String.Empty)
                {
                    error += "Már létezik ilyen felhasználó!\n";

                    break;
                }
            }
        }

        private void CheckForEmptyInputs()
        {
            if (viewModel.Username == null)
            {
                error += "Nem töltötted ki a Felhasználónév mezőt!\n";
            }
            if (SecureStringToString(viewModel.Password1) == String.Empty)
            {
                error += "Nem töltötted ki a Jelszó mezőt!\n";
            }
            if (SecureStringToString(viewModel.Password2) == String.Empty)
            {
                error += "Nem töltötted ki a Jelszó újra mezőt!\n";
            }
            if (viewModel.Email == null)
            {
                error += "Nem töltötted ki az Email mezőt!\n";
            }
        }

        private void CheckMatchingPassword()
        {
            if (SecureStringToString(viewModel.Password1) != SecureStringToString(viewModel.Password2))
            {
                error += "A két jelszó nem egyezik!\n";
            }
        }

        private void CheckEmail()
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(pattern);

            if (viewModel.Email != null && regex.Matches(viewModel.Email).Count == 0)
            {
                error += "Az email hibás formátumban van, használd így: example@example.com\n";
            }
        }
    }
}
