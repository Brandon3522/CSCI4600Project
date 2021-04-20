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
        

        public MainWindow()
        {
            InitializeComponent();
            string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";
            doc.Load(filePath);
            //((App)Application.Current).
        }



        // Navigate to Registration Window
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
        // Login to system
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Check if user is Student or Staff and open respective window
            // Check file for registration id then username and password
            // If found allow access, if not throw error

            if (UsernameText.Text == "" || PasswordText.Text == "")
            {
                MessageBox.Show("Please verify Username and Password", "Empty Username or Password", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Check registration file for user
                // If found allow access to Student or Staff window
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Hide();
            }

            
        }
    }
}
