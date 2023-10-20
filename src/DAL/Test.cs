using System;

namespace Teszt__.src.DAL
{
    public partial class Database
    {
        public class Test
        {
            public int id { get; set; }
            public string name { get; set; }

            //public List<Question> questions { get; set; }

            public int submit_limit { get; set; }

            public DateTime startTime { get; set; }

            public DateTime endTime { get; set; }


        }
    }
}