using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    [Serializable]
    public class RegistrationClass
    {
        //Student list
        public List<Student> students;
        public List<Staff> staff;

        //Registration method
        public RegistrationClass()
        {
            students = new List<Student>();
            staff = new List<Staff>();
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

        public Student FindStudent(string name)
        {
            Student result = new Student();

            foreach (Student c in students)
            {
                if (c.FirstName == name)
                {
                    result = c;
                }
            }
            return result;
        }

        public Staff FindStaff(string name)
        {
            Staff result = new Staff();

            foreach (Staff c in staff)
            {
                if (c.Firstname == name)
                {
                    result = c;
                }
            }
            return result;
        }

        public string getccoursesinfo()
        {
            string t = "";
            foreach (Student c in students)
            {
                t = t + c.Getccoursesinfo();
            }
            return t;
        }

        public string getfcoursesinfo()
        {
            string t = "";
            foreach (Student c in students)
            {
                t = t + c.Getfcoursesinfo();
            }
            return t;
        }

        public void removestudent(int id)
        {
            int x = 0;
            foreach (Student c in students)
            {
                if (c.StudentId == id)
                {
                    students.RemoveAt(x);
                }
                x += 1;
            }
        }
        public string findstudent(string name)
        {
            string result = "student not found";

            foreach (Student c in students)
            {
                if (c.FirstName == name)
                {
                    result = c.studentinfo();
                }

            }
            return result;
        }
        public void removestudent(string name)
        {
            int x = 0;

            foreach (Student c in students)
            {
                if (c.FirstName == name)
                {
                    students.RemoveAt(x);
                }
                x += 1;

            }

        }
        public void removestaff(int id)
        {
            int x = 0;
            foreach (Staff c in staff)
            {
                if (c.StaffId == id)
                {
                    staff.RemoveAt(x);
                }
                x += 1;
            }
        }
        public string findstaff(string name)
        {
            string result = "student not found";

            foreach (Staff c in staff)
            {
                if (c.Firstname == name)
                {
                    result = c.info();
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
