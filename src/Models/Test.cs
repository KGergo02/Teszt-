using System.ComponentModel.DataAnnotations;

namespace Teszt__.src.Models
{
    public partial class DatabaseContext
    {
        public class Test
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }

            public int Submit_Limit { get; set; }

            public string Date { get; set; }

            public string StartTime { get; set; }

            public string EndTime { get; set; }

            public int CourseId { get; set; }

            public Test()
            {

            }

            public Test(string name, int submit_limit, string date, string startTime, string endTime, int courseid)
            {
                this.Name = name;
                this.Submit_Limit = submit_limit;
                this.Date = date;
                this.StartTime = startTime;
                this.EndTime = endTime;
                this.CourseId = courseid;
            }
        }
    }
}