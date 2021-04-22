using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    [Serializable]
    public class Course
    {
        public string cname { get; set; }
        public string days { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public int chours { get; set; }
        public int score { get; set; }
        List<Course> courses = new List<Course>();

        public Course(string cname, string days, string time, string location, int chours, int score)
        {
            this.cname = cname;
            this.days = days;
            this.time = time;
            this.location = location;
            this.chours = chours;
            this.score = score;
        }

        public Course()
        {

        }

        public override string ToString()
        {
            return cname + " | " + days + " | " + time + " | " + location + " | " + "Credit hours: " + chours + " | " + "Score: " + score + "\n";
        }

        public string getinfo()
        {
            return cname + " | " + days + " | " + time + " | " + location + " | " + "Credit hours: " + chours + " | " + "Score: " + score + "\n";
        }

        public string getfcourseinfo()
        {
            return cname + " | " + days + " | " + time + " | " + location + " | " + "Credit hours: " + chours + " | " + "Score: " + score + "\n";
        }
    }
}
