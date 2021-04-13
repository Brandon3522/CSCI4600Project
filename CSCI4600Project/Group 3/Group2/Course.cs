using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    [Serializable]
    class Course
    {
        public string cname { get; private set; }
        public string days { get; private set; }
        public string time { get; private set; }
        public string location { get; private set; }
        public int chours { get; private set; }
        public int score { get; private set; }

        public Course(string cname, string days,string time, string location, int chours, int score)
        {
            this.cname = cname;
            this.days = days;
            this.time = time;
            this.location = location;
            this.chours = chours;
            this.score = score;

        }

        public string getinfo()
        {
            return cname + " | " + days + " | " + time + " | " + location + " | " + chours + " | " + score;
        }
    }
}
