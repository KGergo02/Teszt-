using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class User_Course
        {
            [Key]
            public int Id { get; set; }

            public string User_name { get; set; }

            public string Course_name { get; set; }

            public User_Course()
            {
            }

            public User_Course(string user_name, string course_name)
            {
                User_name = user_name;
                Course_name = course_name;
            }

            public User_Course(int id, string user_name, string course_name)
            {
                Id = id;
                User_name = user_name;
                Course_name = course_name;
            }
        }
    }
}
