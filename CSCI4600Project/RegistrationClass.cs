using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CSCI4600Project
{
    [Serializable]
    public class RegistrationClass
    {
        //Student list
        public List<Student> students;
        public List<Staff> staff;
        public string UserLoggedIn { get; set; }

        //Registration method
        public RegistrationClass()
        {
            students = new List<Student>();
            staff = new List<Staff>();
        }

        public RegistrationClass(string userName)
        {
            this.UserLoggedIn = userName;
        }

        public void CurrentUser(string user)
        {
            UserLoggedIn = user;
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

        // Update student account info
        public void UpdateStudent(Student studentToUpdate, string firstName, string lastName, 
            string password, string major, string gender)
        {
            foreach (Student student in students)
            {
                if (studentToUpdate != null && student == studentToUpdate)
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Password = password;
                    student.Major = major;
                    student.Gender = gender;

                    // Update current logged in user
                    UserLoggedIn = firstName;
                }
            }
        }

        // Update staff account info
        public void UpdateStaff(Staff staffToUpdate, string firstName, string lastName, 
            string password, string gender)
        {
            foreach (Staff staff in staff)
            {
                if (staffToUpdate != null && staff == staffToUpdate)
                {
                    staff.Firstname = firstName;
                    staff.Lastname = lastName;
                    staff.Gender = gender;
                    staff.Password = password;

                    // Update current logged in user
                    UserLoggedIn = firstName;
                }
            }
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
            Student student0 = new Student("English", "Bob", "Y", "Password", "Male");
            Student student1 = new Student("English", "Tom", "Y", "Password", "Male");
            Student student2 = new Student("CS", "Tomyyyyy", "Y", "Password", "Male");
            Student student3 = new Student("Engineering", "Bobbyyy", "Y", "Password", "Male");

        }

    }
}
