﻿using System;
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
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        RegistrationClass registration0 = new RegistrationClass();
        string filePath = "E:\\Spring 2021\\CSCI 4600\\Project\\CSCI4600Project\\CSCI4600Project\\Data.xml";

        public StaffWindow()
        {
            InitializeComponent();

            // Open file and deserialze to RegistrationClass object

            XmlSerializer write0 = new XmlSerializer(typeof(RegistrationClass));

            FileStream filestream = new FileStream(filePath, FileMode.Open);

            registration0 = (RegistrationClass)write0.Deserialize(filestream);

            filestream.Close();
            //

            foreach (var item in registration0.students)
            {
                StudentsList.Items.Add(item);
            }
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
