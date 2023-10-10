using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Teszt__.src.DAL
{
    public static class Database
    {
        public static MySqlConnection Connect()
        {
            string database = "datasource=localhost;port=3306;username=root;password=;database=teszt++";

            MySqlConnection current_connection = new MySqlConnection(database);

            try
            {
                current_connection.Open();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz\n", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return current_connection;
        }

        public static List<Dictionary<string, string>> Query(string lekerdezes)
        {
            MySqlConnection connection = Connect();

            List<Dictionary<string, string>> lista = new List<Dictionary<string, string>>();

            MySqlCommand command = new MySqlCommand(lekerdezes, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dictionary<string, string> adatok = new Dictionary<string, string>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    adatok.Add(reader.GetName(i), reader.GetValue(i).ToString());
                }

                lista.Add(adatok);
            }

            connection.Close();

            return lista;
        }

        public static void Execute(string script)
        {
            MySqlConnection connection = Connect();

            MySqlCommand command = new MySqlCommand(script, connection);

            command.ExecuteNonQuery();
        }

        public static List<Dictionary<string, string>> getAllUsers()
        {
            return Query("SELECT * FROM users");
        }

        public static Dictionary<string, string> getUserByName(string name)
        {
            List<Dictionary<string, string>> user = Query($"SELECT * FROM users WHERE name = '{name}'");

            if (user.Count == 1)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }
    }
}