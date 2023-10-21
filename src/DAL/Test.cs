using System;
using System.Collections.Generic;

namespace Teszt__.src.DAL
{
    public partial class Database
    {
        public class Test
        {
            public int id { get; set; }
            public string name { get; set; }

            public int submit_limit { get; set; }

            public DateTime date { get; set; }

            public TimeSpan startTime { get; set; }

            public TimeSpan endTime { get; set; }

            public Test()
            {

            }

            public Test(int id, string name, int submit_limit, DateTime date, TimeSpan startTime, TimeSpan endTime)
            {
                this.id = id;
                this.name = name;
                this.submit_limit = submit_limit;
                this.date = date;
                this.startTime = startTime;
                this.endTime = endTime;
            }

            public Test(string name, int submit_limit, DateTime date, TimeSpan startTime, TimeSpan endTime)
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