using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace CSCI4600Project
{
    [Serializable]
    public class Student
    {
        // Fields, Get/Set
        public Guid StudentId { get; set; }  // Global Unique Identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Major { get; set; }
        public bool Permission { get; set; }
        public List<Course> CurrentCourses;
        public List<Course> FinishedCourses;


        // Student constructor
        public Student(string Major, string FirstName, string LastName, 
            string password, string gender, bool permission = false)
        {
            this.StudentId = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Major = Major;
            this.Password = password;
            this.Gender = gender;
            this.Permission = permission;
            CurrentCourses = new List<Course>();
            FinishedCourses = new List<Course>();

        }

        // Blank constructor for data serialization
        public Student()
        {

        }

        // Add current course
        public void addccourse(Course course)
        {
            CurrentCourses.Add(course);
        }

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

        // Calculate GPA based on finished courses
        // Incorrect: Reimplement
        public int calcgpa()
        {
            int h = 0;
            int s = 0;
            foreach (Course c in FinishedCourses)
            {
                h += 1;
                s += c.score;
            }
            if (h == 0)
                return 0;

                int gpa = s / h;
                return gpa;
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

        // Retrieve list of current courses
        public List<Course> CourseList()
        {
            List<Course> courses = new List<Course>();

            try
            {
                foreach (Course course in CurrentCourses)
                {
                    courses.Add(course);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Exception: " + e.Message);
            }

            return courses;
        }

        // Find and return the given course
        public Course CcourseReturn(string courseName)
        {
            Course courseMatch = new Course();

            try
            {
                foreach (Course course in CurrentCourses)
                {
                    if (courseName == course.cname)
                    {
                        courseMatch = course;
                        return courseMatch;
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Exception: " + e.Message);
                throw new Exception();
            }

            return null;
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

        // Remove course from list of current courses
        public void RemoveCourse(Course course)
        {
            CurrentCourses.Remove(course);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " | " + Gender + " | " + Major + "\n";
        }

    }
}
