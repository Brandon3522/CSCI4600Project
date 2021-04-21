using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    [Serializable]
    public class Student
    {
        //Fields, Get/Set
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string major { get; set; }
        public bool Permission { get; set; }
       public List<Course> ccourses;
       public List<Course> fcourses;


        //Student method
        public Student(int StudentId, string major, string FirstName, string LastName, 
            string password, string gender, bool permission = false)
        {
            StudentId += 1;
            this.StudentId = StudentId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.major = major;
            this.Password = password;
            this.Gender = gender;
            this.Permission = permission;
            ccourses = new List<Course>();
            fcourses = new List<Course>();

        }

        public Student()
        {

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

            s = FirstName + " " + LastName + " " + major;
            return s;
        }
        public void addccourse(Course course)
        {
            ccourses.Add(course);
        }

        public void addfcourse(Course course)
        {
            fcourses.Add(course);
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
            string t = "not a currently registered course";
            foreach (Course c in ccourses)
            {
                if (s == c.cname)
                {
                    t = c.getinfo() + "\n";
                }
            }


            return t;

        }
        public string Getccoursesinfo()
        {
            string t = "";

            try
            {
                foreach (Course c in ccourses)
                {
                    t = t + c.getinfo() + "\n";
                }
            }
            catch (Exception e)
            {

                throw new Exception("Exception: " + e.Message);
            }

          


            return t;

        }

        public List<Course> CourseList()
        {
            List<Course> courses = new List<Course>();

            try
            {
                foreach (Course c in ccourses)
                {
                    courses.Add(c);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Exception: " + e.Message);
            }

           
            return courses;



        }

        public Course CcourseReturn(string courseName)
        {
            Course course1 = new Course();

            foreach (Course c in ccourses)
            {
                if (courseName == c.cname)
                {
                    course1 = c;
                    return course1;
                }
                    
            }

            return null;
        }

        public string Getfcoursesinfo()
        {
            string t = "";
            foreach (Course c in fcourses)
            {
                t = t + c.getfcourseinfo();
            }


            return t;

        }

        public void removeccourse(string s)
        {
            int x = 0;

            foreach (Course c in ccourses.ToList())
            {
                if (s == c.cname)
                {
                    ccourses.RemoveAt(x);
                }
                x += 1;
            }
        }

        public Course RemoveCourse(Course C)
        {
            int x = 0;
            Course Co = new Course();
            foreach (Course c in ccourses.ToList())
            {
                if (C == c)
                {
                    ccourses.RemoveAt(x);
                    return Co;
                }
                x += 1;
            }
            return null;
        }

        public override string ToString()
        {
            return StudentId + " | " + FirstName + " " + LastName + " | " + Gender + " | " + major + " | " + "\n";
        }



    }
}
