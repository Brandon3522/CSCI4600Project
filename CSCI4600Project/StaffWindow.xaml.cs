﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        RegistrationClass registration = new RegistrationClass();
        Staff staff = new Staff();
        string filePath = "./Data.xml";

        public StaffWindow()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration.getUserLoggedIn();
            staff = registration.FindStaff(userName);

            // Add students to List box
            foreach (var item in registration.students)
            {
                StudentsList.Items.Add(item);
            }
        }

        // View account information
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////// XML ////////////////////
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration);

            file0.Close();
            //////////////// XML ////////////////////

            AccountInfoStaff accountInfoStaff = new AccountInfoStaff();
            accountInfoStaff.Show();
            this.Close();
        }

        // Logout
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////// XML ////////////////////
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration);

            file0.Close();
            //////////////// XML ////////////////////

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Remove student from list
        // Add XML removal
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify this is the student to be removed
            // Remove student from StudentListDataGrid
            // Remove student from Registration list

            var selected = (Student)StudentsList.SelectedItem;

            if (MessageBox.Show("Do you want to remove this student?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //MessageBox.Show(selected.ToString());

                registration.removeStudent(selected);

                StudentsList.Items.Clear();

                try
                {
                    foreach (var item in registration.DisplayStudents())
                    {
                        StudentsList.Items.Add(item);
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Exception: " + a.Message);
                    throw new Exception(a.Message);
                }

                //////////////// XML ////////////////////
                // Save RegistrationClass object to xml file
                XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                FileStream file0 = System.IO.File.Create(filePath);

                write1.Serialize(file0, registration);

                file0.Close();
                //////////////// XML ////////////////////
            }
        }


    }
}
