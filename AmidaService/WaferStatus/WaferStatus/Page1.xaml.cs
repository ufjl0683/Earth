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
using System.Windows.Navigation;

namespace WaferStatus
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void sleep_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           // VisualStateManager.GoToState(this, "sleeping", true);
            //this.wafer.
            wafer.SetStatus("Idle");
        }
        private void testting_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	//VisualStateManager.GoToState(this,"testting", true);
            wafer.SetStatus("Product");
        }

        private void damage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	//VisualStateManager.GoToState(this, "damage", true);
            wafer.SetStatus("Verify");
        }

        private void fax_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	//VisualStateManager.GoToState(this, "fax", true);
            wafer.SetStatus("LEM");
        }

        bool pause_check_staus = false;
        private void pause_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (pause_check_staus == false)
            //{
            //    wafer.SetStatus(5);
            // ////   pause_check_staus = true;
            //}
            //else {
            //    wafer.SetStatus(6);
            // //   pause_check_staus = false;
            //}

           // wafer.set

            if (pause_check_staus == false)
            {
                wafer.SetWarning("Alarm");
                pause_check_staus = true;
            }
            else
            {
                wafer.SetWarning("");
                pause_check_staus = false;
            }
        }



    }
}
