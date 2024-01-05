using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Course
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; } 
            
            public int User_limit { get; set; }
            
            public Course()
            {

            }

            public Course(string name, int user_limit)
            {
                this.Name = name;
                this.User_limit = user_limit;
            }

            public Course(int id, string name, int user_limit)
            {
                Id = id;
                Name = name;
                User_limit = user_limit;
            }
        }
    }
}