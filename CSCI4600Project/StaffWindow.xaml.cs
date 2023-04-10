using System;
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

            // Read XML file
            registration = XMLFile.ReadFromXmlFile<RegistrationClass>(filePath);

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration.UserLoggedIn;
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
            // Save RegistrationClass object to xml file
            XMLFile.WriteToXmlFile<RegistrationClass>(filePath, registration);

            AccountInfoStaff accountInfoStaff = new AccountInfoStaff();
            accountInfoStaff.Show();
            this.Close();
        }

        // Logout
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Save RegistrationClass object to xml file
            XMLFile.WriteToXmlFile<RegistrationClass>(filePath, registration);

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

                // Save RegistrationClass object to xml file
                XMLFile.WriteToXmlFile<RegistrationClass>(filePath, registration);
            }
        }


    }
}
