using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrationClass registration = new RegistrationClass();

        XmlDocument doc = new XmlDocument();

        string filePath = "./Data.xml";

        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists(filePath))
            {
                XElement rootNode = new XElement("RegistrationClass");
                rootNode.Save(filePath);
            }
            else
            {
                // Load XML file
                doc.Load(filePath);
            }
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
            // Read XML file
            registration = XMLFile.ReadFromXmlFile<RegistrationClass>(filePath);

            // Check empty input
            if (UsernameText.Text == "" || PasswordText.Password == "")
            {
                MessageBox.Show("Please verify Username and Password", "Empty Username or Password", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string user = UsernameText.Text.ToLower();

            // Find, verify and save student as logged in
            if (registration.FindStudentName(user) == user)
            {
                registration.CurrentUser(user);

                // Save RegistrationClass object to xml file
                XMLFile.WriteToXmlFile<RegistrationClass>(filePath, registration);

                MessageBox.Show("User logged in as Student", "Success", MessageBoxButton.OK);
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Close();

            }

            // Display message if invalid login
            else if (registration.FindStudentName(user) != user && registration.findstaff(user) != user)
            {
                MessageBox.Show("Please enter a valid username / password", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Find, verify, and save Admin as logged in
            if (registration.findstaff(user) == user && PasswordText.Password.Contains("Admin"))
            {

                registration.CurrentUser(user);

                // Save RegistrationClass object to xml file
                XMLFile.WriteToXmlFile<RegistrationClass>(filePath, registration);

                MessageBox.Show("User logged in as Admin", "Success", MessageBoxButton.OK);
                StaffWindow staffWindow = new StaffWindow();
                staffWindow.Show();
                this.Close();

                // Need to update
                //if (!PasswordText.Password.Contains("Admin") || registration.findstaff(user) != user)
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

        //registration.Addstudent(student0);
        //registration.Addstudent(student2);
        //registration.Addstudent(student3);

        //Student student1 = new Student(1, "CS", "Tom", "Bob", "Password", "Male");

        //Course course = new Course("English", "Monday", "8:00", "English building", 4, 0);

        //Course course1 = new Course("Engineering", "Monday", "10:00", "Engineering building", 4, 0);

        //student1.addccourse(course1);
        //student1.addccourse(course);

        //registration.Addstudent(student1);
        ///////////////////////// testing /////////////////////////

    }
}
