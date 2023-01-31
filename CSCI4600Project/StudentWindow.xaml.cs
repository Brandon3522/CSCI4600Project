﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        RegistrationClass registration0 = new RegistrationClass();
        Student student1 = new Student();
        string filePath = "./Data.xml";
        
        public StudentWindow()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration0.getUserLoggedIn();
            student1 = registration0.FindStudent(userName);

            // Label = current user
            StudentNameLabel.Content = userName;

            ListReload();
        }

        // Logout from system
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////// XML ////////////////////
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration0);

            file0.Close();
            //////////////// XML ////////////////////

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // View account information
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////// XML ////////////////////
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration0);

            file0.Close();
            //////////////// XML ////////////////////

            AccountInfoStudent accountInfoStudent = new AccountInfoStudent();
            accountInfoStudent.Show();
            this.Close();
        }

        // Add course from combo box
        // WTF is this??
        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Add selected course from comboBox into StudentList
            // Add selected course to student course list
            if (student1.CourseList().Count >= 5)
            {
                MessageBox.Show("Only 5 classes or less allowed per semester", "Classes", MessageBoxButton.OK);
                return;
            }

            if (CourseList.Text == "C++")
            {
                Course Cpp = new Course("C++", "Monday and Tuesday", "8:00", "Computer Science building", 3, 0);
                student1.addccourse(Cpp);
                BindGrid(Cpp.cname);
            }

            if (CourseList.Text == "C#")
            {
                Course CSharp = new Course("C#", "Friday", "8:00", "Computer Science building", 3, 0);
                student1.addccourse(CSharp);
                BindGrid(CSharp.cname);
            }

            if (CourseList.Text == "Python")
            {
                Course Python = new Course("Python", "Wednesday", "11:00", "Computer Science building", 3, 0);
                student1.addccourse(Python);
                BindGrid(Python.cname);
            }

            if (CourseList.Text == "Calculus")
            {
                Course Calculus = new Course("Calculus", "Monday and Tuesday", "3:00", "Computer Science building", 4, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "English")
            {
                Course Calculus = new Course("English", "Monday and Thursday", "1:00", "English building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "Data Structures")
            {
                Course Calculus = new Course("Data Structures", "Monday", "3:30", "Computer Science building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "COBOL")
            {
                Course Calculus = new Course("COBOL", "Friday", "1:30", "Computer Science building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "Software Engineering")
            {
                Course Calculus = new Course("Software Engineering", "Monday and Friday", "1:30", "Computer Science building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "History")
            {
                Course Calculus = new Course("History", "Tuesday and Thursday", "7:00", "History building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "Calculus 2")
            {
                Course Calculus = new Course("Calculus 2", "Tuesday, Wednesday, and Thursday", "9:00", "Mathematics building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);
            }

            if (CourseList.Text == "Java")
            {
                Course Java = new Course("Java", "Tuesday, Wednesday, and Thursday", "9:00", "Computer Science building", 3, 0);
                student1.addccourse(Java);
                BindGrid(Java.cname);
            }

        }

        // switch statement to determine what course is removed
        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected course from ListBox
            // Remove course from student course list

            var selected = (Course)StudentListBox.SelectedItem;

            if (MessageBox.Show("Do you want to remove this course?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                student1.RemoveCourse(selected);

                StudentListBox.Items.Remove(selected);
                ListReload();
            }            
        }

        // Reload current courses
        public void BindGrid(string course)
        {

            try
            {
                StudentListBox.Items.Add(student1.CcourseReturn(course));
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                throw new Exception();
                
            }
         }

        public void ListReload()
        {
            StudentListBox.Items.Clear();

            try
            {
                foreach (var item in student1.CourseList())
                {
                    StudentListBox.Items.Add(item);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                throw new Exception("Oh No, Exception: " + e.Message);
            }

        }

        //////////////// Test ////////////////////
        // completed courses test
        //Course C = new Course("English", "Monday and Tuesday", "8:00", "English building", 3, 3);
        //Course B = new Course("C++", "Monday and Tuesday", "9:00", "Computer Science building", 3, 4);
        //Course D = new Course("Calculus 2", "Monday and Thursday", "9:00", "Mathematics building", 4, 4);
        //student1.addfcourse(C);
        //student1.addfcourse(B);
        //student1.addfcourse(D);
        //////////////// Test ////////////////////

    }
}
