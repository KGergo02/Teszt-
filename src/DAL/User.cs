using System.ComponentModel.DataAnnotations;

namespace Teszt__.src.DAL
{
    public partial class UserDatabaseContext
    {
        public class User
        {
            [Key]
            public string name { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public bool admin { get; set; }

            public User()
            {

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