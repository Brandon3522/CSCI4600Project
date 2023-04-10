using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for AccountInfoStudent.xaml
    /// </summary>
    public partial class AccountInfoStudent : Window
    {
        List<Course> courses = new List<Course>();
        string filePath = "./Data.xml";

        RegistrationClass registration = new RegistrationClass();
        Student student = new Student();
       
        public AccountInfoStudent()
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
            userName = registration.UserLoggedIn;
            student = registration.FindStudent(userName);

            // Populate account info wtih Student info
            FirstNameText.Text = userName;
            LastNameText.Text = student.LastName;

            if (student.Gender == "Male")
            {
                MaleRadioButton.IsChecked = true;
            }
            else
            {
                FemaleRadioButton.IsChecked = true;
            }

            PassText.Text = student.Password;

            MajorCombo.Text = student.Major;       

            if (registration.HasFinishedCourses(student))
            {
                //CompletedClasses.Items.Add(student.GetFinishedCoursesinfo());
                AddFinishedCourses(student);
            }
    
            try
            {
                GPAinfo.Content = student.calcgpa();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // Update student information
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Verfiy information isn't blank
            if (FirstNameText.Text == "" || LastNameText.Text == "" || PassText.Text == ""
                || MaleRadioButton.IsChecked == false && FemaleRadioButton.IsChecked == false)
            {
                MessageBox.Show("Please input all information.", "Invalid information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Gather and update account information
            else
            {
                string firstNameUpdate = FirstNameText.Text.ToLower();
                string lastNameUpdate = LastNameText.Text;
                string passwordUpdate = PassText.Text;
                string majorUpdate = MajorCombo.Text;
                string genderUpdate = "";

                if (MaleRadioButton.IsChecked == true)
                {
                    genderUpdate = "Male";
                }
                else
                {
                    genderUpdate = "Female";
                }

                // Update student in students registration list
                registration.UpdateStudent(student, firstNameUpdate, lastNameUpdate, passwordUpdate, 
                    majorUpdate, genderUpdate);

                //////////////// XML ////////////////////
                // Save RegistrationClass object to xml file
                XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                FileStream file0 = System.IO.File.Create(filePath);

                write1.Serialize(file0, registration);

                file0.Close();
                //////////////// XML ////////////////////

                // Update currently logged in user to new first name
                //registration.CurrentUser(student.FirstName);

                MessageBox.Show("Information updated.", "Update Successful", MessageBoxButton.OK);

            }
        }

        // Add finished courses to list box
        private void AddFinishedCourses(Student student)
        {
            foreach (var course in student.FinishedCourses)
            {
                CompletedClasses.Items.Add(course);
            }
        }

        // Navigate to Main Window
        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.Show();
            this.Close();
        }
    }
}
