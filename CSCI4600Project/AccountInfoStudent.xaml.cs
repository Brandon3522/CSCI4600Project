using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for AccountInfoStudent.xaml
    /// </summary>
    public partial class AccountInfoStudent : Window
    {
        List<Course> courses = new List<Course>();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        RegistrationClass registration0 = new RegistrationClass();
        Student student = new Student();
       
        public AccountInfoStudent()
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
            student = registration0.FindStudent(userName);

            // Populate account info wtih Student info
            FirstNameText.Text = userName;
            LastNameText.Text = student.GetLastName();

            if (student.GetGender() == "Male")
            {
                MaleRadioButton.IsChecked = true;
            }
            else
            {
                FemaleRadioButton.IsChecked = true;
            }

            PassText.Text = student.GetPassword();

            MajorCombo.Text = student.GetMajor();       

            if (registration0.HasFinishedCourses(student))
            {
                CompletedClasses.Items.Add(student.GetFinishedCoursesinfo());
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
            // Update student information, needs to be updated in Registration file


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
