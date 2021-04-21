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
    /// Interaction logic for AccountInfoStudent.xaml
    /// </summary>
    public partial class AccountInfoStudent : Window
    {
        // Needs to bind completed courses to CompletedClasses list box
        Student student = new Student(0, "Computer Science", "Billy", "Bob", "Pass", "Male");
        List<Course> courses = new List<Course>();

        RegistrationClass registration0 = new RegistrationClass();
        Student student1 = new Student();
       

        public AccountInfoStudent()
        {
            InitializeComponent();

            // Open file and deserialze to RegistrationClass object
            string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //

            // Replace FindStudent name with currently logged in user **********************
            // Check file for FirstName that matches the logged in user
            string userName = "Tom";
            student1 = registration0.FindStudent(userName);

            // add some finished courses for testing
            Course C = new Course("English", "Mondays and tuesdays", "8:00", "English building", 4, 90);
            Course B = new Course("C++", "Mondays and tuesdays", "8:00", "CS building", 4, 90);
            student1.addfcourse(C);
            student1.addfcourse(B);

            // populate course list with finished courses
            CompletedClasses.Items.Add(student1.Getfcoursesinfo());
            


            //Course CSharp = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            //Course C = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            //Course Cd = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 0);
            //courses.Add(CSharp);
            //courses.Add(C);
            //courses.Add(Cd);

            //foreach (var Ca in courses)
            //{
            //    CompletedClasses.Items.Add(Ca);
            //}

            // List Box

            //Course English = new Course("English", "Mondays and tuesdays", "8:00", "English building", 4, 90);
            //Course CSharp0 = new Course("C#", "Mondays and tuesdays", "8:00", "CS building", 4, 86);
            //Course Cpp = new Course("Cpp", "Mondays and tuesdays", "8:00", "CS building", 4, 94);

            //student.addfcourse(English);
            //student.addfcourse(CSharp0);
            //student.addfcourse(Cpp);

            //StudentfCourseList.Items.Add(student.Getfcoursesinfo()) ;

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
