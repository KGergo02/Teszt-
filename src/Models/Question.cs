using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Question
        {
            [Key]
            public string Name { get; set; }

            [NotMapped]
            public List<string> Answers { get; set; }

            public string questionType { get; set; }

            public string testName;

            public Question()
            {

            }

            public Question(string name, List<string> answers, string questionType, string testName)
            {
                Name = name;
                Answers = answers;
                this.questionType = questionType;
                this.testName = testName;
            }
        }
    }
}
