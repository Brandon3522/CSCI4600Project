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

          //  registration0.Addstudent(student);

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object


            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //

            // Replace FindStudent name with currently logged in user **********************
            // Check file for FirstName that matches the logged in user
            string userName = "John";
            student1 = registration0.FindStudent(userName);

            ListReload();
            // BindGrid(C);


            //// Save RegistrationClass object to xml file
            //XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            //FileStream file0 = System.IO.File.Create("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml");

            //write0.Serialize(file0, registration0);

            //file0.Close();
            //////////////////////

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
                Course Cpp = new Course("Cpp", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
                student1.addccourse(Cpp);
                BindGrid(Cpp.cname);

            }

            if (CourseList.Text == "C#")
            {
                Course CSharp = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
                student1.addccourse(CSharp);
                BindGrid(CSharp.cname);

            }

            if (CourseList.Text == "Python")
            {
                Course Python = new Course("Python", "Mondays and tuesdays", "11:00", "CS building", 4, 0);
                student1.addccourse(Python);
                BindGrid(Python.cname);

            }

            if (CourseList.Text == "Calculus")
            {
                Course Calculus = new Course("Calculus", "Mondays and tuesdays", "1:00", "CS building", 4, 0);
                student1.addccourse(Calculus);
                BindGrid(Calculus.cname);

            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // remove deleted course from student
            // how to get course name from dataGrid
            // MessageBox.Show("Deleted");

            //string info = student.Getccoursesinfo();
            //MessageBox.Show(info);

        }

        // switch statement to determine what course is removed
        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected course from ListBox
            // Remove course from student course list

           // var selected = (string)StudentListBox.SelectedItem;
            //   var selected = StudentListBox.SelectedItem;

            //////////////////////// new method
            var selected0 = (Course)StudentListBox.SelectedItem;
            // selected0 = Course object


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

            //bool cpp = selected.Contains("Cpp");
            //bool english = selected.Contains("English");
            //bool c = selected.Contains("C#");
            //bool python = selected.Contains("Python");
            //bool dataStructures = selected.Contains("Data Structures");
            //bool calculus = selected.Contains("Calculus");

            //if (cpp)
            //{
            //    student1.removeccourse("Cpp");
            //}
            //if (english)
            //{
            //    student1.removeccourse("English");
            //}
            //if (c)
            //{
            //    student1.removeccourse("C#");
            //}
            //if (python)
            //{
            //    student1.removeccourse("Python");
            //}
            //if (dataStructures)
            //{
            //    student1.removeccourse("Data Structures");
            //}
            //if (calculus)
            //{
            //    student1.removeccourse("Calculus");
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


            

        //    try
        //    {
        //        for (int i = 0; i < student1.CourseList().Count; i++)
        //        {
        //            StudentListBox.Items.Add(student1.Getccourseinfo(course)); 
        //        }

        //        foreach (var item in CourseList)
        //        {
        //            StudentListBox.Items.Add(item);
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception("Oh No, Exception: " + e.Message);
        //    }

         }

        public void ListReload()
        {
            StudentListBox.Items.Clear();

            //  StudentListBox.Items.Add(student1.Getccoursesinfo());

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
            
            //   StudentListBox.Items.Add(student1.Getccoursesinfo());
        }
        


        //public string LoadCourses()
        //{
        //    List<Course> courses = new List<Course>();
        //    courses.Add(new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 0));
        //    return courses;
        //}
    }
    }
