using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegistrationClass registration = new RegistrationClass();
        string filePath = "./Data.xml";

        public Registration()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////
        }

        // Return to Login
        private void LoginScreen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Verify all information inputted
            
            // User should now be able to log in
            if (FirstNameText.Text == "" || LastNameText.Text == "" || PasswordText.Text == "" 
                || MaleRadio.IsChecked == false && FemaleRadio.IsChecked == false
                || StudentCheck.IsChecked == false && StaffCheck.IsChecked == false)
            {
                MessageBox.Show("Please input all information", "Invalid information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Take user information and create Student or Staff based on selection
            else
            {
                string gender = "";
                string Fname = FirstNameText.Text.ToLower();
                string Lname = LastNameText.Text;
                string pass = PasswordText.Text;
                string Major = MajorComboBox.Text;

                if (MaleRadio.IsChecked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                // Add the user as Student and save to Registration
                if (StudentCheck.IsChecked == true)
                {
                    Student student = new Student(Major, Fname, Lname, pass, gender);
                    registration.Addstudent(student); 

                    //////////////// XML ////////////////////
                    // Save RegistrationClass object to xml file
                    XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                    FileStream file0 = new FileStream(filePath, FileMode.OpenOrCreate);

                    write1.Serialize(file0, registration);

                    file0.Close();
                    //////////////// XML ////////////////////

                    MessageBox.Show("Student registered", "Registration successful", MessageBoxButton.OK);
                }

                // Add the user as Admin and save to Registration
                else
                {
                    Staff staff = new Staff(Fname, Lname, gender);
                    registration.AddStaff(staff);

                    //////////////// XML ////////////////////
                    // Save RegistrationClass object to xml file
                    XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                    FileStream file0 = new FileStream(filePath, FileMode.OpenOrCreate);

                    write1.Serialize(file0, registration);

                    file0.Close();
                    //////////////// XML ////////////////////

                    MessageBox.Show("Staff registered", "Registration successful", MessageBoxButton.OK);
                }

            }

        }


    }
}
