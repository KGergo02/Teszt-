using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

            public int? CourseId { get; set; }

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

            public Test(string name, int submit_Limit, string date, string startTime, string endTime, int? courseId)
            {
                Name = name;
                Submit_Limit = submit_Limit;
                Date = date;
                StartTime = startTime;
                EndTime = endTime;
                CourseId = courseId;
            }

            public Test(int id, string name, int submit_Limit, string date, string startTime, string endTime, int courseId)
            {
                Id = id;
                Name = name;
                Submit_Limit = submit_Limit;
                Date = date;
                StartTime = startTime;
                EndTime = endTime;
                CourseId = courseId;
            }
        }
    }
}