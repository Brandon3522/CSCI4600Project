//Group 3: Brandon Sitz, Weston Abner
//CSCI 4600
//spring 2020
//Final Project

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    [Serializable]
    class Registration
    {
        //Student list
        List<Student> students;
        List<Staff> staff;

        //Registration method
        public Registration()
        {
            students = new List<Student>();
            staff = new List<Staff>();
        }

        //Add Registration Info Method
        public void Addstudent(Student c)
        {
            students.Add(c);
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
                if(c.StudentId == id)
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
                   result= c.studentinfo();
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
                if (c.staffId == id)
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
                if (c.firstname == name)
                {
                    result = c.info();
                }

            }
            return result;
        }
        //Remove Course Method

    }
}
