using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Teszt__.src.Models.DatabaseContext;

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

            public DateTime GetStartDateTime()
            {
                List<string> testStartDate = this.StartDate.Replace(" ", "").Split('.').ToList();

                List<string> startTestTimes = this.StartTime.Split(':').ToList();

                return new DateTime(
                Convert.ToInt32(testStartDate[0]),
                Convert.ToInt32(testStartDate[1]),
                Convert.ToInt32(testStartDate[2]),
                Convert.ToInt32(startTestTimes[0]),
                Convert.ToInt32(startTestTimes[1]),
                0
                );
            }

            public DateTime GetEndDateTime()
            {
                List<string> testEndDate = this.EndDate.Replace(" ", "").Split('.').ToList();

                List<string> endTestTimes = this.EndTime.Split(':').ToList();

                return new DateTime(
                Convert.ToInt32(testEndDate[0]),
                Convert.ToInt32(testEndDate[1]),
                Convert.ToInt32(testEndDate[2]),
                Convert.ToInt32(endTestTimes[0]),
                Convert.ToInt32(endTestTimes[1]),
                0
                );
            }
        }
    }
}