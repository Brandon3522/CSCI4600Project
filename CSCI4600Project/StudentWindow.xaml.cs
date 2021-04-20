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
       // List<Course> courses = new List<Course>();
        Student student = new Student(0, "Computer Science", "Billy", "Bob", "Pass", "Male");
        RegistrationClass registration0 = new RegistrationClass();
        Student student1 = new Student();


        public StudentWindow()
        {
            InitializeComponent();

          //  registration0.Addstudent(student);

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //
            
            student1 = registration0.FindStudent("Billy");

            ListReload();


            //// Save RegistrationClass object to xml file
            //XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            //FileStream file0 = System.IO.File.Create("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml");

            //write0.Serialize(file0, registration0);

            //file0.Close();
            //////////////////////

            // FileStream file0 = System.IO.File.Create("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml");

            // write0.Serialize(file0, registrationClass);

            //  file0.Close();


            // BindGrid(C);



        }
        // Logout from system
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml");

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
            // Save RegistrationClass object to xml file
            XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

            FileStream file0 = System.IO.File.Create("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml");

            write1.Serialize(file0, registration0);

            file0.Close();
            ////////////////////
            AccountInfoStudent accountInfoStudent = new AccountInfoStudent();
            accountInfoStudent.Show();
            this.Close();
        }

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


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // remove deleted course from student
            // how to get course name from dataGrid
            // MessageBox.Show("Deleted");

            string info = student.Getccoursesinfo();
;            MessageBox.Show(info);

        }

        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected course from Data Grid
            // Remove course from student course list
            //var selectedItem = DataStudent.SelectedItem;
            //DataStudent.Items.Remove(selectedItem);

            var selected = (string)StudentListBox.SelectedItem;

            //  MessageBox.Show((string)selected);

            bool b = selected.Contains("Cpp");


            if (b)
            {
                student1.removeccourse("Cpp");
                MessageBox.Show("IF");
            }

           // student.removeccourse("Cpp");

           //  StudentListBox.Selected

            StudentListBox.Items.Remove(selected);

          //  student.removeccourse((string)selected);

            ListReload();       

        }

        public void BindGrid(string course)
        {
            //courses.Add(new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 0));
            //string[] courses = student.Getccoursesinfo();
            StudentListBox.Items.Add(student1.Getccourseinfo(course));



        }

        public void ListReload()
        {
            StudentListBox.Items.Clear();



            StudentListBox.Items.Add(student1.Getccoursesinfo());
        }
        


        //public string LoadCourses()
        //{
        //    List<Course> courses = new List<Course>();
        //    courses.Add(new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 0));
        //    return courses;
        //}
    }
    }
