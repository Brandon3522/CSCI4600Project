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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         RegistrationClass registrationClass = new RegistrationClass();

        XmlDocument doc = new XmlDocument();

        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";


        public MainWindow()
        {


            InitializeComponent();

            //Student student0 = new Student(0, "English", "Billy", "Bob", "Password", "Male");

            //Student student1 = new Student(1, "CS", "Tom", "Bob", "Password", "Male");

            //Course course = new Course("English", "Monday", "8:00", "English building", 4, 90);

            //Course course1 = new Course("English", "Monday", "8:00", "English building", 4, 90);

            //student0.addccourse(course);

            //student0.addccourse(course1);



            //student1.addccourse(course1);
            //student1.addccourse(course);

            //student0.addccourse(course);

            ////student2.addccourse(course1);

            //registrationClass.Addstudent(student0);
            //registrationClass.Addstudent(student1);
            //registrationClass.Addstudent(student2);
            //registrationClass.Addstudent(student3);



            //XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            //FileStream file0 = new FileStream("E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml", FileMode.Open);

            //write0.Serialize(file0, registrationClass);

            //file0.Close();


            // doc.Load(filePath);


        }



        // Navigate to Registration Window
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
        // Login to system
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Check if user is Student or Staff and open respective window
            // Check file for registration id then username and password
            // If found allow access, if not throw error

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object


            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registrationClass = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //




            if (UsernameText.Text == "" || PasswordText.Text == "")
            {
                MessageBox.Show("Please verify Username and Password", "Empty Username or Password", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //if ()
            //{

            //}

            else if (PasswordText.Text.Contains("Admin"))
            {
                    StaffWindow staffWindow = new StaffWindow();
                    staffWindow.Show();
                    this.Close();
                
            }
            else
            {
                // Check registration file for user
                // If found allow access to Student or Staff window

                



                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Close();
            }

            
        }
    }
}
