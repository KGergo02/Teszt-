using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.Models;
using Teszt__.src.Services;

namespace Teszt__.src.DAL
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("datasource=localhost;port=3306;username=root;password=;database=teszt++");
        }

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

        public class Course
        {
            public int id { get; set; }
            public string name { get; set; }
            public int user_limit { get; set; }
            public List<Test> tests { get; set; }

            public Course()
            {

            }

            public Course(int id, string name, int user_limit, List<Test> tests)
            {
                this.id = id;
                this.name = name;
                this.user_limit = user_limit;
                this.tests = tests;
            }
        }

        public class Test
        {
            public int id { get; set; }
            public string name { get; set; }

            //public List<Question> questions { get; set; }

            public int submit_limit { get; set; }

            public DateTime startTime { get; set; }

            public DateTime endTime { get; set; }


        }

        public User GetUserByName(string name)
        {
            try
            {
                return this.Users.Where(b => b.name == name).ToList().Count == 1 ? this.Users.Where(b => b.name == name).ToList()[0] : null;
            }
            catch(InvalidOperationException)
            {
                Message.Error("Nem sikerült kapcsolódni az adatbázishoz!");

                return null;
            }
        }
    }
}