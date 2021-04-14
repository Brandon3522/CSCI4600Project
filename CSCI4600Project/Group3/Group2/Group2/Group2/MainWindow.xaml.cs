//Group 2: Jasmine Sager-Gonzalez, Brandon Sitz, Weston Abner
//CSCI 3005-12
//Fall 2020
//Final Project

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Group2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Registration, Courses, RegistrationView
        Registration register = new Registration();
        Courses course;

        //Submit Course Registration
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            if (studentId.Text == "" || firstName.Text == "" || lastName.Text == "" )
            {
                MessageBox.Show("Error! Please enter valid student information");
                return;
            }

            //Student list
            course = new Courses(course1.Text, course2.Text, course3.Text, course4.Text);

            //Add to registration
            register.AddRegistration(course);

            //Add to list box
            RegisteredListBox.Items.Add(course.GetInfo());

            //Clear text boxes
            course1.Clear();
            course2.Clear();
            course3.Clear();
            course4.Clear();
        }

        //Delete Course
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

            if (removeCourse.Text == "")
            {
                MessageBox.Show("Error! Please enter a course to remove");
                return;
            }
            
            course.removecourse(removeCourse.Text);
            RegisteredListBox.Items.Clear();
            RegisteredListBox.Items.Add(course.GetInfo());
            removeCourse.Clear();
        }
    }
}
