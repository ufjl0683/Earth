using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.webBrowser1.Navigate(System.AppDomain.CurrentDomain.BaseDirectory+"NextLot.htm");
            this.webBrowser1.DocumentText = "<html><body  bgcolor=\"pink\"></body></html>";
        }
    }
}
