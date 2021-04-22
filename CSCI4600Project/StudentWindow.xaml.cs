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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        RegistrationClass registration0 = new RegistrationClass();
        Student student1 = new Student();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";
        
        public StudentWindow()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
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

            // competed courses test
            //Course C = new Course("English", "Mondays and tuesdays", "8:00", "English building", 4, 3);
            //Course B = new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 4);
            //student1.addfcourse(C);
            //student1.addfcourse(B);

            // Label = current user
            StudentNameLabel.Content = userName;

            ListReload();

        }
        // Logout from system
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////////// Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration0);

            file0.Close();
            ////////////////////
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        // View account information
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            //////////////////// Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create(filePath);

            write1.Serialize(file0, registration0);

            file0.Close();
            ////////////////////

            AccountInfoStudent accountInfoStudent = new AccountInfoStudent();
            accountInfoStudent.Show();
            this.Close();
        }

        // switch statement to determine what course is selected
        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Add selected course from comboBox into StudentList
            // Add selected course to student course list

            if (CourseList.Text == "Cpp")
            {
                Course Cpp = new Course("Cpp", "Mondays and tuesdays", "8:00", "CS building", 3, 0);
                student1.addccourse(Cpp);
                BindGrid(Cpp.cname);

            }

            if (CourseList.Text == "C#")
            {
                Course CSharp = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 3, 0);
                student1.addccourse(CSharp);
                BindGrid(CSharp.cname);

            }

            if (CourseList.Text == "Python")
            {
                Course Python = new Course("Python", "Mondays and tuesdays", "11:00", "CS building", 3, 0);
                student1.addccourse(Python);
                BindGrid(Python.cname);

            }

            if (CourseList.Text == "Calculus")
            {
                Course Calculus = new Course("Calculus", "Mondays and tuesdays", "1:00", "CS building", 3, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);

            }

        }

        // switch statement to determine what course is removed
        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected course from ListBox
            // Remove course from student course list

            var selected0 = (Course)StudentListBox.SelectedItem;

           MessageBox.Show(selected0.getinfo());

           student1.RemoveCourse(selected0);

            StudentListBox.Items.Remove(selected0);
            ListReload();


            /////////////////////////

            //switch (selected)
            //{
            //    case "English":
            //        student1.removeccourse("English");
            //        break;

            //    case "Cpp":
            //        student1.removeccourse("Cpp");
            //        break;

            //    case "C#":
            //        student1.removeccourse("C#");
            //        break;

            //    case "Python":
            //        student1.removeccourse("Python");
            //        break;

            //    case "Data Structures":
            //        student1.removeccourse("Data Structures");
            //        break;

            //    case "Calculus":
            //        student1.removeccourse("Calculus");
            //        break;

            //    default:
            //        MessageBox.Show(selected);
            //        break;
            //}
        }

        public void BindGrid(string course)
        {
            // StudentListBox.Items.Add(student1.Getccourseinfo(course));
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
        
    }
 }
