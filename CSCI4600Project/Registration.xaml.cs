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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        RegistrationClass registration = new RegistrationClass();

        
        public Registration()
        {
            InitializeComponent();
            
            

            IDLabel.Content = 0;
            

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
                    MessageBox.Show("Student registered", "Registration successful", MessageBoxButton.OK);
                }
                else
                {
                    // need to add user to file
                    Staff staff = new Staff(registrationID, Fname, Lname);
                    registration.AddStaff(staff);
                    MessageBox.Show("Staff registered", "Registration successful", MessageBoxButton.OK);
                }

            }

        }


    }
}
