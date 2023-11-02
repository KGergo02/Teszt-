using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Teszt__.src.DAL.TestDatabaseContext;

namespace Teszt__.src.DAL
{
    public partial class CourseDatabaseContext
    {
        public class Course
        {
            [Key]
            public string name { get; set; }
            public int user_limit { get; set; }
            public List<Test> tests { get; set; }

            public Course()
            {

            }

            public Course(string name, int user_limit, List<Test> tests)
            {
                this.name = name;
                this.user_limit = user_limit;
                this.tests = tests;
            }

            public override string ToString()
            {
                return $"Kurzus neve: {this.name}\n" +
                    $"Kurzus limit: {this.user_limit}";
            }
        }
    }
}