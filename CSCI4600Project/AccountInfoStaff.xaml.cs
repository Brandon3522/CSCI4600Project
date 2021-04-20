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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSCI4600Project
{
    /// <summary>
    /// Interaction logic for AccountInfoStaff.xaml
    /// </summary>
    public partial class AccountInfoStaff : Window
    {
        // Bind student registration list to StudentList

        public AccountInfoStaff()
        {
            InitializeComponent();
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
