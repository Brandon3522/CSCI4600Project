//Group 3: Brandon Sitz, Weston Abner
//CSCI 4600
//spring 2020
//Final Project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    [Serializable]
    class Student
    {
        //Fields, Get/Set
        public int StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string major { get; set; }
        List<Course> ccourses;
        List<Course> fcourses;


        //Student method
        public Student (int StudentId,string major, string FirstName, string LastName)
        {
            this.StudentId = StudentId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.major = major;
            ccourses = new List<Course>();
            fcourses = new List<Course>();
        }
        public string studentinfo()
        {
            string s = "";
            string t = "";
            foreach (Course c in ccourses)
            {
                t = t + c.cname + " ";
            }
            foreach (Course c in fcourses)
            {
                t = t + c.cname + " ";
            }

            s = FirstName + " " + LastName + " " + major ;
            return s;
        }
        public void addccourse(Course course)
        {
            ccourses.Add(course);
        }

        public void endsemester()
        {
            foreach (Course c in ccourses)
            {
                fcourses.Add(c);
            }
            ccourses = new List<Course>();
        }
        public int calcgpa()
        {
            int h = 0;
            int s = 0;
            foreach (Course c in ccourses)
            {
                h += c.chours;
                s += c.score;
            }

            foreach (Course c in fcourses)
            {
                h += c.chours;
                s += c.score;
            }
            int gpa = s / h;
            return gpa;
        }
        //Get information method
        public string Getccourseinfo(string s)
        {
            string t="not a currently registered course";
            foreach(Course c in ccourses)
            {
                if (s == c.cname)
                {
                    t = c.getinfo();
                }
            }


            return t;
           
        }
        public string Getccoursesinfo()
        {
            string t = "";
            foreach (Course c in ccourses)
            {
                t = t + c.getinfo();
            }


            return t;

        }

        public string Getfcoursesinfo()
        {
            string t = "";
            foreach (Course c in fcourses)
            {
                t = t + c.getinfo();
            }


            return t;

        }

        public void removeccourse(string s)
        {
            int x = 0;
            
            foreach (Course c in ccourses)
            {
                if (s == c.cname)
                {
                    ccourses.RemoveAt(x);
                }
                x += 1;
            }


            

        }
    }
}
     

