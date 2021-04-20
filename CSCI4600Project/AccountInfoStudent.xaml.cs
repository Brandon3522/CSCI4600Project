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
    /// Interaction logic for AccountInfoStudent.xaml
    /// </summary>
    public partial class AccountInfoStudent : Window
    {
        // Needs to bind completed courses to CompletedClasses list box
        Student student = new Student(0, "Computer Science", "Billy", "Bob", "Pass", "Male");

        List<Course> courses = new List<Course>();
        
       

        public AccountInfoStudent()
        {
            InitializeComponent();

            Course CSharp = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            Course C = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            Course Cd = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            courses.Add(CSharp);
            courses.Add(C);
            courses.Add(Cd);

            foreach (var Ca in courses)
            {
                CompletedClasses.Items.Add(Ca);
            }

            // List Box

            Course English = new Course("English", "Mondays and tuesdays", "8:00", "English building", 4, 90);
            Course CSharp0 = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 86);
            Course Cpp = new Course("Cpp", "Mondays and tuesdays", "8:00", "CS building", 4, 94);

            student.addfcourse(English);
            student.addfcourse(CSharp0);
            student.addfcourse(Cpp);

            StudentfCourseList.Items.Add(student.Getfcoursesinfo()) ;

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
