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
        RegistrationClass registration = new RegistrationClass();
        Staff staff = new Staff();
        string filePath = "./Data.xml";

        public AccountInfoStaff()
        {
            InitializeComponent();

            //////////////// XML ////////////////////
            // Open file and deserialze to RegistrationClass object
            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //////////////// XML ////////////////////

            // Check file for FirstName that matches the logged in user
            string userName = "";
            userName = registration.getUserLoggedIn();
            staff = registration.FindStaff(userName);


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
            // Verfiy information isn't blank
            if (FirstNameText.Text == "" || LastNameText.Text == "" || PassText.Text == ""
                || MaleRadioButton.IsChecked == false && FemaleRadioButton.IsChecked == false)
            {
                MessageBox.Show("Please input all information.", "Invalid information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Gather and update account information
            else
            {
                string firstNameUpdate = FirstNameText.Text.ToLower();
                string lastNameUpdate = LastNameText.Text;
                string passwordUpdate = PassText.Text;
                string genderUpdate = "";

                if (MaleRadioButton.IsChecked == true)
                {
                    genderUpdate = "Male";
                }
                else
                {
                    genderUpdate = "Female";
                }

                // Update staff in staff registration list
                registration.UpdateStaff(staff, firstNameUpdate, lastNameUpdate, passwordUpdate, genderUpdate);

                //////////////// XML ////////////////////
                // Save RegistrationClass object to xml file
                XmlSerializer write1 = new XmlSerializer(typeof(RegistrationClass));

                FileStream file0 = System.IO.File.Create(filePath);

                write1.Serialize(file0, registration);

                file0.Close();
                //////////////// XML ////////////////////

                // Update currently logged in user to new first name
                //registration.UserLoggedIn(student.FirstName);

                MessageBox.Show("Information updated.", "Update Successful", MessageBoxButton.OK);

            }


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
