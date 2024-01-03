using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teszt__.src.Models;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Services
{
    public static class UserService
    {
        public static void CheckAllInputs(string username, string email, SecureString password1, SecureString password2, ref StringBuilder error, ref InputField inputField, List<User> users)
        {
            CheckForEmptyInputs(username, email, password1, password2, ref error, ref inputField);

            CheckIfUserExists(username, ref error, ref inputField, users);

            CheckMatchingPassword(password1, password2, ref error, ref inputField);

            CheckEmail(email, ref error, ref inputField);
        }

        public static void CheckIfUserExists(string username, ref StringBuilder error, ref InputField inputField, List<User> users)
        {
            if (username != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Name.ToUpper() == username.ToUpper() && username != String.Empty)
                    {
                        error.Append("Már létezik ilyen felhasználó!\n");

                        inputField.ChangeColor("username");

                        break;
                    }
                }
            }
            else
            {
                if (!error.ToString().Contains("Nem töltötted ki a Felhasználónév mezőt!\n"))
                {
                    error.Append("Nem töltötted ki a Felhasználónév mezőt!\n");

                    inputField.ChangeColor("username");
                }
            }
        }

        public static void CheckForEmptyInputs(string username, string email, SecureString password1, SecureString password2, ref StringBuilder error, ref InputField inputField)
        {
            if (username != null)
            {
                username = username.Trim();
            }

            if (username == null || username == String.Empty)
            {
                error.Append("Nem töltötted ki a Felhasználónév mezőt!\n");

                inputField.ChangeColor("username");
            }
            if (SecureStringToString(password1) == String.Empty)
            {
                error.Append("Nem töltötted ki a Jelszó mezőt!\n");

                inputField.ChangeColor("password1");
            }
            if (SecureStringToString(password2) == String.Empty)
            {
                error.Append("Nem töltötted ki a Jelszó újra mezőt!\n");

                inputField.ChangeColor("password2");
            }
            if (email == null || email == String.Empty)
            {
                error.Append("Nem töltötted ki az Email mezőt!\n");

                inputField.ChangeColor("email");
            }
        }

        public static void CheckMatchingPassword(SecureString password1, SecureString password2, ref StringBuilder error, ref InputField inputField)
        {
            if (SecureStringToString(password1) != SecureStringToString(password2))
            {
                error.Append("A két jelszó nem egyezik!\n");

                inputField.ChangeColor("password1");

                inputField.ChangeColor("password2");
            }
        }

        private static string SecureStringToString(SecureString secureString)
        {
            if (secureString != null)
            {
                return SecureStringConvert.ToString(secureString);
            }
            else
            {
                return "";
            }
        }

        public static void CheckEmail(string email, ref StringBuilder error, ref InputField inputField)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(pattern);

            if (email != null && regex.Matches(email).Count == 0)
            {
                error.Append("Az email hibás formátumban van, használd így: example@example.com\n");

                inputField.ChangeColor("email");
            }
        }

        public static async Task<DateTime> GetCurrentTimeAsync()
        {
            string apiUrl = "http://worldtimeapi.org/api/ip";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        DateTime currentTime = Newtonsoft.Json.JsonConvert.DeserializeObject<WorldTimeApiResponse>(responseData).Datetime;

                        return currentTime;
                    }
                    else
                    {
                        Message.Error("Hiba történt:\n" + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                Message.Error("Hiba történt:\n" + ex.Message);
            }

            return new DateTime();
        }

        public class WorldTimeApiResponse
        {
            public DateTime Datetime { get; set; }
        }
    }
}
