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

namespace slDBManager.Report
{
    public partial class WaferLv2 : Page
    {
        public WaferLv2()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            IconMenu[] IconMenus = new IconMenu[] { 
            new IconMenu(){ImgPath="/ReportIcons/Lv2/PerformanceIndex.png", Title="Performance Index" ,Url="/Report/Wafer/rptPerformanceIndex.xaml?ReportName=PerformanceIndex" },
              new IconMenu(){ImgPath="/ReportIcons/Lv2/RCPProductivity.png",Title="RCP Productivity",Url="/Report/Wafer/rptRCPProductivity.xaml?ReportName=RCPProductivity" },
              new IconMenu(){ImgPath="/ReportIcons/Lv2/CurrentWIP.png", Title="Current WIP",Url="/Report/Wafer/rptCurrentWIP.xaml?ReportName=CurrentWIP"},
           
            
            
            
            
            };
            // System.Collections.ObjectModel.ObservableCollection<IconMenu> colection = new System.Collections.ObjectModel.ObservableCollection<IconMenu>(IconMenus);
            this.lstMenu.ItemsSource = IconMenus;


        }
        WrapPanel wrapanel;
        private void wrapPanel_Loaded(object sender, RoutedEventArgs e)
        {
            wrapanel = sender as WrapPanel;
            lstMenu_SizeChanged(null, null);
        }

        private void lstMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (wrapanel != null)
                wrapanel.Width = lstMenu.ActualWidth;
        }
    }
}
