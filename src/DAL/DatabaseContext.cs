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

        public DbSet<User_Course> User_Courses { get; set; }


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
            catch(InvalidOperationException IOE)
            {
                Message.Error($"Hiba történt:\n{IOE.Message}");

                return null;
            }
            catch (Exception pokemon)
            {
                Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");

                return null;
            }
        }

        public List<User_Course> GetUser_CourseListOfUser(User user)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    return database.User_Courses.Where(item => item.User_name == user.Name).OrderBy(item => item.Course_name).ToList();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");

                    return null;
                }
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");

                    return null;
            }
        }
        }

        public List<Test> GetTestsOfCourse(Course course)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    return database.Tests.Where(item => item.CourseId == course.Id).OrderBy(item => item.StartTime).OrderBy(item => item.Date).ToList();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");

                    return null;
                }
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");

                    return null;
                }
            }
        }

        public int? GetUserCourseIdByName(string name)
        {
            foreach (User_Course item in User_Courses)
            {
                if(item.User_name == name)
                {
                    return item.Id;
            }
        }

            return null;
        }

        public static void SaveUser(User user)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    user.Id = database.Users.Count() + 1;

                    database.Users.Add(user);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
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
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
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
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
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
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
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
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
            }
        }
        }

        public static void UpdateUser()
        {
            User user = UserService.GetCurrentUser();

            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    User savedUser = database.Users.Find(user.Id);

                    if (savedUser == user)
                    {
                        return;
                    }

                    if (savedUser != null)
                    {
                        savedUser.CopyUser(user);
                    }

                    database.Users.Add(user);

                    database.SaveChanges();
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
            }
        }
        }

        public static void DeleteUser()
        {
            User user = UserService.GetCurrentUser();

            using (DatabaseContext database = new DatabaseContext())
            {
                try
                {
                    if (database.Users.Contains(user))
                    {
                        database.Users.Remove(user);

                        database.SaveChanges();
                    }
                }
                catch (DbUpdateException DUE)
                {
                    Message.Error($"Hiba történt az adatbáziban a művelet végrehajtásakor!\nHiba:\n{DUE.InnerException.Message}");
                }
                catch (Exception pokemon)
                {
                    Message.Error($"Ismeretlen hiba történt! Kérlek jelentsd az alábbi hibát a fejlesztőknek!\n{pokemon.Message}");
                }
            }
        }
    }
}