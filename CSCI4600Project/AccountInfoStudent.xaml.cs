﻿using System;
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
    /// Interaction logic for AccountInfoStudent.xaml
    /// </summary>
    public partial class AccountInfoStudent : Window
    {
        public AccountInfoStudent()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.Show();
            this.Close();
        }
    }
}
