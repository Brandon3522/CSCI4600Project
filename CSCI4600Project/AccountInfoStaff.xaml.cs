using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for AccountInfoStaff.xaml
    /// </summary>
    public partial class AccountInfoStaff : Window
    {
        // Bind student registration list to StudentList
        RegistrationClass registration0 = new RegistrationClass();
        Staff staff = new Staff();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        public AccountInfoStaff()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration0.getUserLoggedIn();
            staff = registration0.FindStaff(userName);


            // Populate account info with Staff info
            FirstNameText.Text = userName;
            LastNameText.Text = staff.GetLastName();

            // Assign saved gender
            if (staff.GetGender() == "Male")
            {
                MaleRadioButton.IsChecked = true;
            }
            else
            {
                FemaleRadioButton.IsChecked = true;
            }

            PassText.Text = "Admin";
        }

        // Update account info
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Verfiy info isnt empty
            // Message box to verify
            // Update Staff information


        }
        // Navigate to Main Window
        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            StaffWindow staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }
    }
}
