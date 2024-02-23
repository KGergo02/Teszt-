using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Question
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }

            public string QuestionType { get; set; }

            public int Value { get; set; }

            public int? TestId { get; set; }

            public Question()
            {

            }

            public Question(string name, string questionType, int value, int? testId)
            {
                Name = name;
                QuestionType = questionType;
                Value = value;
                TestId = testId;
            }

            public Question(int id, string name, string questionType, int value, int testId)
            {
                Id = id;
                Name = name;
                QuestionType = questionType;
                Value = value;
                TestId = testId;
            }

            public static Question operator + (Question question, Test test)
            {
                question.TestId = test.Id;

                return question;
            }

            public Dictionary<string, string> GetNameOfProperties()
            {
                return new Dictionary<string, string>
                {
                    { nameof(Name), "Kérdés" },
                    { nameof(QuestionType), "Kérdés Típusa" },
                    { nameof(Value), "Megszerezhető Pont" },
                };
            }
        }
    }
}
