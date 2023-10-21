namespace Teszt__.src.DAL
{
    public partial class Database
    {
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public bool admin { get; set; }

            public User()
            {

            }

            public User(int id, string name, string password, string email, bool admin)
            {
                this.id = id;
                this.name = name;
                this.password = password;
                this.email = email;
                this.admin = admin;
            }

            public User(string name, string password, string email, bool admin)
            {
                this.name = name;
                this.password = password;
                this.email = email;
                this.admin = admin;
            }
        }
    }
}