using System.Collections.Generic;

namespace Teszt__.src.DAL
{
    public partial class Database
    {
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

            public Course(string name, int user_limit, List<Test> tests)
            {
                this.name = name;
                this.user_limit = user_limit;
                this.tests = tests;
            }
        }
    }
}