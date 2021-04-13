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
        public StudentWindow()
        {
            InitializeComponent();
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



        }

        private void RemoveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected course from Data Grid
            // Remove course from student course list



        }
    }
}
