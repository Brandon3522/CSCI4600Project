using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    [Serializable]
    public class Course : IEnumerable
    {
        public string cname { get; private set; }
        public string days { get; private set; }
        public string time { get; private set; }
        public string location { get; private set; }
        public int chours { get; private set; }
        public int score { get; private set; }
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

        public IEnumerator GetEnumerator()
        {
            return courses.GetEnumerator();
        }

        //public override string ToString()
        //{
        //    foreach (Course C in courses)
        //    {
        //        return $"Name: {C.cname} {C.chours} {C.score}";
        //    }
        //    return "The list remains empty.";
        //}

        public string getinfo()
        {
            return cname + " | " + days + " | " + time + " | " + location + " | " + chours + " | " + score + "\n";
        }
    }
}
