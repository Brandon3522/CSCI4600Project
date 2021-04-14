//Group 2: Jasmine Sager-Gonzalez, Brandon Sitz, Weston Abner
//CSCI 3005-12
//Fall 2020
//Final Project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    class Courses
    {
        //Fields, Get/Set
        public int StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Course1 { get; private set; }
        public string Course2 { get; private set; }
        public string Course3 { get; private set; }
        public string Course4 { get; private set; }

        //Student method
        public Courses (string c1, string c2, string c3, string c4)
        {
            this.Course1 = c1;
            this.Course2 = c2;
            this.Course3 = c3;
            this.Course4 = c4;
        }

        //Get information method
        public string GetInfo()
        {
            return Course1 + "\n" + Course2 + "\n" + Course3 + "\n" + Course4;
        }

        public void removecourse(string c)
        {
            if (c == Course1)
            {
               this.Course1 = " ";
            }
            if (c == Course2)
            {
                this.Course2 = " ";
            }
            if (c == Course3)
            {
                this.Course3 = " ";
            }
            if (c == Course4)
            {
                this.Course4 = " ";
            }
        }
    } 
}
