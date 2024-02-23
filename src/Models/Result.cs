using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Services;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Result
        {
            public int Id { get; set; }
            
            public string Username { get; set; }

            public int Value { get; set; }

            public int TestId { get; set; }

            public string Date { get; set; }

            public Result()
            {
            }

            public Result(string username, int value, int testId, string dateTime)
            {
                Username = username;
                Value = value;
                TestId = testId;
                Date = dateTime;
            }

            public Dictionary<string, string> GetNameOfProperties()
            {
                return new Dictionary<string, string>
                {
                    { nameof(Username), "Felhasználónév" },
                    { nameof(Value), "Elért Pontszám" },
                    { nameof(Date), "Kitöltés Dátuma" }
                };
            }
        }
    }
}
