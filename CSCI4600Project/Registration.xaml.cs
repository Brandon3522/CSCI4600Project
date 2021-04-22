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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegistrationClass registration = new RegistrationClass();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        public Registration()
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

            ///////////// load xml
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            ////////////

        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString();
        }

        void timer_Tick1(object sender, EventArgs e)
        {
            LiveTimeLabel_Copy.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        // Return to Login
        private void LoginScreen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Verify all information inputted
            // Take user information and create Student or Staff based on selection
            // Add the user to the Registration
            // User should now be able to log in
            if (FirstNameText.Text == "" || LastNameText.Text == "" || PasswordText.Text == "" 
                || MaleRadio.IsChecked == false && FemaleRadio.IsChecked == false
                || StudentCheck.IsChecked == false && StaffCheck.IsChecked == false)
            {
                MessageBox.Show("Please input all information", "Invalid information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                // registrationID needs more work
                int registrationID = 0;
                string gender = "";
                string Fname = FirstNameText.Text;
                string Lname = LastNameText.Text;
                string pass = PasswordText.Text;
                string major = MajorComboBox.Text;

                if (MaleRadio.IsChecked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                
                if (StudentCheck.IsChecked == true)
                {
                    // need to add user to file
                    Student student = new Student(registrationID, major, Fname, Lname, pass, gender);
                    registration.Addstudent(student);

                    //////////////////// Save RegistrationClass object to xml file
                    XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                    FileStream file0 = new FileStream(filePath, FileMode.OpenOrCreate);

                    write1.Serialize(file0, registration);

                    file0.Close();
                    ////////////////////

                    MessageBox.Show("Student registered", "Registration successful", MessageBoxButton.OK);
                }
                else
                {
                    // need to add user to file
                    Staff staff = new Staff(registrationID, Fname, Lname, gender);
                    registration.AddStaff(staff);

                    //////////////////// Save RegistrationClass object to xml file
                    XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                    FileStream file0 = new FileStream(filePath, FileMode.OpenOrCreate);

                    write1.Serialize(file0, registration);

                    file0.Close();
                    ////////////////////

                    MessageBox.Show("Staff registered", "Registration successful", MessageBoxButton.OK);
                }

            }

        }


    }
}
