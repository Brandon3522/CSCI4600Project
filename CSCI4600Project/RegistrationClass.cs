using System;
using System.Collections.Generic;

namespace CSCI4600Project
{
    [Serializable]
    public class RegistrationClass
    {
        //Student list
        public List<Student> students;
        public List<Staff> staff;
        public string _UserLoggedIn { get; set; }

        //Registration method
        public RegistrationClass()
        {
            students = new List<Student>();
            staff = new List<Staff>();
        }

        public RegistrationClass(string userName)
        {
            this._UserLoggedIn = userName;
        }

        public string getUserLoggedIn()
        {
            return _UserLoggedIn;
        }

        public void UserLoggedIn(string user)
        {
            _UserLoggedIn = user;
        }

        //Add Registration Info Method
        public void Addstudent(Student c)
        {
            students.Add(c);
        }

        public void AddStaff(Staff s)
        {
            staff.Add(s);
        }

        // Check for finished courses
        public bool HasFinishedCourses(Student student)
        {
            bool hasCourse = false;
            if (student.FinishedCourses.Count >= 1)
            {
                hasCourse = true;
                return hasCourse;
            }
            else return hasCourse;
        }

        // Find students first name
        public string FindStudentName(string name)
        {
            string result = "student not found";

            foreach (Student student in students)
            {
                if (student.FirstName == name)
                {
                    result = student.FirstName;
                }
            }
            return result;
        }

        public Student FindStudent(string name)
        {
            Student result = new Student();

            foreach (Student student in students)
            {
                if (student.FirstName == name)
                {
                    result = student;
                }
            }
            return result;
        }

        public Staff FindStaff(string name)
        {
            Staff result = new Staff();

            foreach (Staff student in staff)
            {
                if (student.Firstname == name)
                {
                    result = student;
                }
            }
            return result;
        }

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
            string finishedCourses= "";
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

        public List<Student> DisplayStudents()
        {
            List<Student> result = new List<Student>();

            foreach (Student student in students)
            {
                result.Add(student);
            }
            return result;
        }

        public void removeStudent(Student student)
        {
            students.Remove(student);
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

        public string findstaff(string name)
        {
            string result = "student not found";

            foreach (Staff st in staff)
            {
                if (st.Firstname == name)
                {
                    result = st.info();
                }
            }
            return result;
        }
        
        public void LoadRegistration()
        {
            Student student0 = new Student(0, "English", "Bob", "Y", "Password", "Male");
            Student student1 = new Student(1, "English", "Tom", "Y", "Password", "Male");
            Student student2 = new Student(2, "CS", "Tomyyyyy", "Y", "Password", "Male");
            Student student3 = new Student(3, "Engineering", "Bobbyyy", "Y", "Password", "Male");

        }

    }
}
