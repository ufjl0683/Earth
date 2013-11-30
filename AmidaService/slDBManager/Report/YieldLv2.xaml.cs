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
    public partial class YieldLv2 : Page
    {
        public YieldLv2()
        {
            InitializeComponent();
            
        }

        // 使用者巡覽至這個頁面時執行。
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            IconMenu[] IconMenus = new IconMenu[] { 
            //  new IconMenu(){ImgPath="/ReportIcons/Lv2/TouchDown.png", Title="TouchDown" ,Url="/Report/ProbeCard/rptTouchDown.xaml?ReportName=TouchDown" },
              new IconMenu(){ImgPath="/ReportIcons/Lv2/YieldVSOP.png", Title=" Yield VS OP" ,Url="/Report/Yield/rptYieldVSOP.xaml?ReportName=YieldVSOP" },
               new IconMenu(){ImgPath="/ReportIcons/Lv2/YieldVSRCP.png", Title=" Yield VS RCP" ,Url="/Report/Yield/rptYieldVSRCP.xaml?ReportName=YieldVSRCP" },
               new IconMenu(){ImgPath="/ReportIcons/Lv2/YieldVSPC.png", Title=" Yield VS PC" ,Url="/Report/Yield/rptYeildVSPC.xaml?ReportName=YieldVSPC" }
             //new  IconMenu() {ImgPath="/ReportIcons/Lv1/RCP.png",Title="RCP"},
              //new IconMenu() {ImgPath="/ReportIcons/Lv1/RawDataOutput.png",Title="RawDataOutput"}
            
            
            
            
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
