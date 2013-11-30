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
using System.ComponentModel;

namespace slDBManager.Report
{
    public partial class ReportLv1 : UserControl
    {
        IconMenu[] IconMenus;
        public ReportLv1()
        {
            InitializeComponent();

          

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            IconMenus = new IconMenu[] { 
              new IconMenu(){ImgPath="/ReportIcons/Lv1/ProbeCard.png", Title="ProbeCard" ,Url="/Report/ProbeCardLv2.xaml" },
              new IconMenu(){ImgPath="/ReportIcons/Lv1/Wafer.png",Title="Wafer",Url="/Report/WaferLv2.xaml"},
              new IconMenu(){ImgPath="/ReportIcons/Lv1/Yield.png", Title="Yield",Url="/Report/YieldLv2.xaml"},
              new  IconMenu() {ImgPath="/ReportIcons/Lv1/RCP.png",Title="RCP",Url="/Report/RCPLv2.xaml"},
              new IconMenu() {ImgPath="/ReportIcons/Lv1/RawDataOutput.png",Title="RawDataOutput",Url="/Report/RawDataLv2.xaml"}
            
            
            
            
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
