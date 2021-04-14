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
    class Registration
    {
        //Student list
        List<Courses> course;

        //Registration method
        public Registration()
        {
            course = new List<Courses>();
        }

        //Add Registration Info Method
        public void AddRegistration(Courses c)
        {
            course.Add(c);
        }

        //Remove Course Method
        
    }
}
