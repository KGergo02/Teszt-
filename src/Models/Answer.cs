using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Answer
        {
            [Key]
            public int Id { get; set; }

            public string Value { get; set; }

            public bool Correct { get; set; }

            public int QuestionId { get; set; }

            public Answer()
            {

            }

            public Answer(string value, bool correct, int questionId)
            {
                Value = value;
                Correct = correct;
                QuestionId = questionId;
            }

            public Answer(int id, string value, bool correct, int questionId)
            {
                Id = id;
                Value = value;
                Correct = correct;
                QuestionId = questionId;
            }
        }
    }
}
