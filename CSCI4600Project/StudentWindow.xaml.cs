using System;
using System.Collections.Generic;
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

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
       // List<Course> courses = new List<Course>();
        Student student = new Student(0, "Computer Science", "Billy", "Bob", "Pass", "Male");
        RegistrationClass registration = new RegistrationClass();
        public StudentWindow()
        {
            InitializeComponent();

            registration.Addstudent(student);

            

           // BindGrid(C);

            

        }
        // Logout from system
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        // View account information
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountInfoStudent accountInfoStudent = new AccountInfoStudent();
            accountInfoStudent.Show();
            this.Close();
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Add selected course from comboBox into DataStudent Data Grid
            // Add selected course to student course list

            if (CourseList.Text == "Cpp")
            {
                Course Cpp = new Course("Cpp", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
                student.addccourse(Cpp);
                BindGrid(Cpp.cname);

            }

            if (CourseList.Text == "C#")
            {
                Course CSharp = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
                student.addccourse(CSharp);
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
                student.removeccourse("Cpp");
                MessageBox.Show("IF");
            }

           // student.removeccourse("Cpp");

           //  StudentListBox.Selected

            StudentListBox.Items.Remove(selected);

          //  student.removeccourse((string)selected);

            ListReload();

            //try
            //{
            //    var selectedItem = DataStudent.SelectedIndex;
            //    DataStudent.Items.Remove(selectedItem);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            


        }

        public void BindGrid(string course)
        {
            //courses.Add(new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 0));
            //DataStudent.ItemsSource = courses;

            //string[] courses = student.Getccoursesinfo();
            
            StudentListBox.Items.Add(student.Getccourseinfo(course));

            DataStudent.ItemsSource = student.Getccoursesinfo();

        }

        public void ListReload()
        {
            StudentListBox.Items.Clear();

            StudentListBox.Items.Add(student.Getccoursesinfo());
        }
        


        //public string LoadCourses()
        //{
        //    List<Course> courses = new List<Course>();
        //    courses.Add(new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 0));
        //    return courses;
        //}
    }
    }
