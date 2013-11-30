using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace slDBManager.ControlForms
{
    public partial class chldDownSubStatusChoice : ChildWindow
    {
        public string Result;
        public chldDownSubStatusChoice()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Content.ToString().Trim().StartsWith("TP"))
                Result = "TP";
            else if ((sender as RadioButton).Content.ToString().Trim().StartsWith("P"))
                Result = "P";
            else
                Result = "T";

        }
    }
}

