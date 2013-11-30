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
using System.ServiceModel.DomainServices.Client;
using slAmidaConsole.Web;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Browser;
using System.Windows.Media.Imaging;

namespace slDBManager.Report.ProbeCard
{
    public partial class rptTouchDown : Page
    {
        public rptTouchDown()
        {
            InitializeComponent();
            HideControlPanel();
        }
        bool IsShowChart = false;
        bool isQueryShow = false;
        void HideControlPanel()
        {
            foreach (UIElement elem in this.ControlPanel.Children)
            {
                if (elem.GetValue(Canvas.NameProperty).ToString() != "btnQuery")
                    elem.Visibility = System.Windows.Visibility.Collapsed;

            }
            this.ControlPanel.Background = new SolidColorBrush(Colors.Transparent);

        }
        void ShowControlPanel()
        {
            foreach (UIElement elem in this.ControlPanel.Children)
            {
                if (elem.GetValue(Canvas.NameProperty).ToString() != "btnQuery")
                    elem.Visibility = System.Windows.Visibility.Visible;

            }
            this.ControlPanel.Background = new SolidColorBrush(Color.FromArgb(255,0xf8,0xf5,0xf5));
        }
        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string ReportName = this.NavigationContext.QueryString["ReportName"].ToString();
            this.btnQuery.Content = ReportName;
            this.Icon.Source =new BitmapImage(new Uri(string.Format( "/ReportIcons/Lv2/{0}.png",ReportName), UriKind.Relative));
        }
        
      
        public void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            if (this.isQueryShow)
            {
                this.LayoutRoot.SetValue(Grid.MarginProperty, new Thickness(0, 137, 0, 0));
             //   this.ControlPanel.Visibility = System.Windows.Visibility.Collapsed;
                ShowControlPanel();
                this.UpdateLayout();
                
                //this.stbQueryHide.Stop();
               // stbQueryHide.Begin();
            }
            else
            {
                this.LayoutRoot.SetValue(Grid.MarginProperty, new Thickness(0, 0, 0, 0));
                HideControlPanel();
              //  this.ControlPanel.Visibility = System.Windows.Visibility.Visible;
               // this.ChartPanel.Visibility = System.Windows.Visibility.Visible;
                //this.stbQueryShow.Stop();
                //this.stbQueryShow.Begin();
              //  this.LayoutRoot.UpdateLayout();
            }
            isQueryShow = !isQueryShow;
        }
        private void chkShowChart_Checked(object sender, RoutedEventArgs e)

        {
          //  this.border.Visibility = System.Windows.Visibility.Collapsed;
            this.IsShowChart = true;
            Grid.SetRow(this.dataGrid1, 0);
            Grid.SetColumn(this.dataGrid1, 0);
            Grid.SetColumnSpan(this.dataGrid1, 1);
            GridSplitter.Visibility = System.Windows.Visibility.Visible;
          //  this.border.Visibility = System.Windows.Visibility.Visible;
           // this.LayoutRoot.UpdateLayout();
         //   this.dataGrid1.UpdateLayout();
           
           //  this.border.SetValue(Grid.MarginProperty,new Thickness(0));
           // stbShowChart.Begin();
        }

        private void chkShowChart_Unchecked(object sender, RoutedEventArgs e)
        {
            this.IsShowChart = false;
            Grid.SetRow(this.dataGrid1, 0);
            Grid.SetColumn(this.dataGrid1, 0);
            
            Grid.SetColumnSpan(this.dataGrid1, 2);
            this.LayoutRoot.UpdateLayout();
            GridSplitter.Visibility = System.Windows.Visibility.Collapsed;
      //      this.LayoutRoot.UpdateLayout();
         //   this.border.Visibility = System.Windows.Visibility.Collapsed;
            //stbHideChart.Begin();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {

            string wherestr="";
            slAmidaConsole.Web.EQ_DomainContext client =new EQ_DomainContext();


            //var q = from n in client.GetTblVerifyNoteQuery() where n.StartTimes == new DateTime(2013, 1, 1) select n; ;
            //client.Load(q);
           
            if (txtPCMASK.Text.Trim() != "")
                wherestr += " it.PCID like '" + txtPCMASK.Text + "%' and";



            if (txtPCShape.Text.Trim() != "")
            {
                int res;

                if (!int.TryParse(txtPCShape.Text,out res))
                {
                    MessageBox.Show("ProbeShape must be integer!");
                    return;

                }
                wherestr += " it.ProbeShape=" + txtPCShape.Text.Trim() + " and";


            }
            int datecnt = 0;
            if (txtStartDate.Text.Trim() != "" && txtStopDate.Text.Trim() != "")
            {
                DateTime res;
                if (!DateTime.TryParse(txtStartDate.Text.Trim(), out res))
                {
                    MessageBox.Show("Start Date format error!");
                    return;
                }
                if (!DateTime.TryParse(this.txtStopDate.Text.Trim(), out res))
                {
                    MessageBox.Show("End Date format error!");
                    return;
                }
                datecnt = 2;
                wherestr += string.Format("  it.StartTimes >= @p0 and it.StartTimes <@p1 and it.stoptimes >=@p0 and it.stoptimes <@p1  and"); 
            }
            else if (txtStartDate.Text.Trim() != "" && txtStopDate.Text.Trim() == "")
            {
                DateTime res;
                if (!DateTime.TryParse(txtStartDate.Text.Trim(), out res))
                {
                    MessageBox.Show("Start Date format error!");
                    return;
                }
                datecnt = 1;
                wherestr += string.Format("  it.StartTimes >= @p0   and"); 

            }
            else if (txtStartDate.Text.Trim() == "" && txtStopDate.Text.Trim() != "")
            {
                DateTime res;
                if (!DateTime.TryParse(txtStartDate.Text.Trim(), out res))
                {
                    MessageBox.Show("Start Date format error!");
                    return;
                }
                datecnt = 1;
                wherestr += string.Format("  it.stoptimes < @p1   and");

            }
 



           wherestr= wherestr.TrimEnd(new char[] { 'a', 'n', 'd' });


           Uri uri;
             
            InvokeOperation<slAmidaConsole.Web.RptSchema.RptTouchDownSchema[]> lo=null;
            if (datecnt == 2)
            {
                lo = client.GetTouchDownTotalBySql(wherestr, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtStopDate.Text));
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=1&wherestr="+wherestr+"&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + txtStopDate.Text.Trim());
            }
            else if (datecnt == 1)
            {
                if(txtStartDate.Text.Trim()=="")
                {
                    lo = client.GetTouchDownTotalBySql(wherestr, DateTime.MinValue, DateTime.Parse(txtStopDate.Text));
                    uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=1&wherestr=" + wherestr + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
            
                }
                else
                 {
                lo = client.GetTouchDownTotalBySql(wherestr, DateTime.Parse(txtStartDate.Text), DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=1&wherestr="+wherestr+"&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
                  }
            }
            else
            {
                lo = client.GetTouchDownTotalBySql(wherestr, DateTime.MinValue, DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=1&wherestr="+wherestr +"&starttimes=" + DateTime.MinValue.ToShortDateString() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
            
            }
            this.BusyIndicator1.IsBusy = true;
            lo.Completed += (s, a) =>
                {
                    this.BusyIndicator1.IsBusy = false ;
                    this.dataGrid1.ItemsSource = lo.Value;
                    if(IsShowChart)
                        (this.chart1.Series[0] as ColumnSeries).ItemsSource = lo.Value;
                };

            HtmlWindow html = HtmlPage.Window;
            if (chkDownload.IsChecked == true)
            {
               // MessageBox.Show(uri.ToString());
                 
                html.Navigate(uri);
            }
           // WebClient webclient = new WebClient();
          //  webclient.OpenReadAsync(uri);
           // Uri uri = App.Current.Host.Source.MakeRelativeUri("../../DownloadForm.aspx");
          //  webclient.OpenReadAsync(new Uri().);
           

        //   var exp = PredicateBuilder.True<tblVerifyNote>().And<tblVerifyNote>(n=>n.StartTimes>=new DateTime(2013,4,16));
          
         // exp = exp.And<tblVerifyNote>(n => n.StartTimes >= new DateTime(2013, 4, 16) && n.StartTimes <= new DateTime(2013, 4, 16));

            //EntityQuery<slAmidaConsole.Web.> q
            // = client.GetTblVerifyNoteBySqlQuery("").Take(3600);
             //  client.GetTblVerifyNoteQuery().Where<tblVerifyNote>(n=>n.PCID.StartsWith("AE385"));


           // LoadOperation<slAmidaConsole.Web.tblVerifyNote> lo
           //     = client.Load<slAmidaConsole.Web.tblVerifyNote>(q);
           //// EntityQuery<tblVerifyNote> lo1 = client.GetTblVerifyNoteBySqlQuery("it.PCID like 'AE385%'");
           

           // lo.Completed += (s, a) =>
           //     {
           //         if (lo.HasError)
           //         {
           //             MessageBox.Show(lo.Error.Message);
           //             return;
           //         }
           //         this.dataGrid1.ItemsSource = lo.Entities;
           //     };
           
        }

         
       

        

    }
}
