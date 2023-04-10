using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrationClass registrationClass = new RegistrationClass();

        XmlDocument doc = new XmlDocument();

        // May need to change file path if cloning application
        string filePath = "./Data.xml";

        public MainWindow()
        {
            InitializeComponent();

            // Load XML file
            doc.Load(filePath);
        }

        // Navigate to Registration Window
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        // Login to system
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registrationClass = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////

            // Check empty input
            if (UsernameText.Text == "" || PasswordText.Password == "")
            {
                MessageBox.Show("Please verify Username and Password", "Empty Username or Password", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string user = UsernameText.Text.ToLower();

            // Find, verify and save student as logged in
            if (registrationClass.FindStudentName(user) == user)
            {
                //string CurrentUser = user;

                registrationClass.CurrentUser(user);

                //////////////// XML ////////////////////
                // Save RegistrationClass object to xml file
                XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                FileStream file0 = System.IO.File.Create(filePath);

                write1.Serialize(file0, registrationClass);

                file0.Close();
                //////////////// XML ////////////////////

                MessageBox.Show("User logged in as Student", "Success", MessageBoxButton.OK);
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Close();

            }

            // Display message if invalid login
            else if (registrationClass.FindStudentName(user) != user && registrationClass.findstaff(user) != user)
            {
                MessageBox.Show("Please enter a valid username / password", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Find, verify, and save Admin as logged in
            if (registrationClass.findstaff(user) == user && PasswordText.Password.Contains("Admin"))
            {

                registrationClass.CurrentUser(user);

                //////////////// XML ////////////////////
                // Save RegistrationClass object to xml file
                XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                FileStream file0 = System.IO.File.Create(filePath);

                write1.Serialize(file0, registrationClass);

                file0.Close();
                //////////////// XML ////////////////////

                MessageBox.Show("User logged in as Admin", "Success", MessageBoxButton.OK);
                StaffWindow staffWindow = new StaffWindow();
                staffWindow.Show();
                this.Close();

                // Need to update
                //if (!PasswordText.Password.Contains("Admin") || registrationClass.findstaff(user) != user)
                //{
                    
                //}

            }
        }

        ///////////////////////// testing /////////////////////////
        //Student student0 = new Student(0, "English", "Billy", "Bob", "Password", "Male");

        //student0.addccourse(course);

        //student0.addccourse(course1);
        //student0.addccourse(course);

        ////student2.addccourse(course1);

        //registrationClass.Addstudent(student0);
        //registrationClass.Addstudent(student2);
        //registrationClass.Addstudent(student3);

        //Student student1 = new Student(1, "CS", "Tom", "Bob", "Password", "Male");

        //Course course = new Course("English", "Monday", "8:00", "English building", 4, 0);

        //Course course1 = new Course("Engineering", "Monday", "10:00", "Engineering building", 4, 0);

        //student1.addccourse(course1);
        //student1.addccourse(course);

        //registrationClass.Addstudent(student1);
        ///////////////////////// testing /////////////////////////

    }
}
