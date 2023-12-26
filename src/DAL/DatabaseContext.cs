using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
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

        public DbSet<Answer> Answers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("datasource=localhost;port=3306;username=root;password=;database=teszt++");
        }

        public object FindById(int id, Type type)
        {
            if(type.Equals(typeof(Course)))
            {
                return Courses.Where(item => item.Id == id).FirstOrDefault();
            }
            else if (type.Equals(typeof(Test)))
            {
                return Tests.Where(item => item.Id == id).FirstOrDefault();
            }
            else if (type.Equals(typeof(Question)))
            {
                return Questions.Where(item => item.Id == id).FirstOrDefault();
            }

            return null;
        }
        
        public object FindByName(string name, Type type)
        {
            if (type.Equals(typeof(User)))
            {
                return GetUserByName(name);
            }
            else if (type.Equals(typeof(Course)))
            {
                return Courses.Where(item => item.Name == name).FirstOrDefault();
            }
            else if (type.Equals(typeof(Test)))
            {
                return Tests.Where(item => item.Name == name).FirstOrDefault();
            }
            else if (type.Equals(typeof(Question)))
            {
                return Questions.Where(item => item.Name == name).FirstOrDefault();
            }

            return null;
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

        public static void SaveUser(User user)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    database.Users.Add(user);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
            }
        }

        public static void SaveCourse(Course course)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    course.Id = database.Courses.Count() + 1;

                    database.Courses.Add(course);

                    database.SaveChanges();
                }
                catch(DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
            }
        }

        public static void SaveTest(Test test) 
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    test.Id = database.Tests.Count() + 1;

                    database.Tests.Add(test);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
            }
        }

        public static void SaveQuestion(Question question)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    question.Id = database.Questions.Count() + 1;

                    database.Questions.Add(question);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
            }
        }

        public static void SaveAnswer(Answer answer)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    answer.Id = database.Answers.Count() + 1;

                    database.Answers.Add(answer);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
            }
        }

        public static void UpdateUser(string initialUsername, ref User user)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                User savedUser = database.Users.Find(initialUsername);

                if(savedUser != null)
                {
                    database.Users.Remove(savedUser);
                }

                database.Users.Add(user);

                database.SaveChanges();
            }
        }

        public static void DeleteUser(User user)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                if(database.Users.Contains(user))
                {
                    database.Users.Remove(user);

                    database.SaveChanges();
                }
            }
        }
    }
}