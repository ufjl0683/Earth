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
    public partial class RawDataLv2 : Page
    {
        public RawDataLv2()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            IconMenu[] IconMenus = new IconMenu[] { 
              new IconMenu(){ImgPath="/ReportIcons/Lv2/VerifyNote.png", Title="VerifyNote Table" ,Url="/Report/RawData/rptVerifyNoteTable.xaml?ReportName=VerifyNote" },
                new IconMenu(){ImgPath="/ReportIcons/Lv2/CurrentEQ.png", Title="Current EQ" ,Url="/Report/RawData/rptCurrentEQ.xaml?ReportName=CurrentEQ"  },
              new IconMenu(){ImgPath="/ReportIcons/Lv2/EQHistoty.png", Title="EQ History" ,Url="/Report/RawData/rptEQHistory.xaml?ReportName=EQHistory" },
                new IconMenu(){ImgPath="/ReportIcons/Lv2/Alarm.png", Title="Alarm" ,Url="/Report/RawData/rptAlarm.xaml?ReportName=Alarm" }
              //new IconMenu(){ImgPath="/ReportIcons/Lv1/Wafer.png",Title="Wafer"},
              //new IconMenu(){ImgPath="/ReportIcons/Lv1/Yield.png", Title="Yield"},
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
