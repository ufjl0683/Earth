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

namespace slAmidaConsole
{
    public partial class cldSendMessage : ChildWindow
    {

        public string Message
        {
            get
            {
                string res = "";
                if (this.optNextLot.IsChecked == true)
                {
                    res = "N"; //normal
                    
                    res += "\t"+txtMask.Text.Trim() + "-";
                    res +=  txtLot.Text.Trim()+"-";//     + "lot:" + txtLot.Text + "\n"
                    res +=   txtWafer.Text + "\r\n";//       + "wafer:" + txtWafer.Text + "\n"
                    res += (txtPC.Text.Trim() == "") ? "\t-" : "\t" + txtPC.Text + "-";        //       + "PC:" + txtPC.Text + "\n"
                    res += (txtShape.Text.Trim() == "") ? "\r\n" :  txtShape.Text + "\r\n";   //       + "Shape:" + txtShape.Text + "\n"
                    res += (txtTestVerify.Text.Trim() == "") ? "\r\n" : "\t" + txtTestVerify.Text + "\r\n";  //       + "Test/Verify:" + txtTestVerify + "\n";
                }
                else
                {
                    res = "O"+this.txtOthers.Text; //oher;
                  //  return this.txtOthers.Text;
                }
                return res;

            }
        }
        public cldSendMessage()
        {
            InitializeComponent();
            this.txtTestVerify.ItemsSource = new string[] { "Test", "Verify" };
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void txtTestVerify_GotFocus(object sender, RoutedEventArgs e)
        {
            this.optNextLot.IsChecked = true;
        }

        private void txtOthers_GotFocus(object sender, RoutedEventArgs e)
        {
            this.optOthers.IsChecked = true;
        }
    }
}

