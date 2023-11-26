using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Teszt__.src.Services;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.DAL
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("datasource=localhost;port=3306;username=root;password=;database=teszt++");
        }

        public User GetUserByName(string name)
        {
            try
            {
                return this.Users.Where(b => b.Name == name).ToList().Count == 1 ? this.Users.Where(b => b.Name == name).ToList()[0] : null;
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);

                Message.Error("Nem sikerült kapcsolódni az adatbázishoz!");

                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
    }
}