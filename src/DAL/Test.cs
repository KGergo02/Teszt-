using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teszt__.src.DAL
{
    public partial class TestDatabaseContext
    {
        public class Test
        {
            [Key]
            public string name { get; set; }

            public int submit_limit { get; set; }

            public string date { get; set; }

            public string startTime { get; set; }

            public string endTime { get; set; }

            public Test()
            {

            }

            public Test(string name, int submit_limit, string date, string startTime, string endTime)
            {
                this.name = name;
                this.submit_limit = submit_limit;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
            }
        }
    }
}