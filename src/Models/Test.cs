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

            public bool Best_Submitted_Result_Counts { get; set; }

            public string StartDate { get; set; }

            public string StartTime { get; set; }

            public string EndDate { get; set; }

            public string EndTime { get; set; }

            public int? CourseId { get; set; }

            public Test()
            {

            }

            public Test(string name, int submit_Limit, bool best_Submitted_Answer_Counts, string startDate, string startTime, string endDate, string endTime, int? courseId)
            {
                Name = name;
                Submit_Limit = submit_Limit;
                Best_Submitted_Result_Counts = best_Submitted_Answer_Counts;
                StartDate = startDate;
                StartTime = startTime;
                EndDate = endDate;
                EndTime = endTime;
                CourseId = courseId;
            }
        }
    }
}