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
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        RegistrationClass registration0 = new RegistrationClass();
        Staff staff = new Staff();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        public StaffWindow()
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
            staff = registration0.FindStaff(userName);
            //

            // Add students to List box
            foreach (var item in registration0.students)
            {
                StudentsList.Items.Add(item);
            }
            //

        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString();
        }

        void timer_Tick1(object sender, EventArgs e)
        {
            LiveTimeLabel_Copy.Content = DateTime.Now.ToString("HH:mm:ss");
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

            AccountInfoStaff accountInfoStaff = new AccountInfoStaff();
            accountInfoStaff.Show();
            this.Close();
        }
        // Logout
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
        // Remove student from Data Grid
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify this is the student to be removed
            // Remove student from StudentListDataGrid
            // Remove student from Registration list

            var selected = (Student)StudentsList.SelectedItem;

            MessageBox.Show(selected.ToString());

            registration0.removeStudent(selected);

            StudentsList.Items.Clear();

            try
            {
                foreach (var item in registration0.DisplayStudents())
                {
                    StudentsList.Items.Add(item);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Exception: " + a.Message);
                throw new Exception(a.Message);
            }


        }
    }
}
