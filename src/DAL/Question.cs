using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Teszt__.src.DAL.TestDatabaseContext;

namespace Teszt__.src.DAL
{
    public partial class UserDatabaseContext
    {
        public class Question
        {
            [Key]
            public string name { get; set; }

            [NotMapped]
            public List<string> listOfAnswers { get; set; }

            public string questionType { get; set; }

            public Test test;

            public Question()
            {

            }

            public Question(string name, List<string> listOfAnswers, string questionType, Test test)
            {
                this.name = name;
                this.listOfAnswers = listOfAnswers;
                this.questionType = questionType;
                this.test = test;
            }
        }
    }
}
