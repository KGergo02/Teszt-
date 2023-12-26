using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Teszt__.src.ViewModels;
using System.Text.RegularExpressions;
using Teszt__.src.Services;
using DatabaseContext = Teszt__.src.DAL.DatabaseContext;
using static Teszt__.src.Models.DatabaseContext;
using System.Text;

namespace Teszt__.src.Commands
{
    public class RegisterCommand : CommandBase
    {
        private RegisterWindowViewModel viewModel;

        public StringBuilder error = new StringBuilder();

        public RegisterCommand(RegisterWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.inputField.ClearColorOfInputFields();

            error.Clear();

            using (DatabaseContext database = new DatabaseContext())
            {
                UserService.CheckAllInputs(viewModel.Username, viewModel.Email, viewModel.Password1, viewModel.Password2, ref error, ref viewModel.inputField, database.Users.ToList());

                if (error.ToString() != "")
                {
                    Message.Error(error.ToString());
                }
                else
                {
                    User user = new User(viewModel.Username, JelszoTitkosito.Encrypt(SecureStringToString(viewModel.Password1)), viewModel.Email, false);

                    DatabaseContext.SaveUser(user);

                    Message.Success("A regisztráció sikeres volt!");

                    viewModel.RegisterWindow.Closing -= WindowService.OnWindowClosing;

                    viewModel.RegisterWindow.Close();
                }
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
    }
}
