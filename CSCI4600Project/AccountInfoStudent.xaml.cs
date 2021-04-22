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
        // Needs to bind completed courses to CompletedClasses list box
        Student student = new Student(0, "Computer Science", "Billy", "Bob", "Pass", "Male");
        List<Course> courses = new List<Course>();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        RegistrationClass registration0 = new RegistrationClass();
        Student student1 = new Student();
       
        public AccountInfoStudent()
        {
            InitializeComponent();

            // date.time
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            DispatcherTimer LiveTime1 = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick1;
            LiveTime.Start();

            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration0.getUserLoggedIn();
            student1 = registration0.FindStudent(userName);
            //

            // completed courses test
            //Course C = new Course("English", "Mondays and tuesdays", "8:00", "English building", 4, 4);
            //Course B = new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 3);
            //student1.addfcourse(C);
            //student1.addfcourse(B);

            // Populate account info wtih Student info
            FirstNameText.Text = userName;
            LastNameText.Text = student.GetLastName();

            if (student1.GetGender() == "Male")
            {
                MaleRadioButton.IsChecked = true;
            }
            else
            {
                FemaleRadioButton.IsChecked = true;
            }

            PassText.Text = student.GetPassword();

            MajorCombo.Text = student1.GetMajor();
            //
            

            if (registration0.HasfCourses(student1))
            {
                CompletedClasses.Items.Add(student1.Getfcoursesinfo());
            }

            try
            {
                GPAinfo.Content = student1.calcgpa();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            

        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString();
        }

        void timer_Tick1(object sender, EventArgs e)
        {
            LiveTimeLabel_Copy.Content = DateTime.Now.ToString("HH:mm:ss");
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
