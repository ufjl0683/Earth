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
using slAmidaConsole.AmidaService;
//using slDBManager.AmidaService;

namespace slAmidaConsole
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
            wafer.Loaded += new RoutedEventHandler(wafer_Loaded);
        }

        void wafer_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
           
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            wafer.DataContext = new RegisterDeviceInfo()
            {
                 Progress=10,
                  Status="Idle",
                   TimeRemain=0,
                    WarningMessage=""
            };
            RegisterDeviceInfo[] datas = new RegisterDeviceInfo[] { wafer.DataContext as RegisterDeviceInfo };
            listBox1.ItemsSource = datas;
            wafer.BindingChanged();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            (wafer.DataContext as RegisterDeviceInfo).Status = "Product";
        }

        private void Wafer_Loaded_1(object sender, RoutedEventArgs e)
        {
            (sender as Wafer).BindingChanged();
        }



    }
}
