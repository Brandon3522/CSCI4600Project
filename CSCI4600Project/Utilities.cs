using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    internal class Utilities
    {
        // Unused Functions
        /*
         * REGISTRATION CLASS

        public string getCurrentCoursesinfo()
        {
            string currentCourses = "";
            foreach (Student student in students)
            {
                currentCourses += student.GetCurrentCoursesinfo();
            }
            return currentCourses;
        }

        public string getFinishedCoursesinfo()
        {
            string finishedCourses = "";
            foreach (Student student in students)
            {
                finishedCourses += student.GetFinishedCoursesinfo();
            }
            return finishedCourses;
        }

        public void removestudent(int id)
        {
            int counter = 0;
            foreach (Student student in students)
            {
                if (student.StudentId == id)
                {
                    students.RemoveAt(counter);
                }
                counter += 1;
            }
        }

                public void removestaff(int id)
        {
            int counter = 0;
            foreach (Staff st in staff)
            {
                if (st.StaffId == id)
                {
                    staff.RemoveAt(counter);
                }
                counter += 1;
            }
        }

        * REGISTRATION CLASS
        
        * STUDENT CLASS
        
        // Add finished course
        public void addfcourse(Course course)
        {
            FinishedCourses.Add(course);
        }

        // Add all current courses to finished courses
        public void endsemester()
        {
            foreach (Course course in CurrentCourses)
            {
                FinishedCourses.Add(course);
            }
            CurrentCourses = new List<Course>();
        }

        // Get current courses information: Not used
        public string Getccourseinfo(string course_name)
        {
            string current_courses = "not a currently registered course";
            foreach (Course course in CurrentCourses)
            {
                if (course_name == course.cname)
                {
                    current_courses = course.getCurrentCourseInfo() + "\n";
                }
            }
            return current_courses;

        }

        // Get current courses information
        public string GetCurrentCoursesinfo()
        {
            string course_info = "";

            try
            {
                foreach (Course course in CurrentCourses)
                {
                    course_info += course.getCurrentCourseInfo() + "\n";
                }
            }
            catch (Exception e)
            {

                throw new Exception("Exception: " + e.Message);
            }
            return course_info;

        }

        // Find and return the info for all finished courses
        public string GetFinishedCoursesinfo()
        {
            string course_info = "";
            foreach (Course course in FinishedCourses)
            {
                course_info += course.getFinishedCourseInfo();
            }

            return course_info;
        }

        // Not used
        public void removeccourse(string coureseToRemove)
        {
            int counter = 0;

            foreach (Course course in CurrentCourses)
            {
                if (coureseToRemove == course.cname)
                {
                    CurrentCourses.RemoveAt(counter);
                }
                counter += 1;
            }
        }
        
        * STUDENT CLASS


        */


    }
}
