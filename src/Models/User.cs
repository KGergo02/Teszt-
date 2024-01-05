using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class User
        {
            [Key]
            public int Id { get; set; }
            
            public string Name { get; set; }
            
            public string Password { get; set; }
            
            public string Email { get; set; }
            
            public bool Admin { get; set; }

            public User()
            {

            }

            public User(string name, string password, string email, bool admin)
            {
                this.Name = name;
                this.Password = password;
                this.Email = email;
                this.Admin = admin;
            }

            public User CopyUser(User user)
            {
                Id = user.Id;

                Name = user.Name;

                Password = user.Password;

                Email = user.Email;

                Admin = user.Admin;

                return this;
            }

            public override bool Equals(object obj)
            {
                User user = (User)obj;

                return this.Name == user.Name && this.Email == user.Email && this.Password == user.Password && this.Admin == user.Admin;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}