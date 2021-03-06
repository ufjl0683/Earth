﻿using System;
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
using System.Windows.Media.Imaging;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Browser;
using slAmidaConsole.Web;

namespace slDBManager.Report.RCP
{
    public partial class rptRCPStatusIndex : Page
    {
        public rptRCPStatusIndex()
        {
            InitializeComponent();
            HideControlPanel();
        }

        // 使用者巡覽至這個頁面時執行。
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
            this.ControlPanel.Background = new SolidColorBrush(Color.FromArgb(255, 0xf8, 0xf5, 0xf5));
        }
        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string ReportName = this.NavigationContext.QueryString["ReportName"].ToString();
            this.btnQuery.Content = ReportName;
            this.Icon.Source = new BitmapImage(new Uri(string.Format("/ReportIcons/Lv2/{0}.png", ReportName), UriKind.Relative));
        }


        public void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            if (this.isQueryShow)
            {
                this.LayoutRoot.SetValue(Grid.MarginProperty, new Thickness(0, 137, 0, 0));

                ShowControlPanel();
                this.UpdateLayout();


            }
            else
            {
                this.LayoutRoot.SetValue(Grid.MarginProperty, new Thickness(0, 0, 0, 0));
                HideControlPanel();

            }
            isQueryShow = !isQueryShow;
        }
        private void chkShowChart_Checked(object sender, RoutedEventArgs e)
        {

            this.IsShowChart = true;
            Grid.SetRow(this.dataGrid1, 0);
            Grid.SetColumn(this.dataGrid1, 0);
            Grid.SetColumnSpan(this.dataGrid1, 1);
            GridSplitter.Visibility = System.Windows.Visibility.Visible;

        }

        private void chkShowChart_Unchecked(object sender, RoutedEventArgs e)
        {
            this.IsShowChart = false;
            Grid.SetRow(this.dataGrid1, 0);
            Grid.SetColumn(this.dataGrid1, 0);

            Grid.SetColumnSpan(this.dataGrid1, 2);
            this.LayoutRoot.UpdateLayout();
            GridSplitter.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            slAmidaConsole.Web.EQ_DomainContext db = new slAmidaConsole.Web.EQ_DomainContext();
            string wherestr = "";
            slAmidaConsole.Web.EQ_DomainContext client = new EQ_DomainContext();


            //var q = from n in client.GetTblVerifyNoteQuery() where n.StartTimes == new DateTime(2013, 1, 1) select n; ;
            //client.Load(q);
            string status;

            status = txtStatus.Text.Trim();



            //if (txtPCShape.Text.Trim() != "")
            //{
            //    int res;

            //    if (!int.TryParse(txtPCShape.Text, out res))
            //    {
            //        MessageBox.Show("ProbeShape must be integer!");
            //        return;

            //    }
            //    wherestr += " it.ProbeShape=" + txtPCShape.Text.Trim() + " and";


            //}
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
            //    wherestr += string.Format("  it.StartTimes >= @p0 and it.StartTimes <@p1 and it.stoptimes >=@p0 and it.stoptimes <@p1  and");
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
              //  wherestr += string.Format("  it.StartTimes >= @p0   and");

            }




          //  wherestr = wherestr.TrimEnd(new char[] { 'a', 'n', 'd' });


            Uri uri;

            InvokeOperation<slAmidaConsole.Web.RptSchema.rptRCPStatusIndex[]> lo = null;
            if (datecnt == 2)
            {
                lo = client.GetRCPStatusIndex(status, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtStopDate.Text));
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=9&status=" + txtStatus.Text.Trim() + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + txtStopDate.Text.Trim());
            }
            else if (datecnt == 1)
            {
                lo = client.GetRCPStatusIndex(status, DateTime.Parse(txtStartDate.Text),DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=9&status=" + status + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
            }
            else
            {
                lo = client.GetRCPStatusIndex(status, DateTime.MinValue, DateTime.Now.Date);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=9&status=" + status + "&starttimes=" + DateTime.MinValue.ToShortDateString() + "&stoptimes=" + DateTime.Now.Date.ToShortDateString());

            }
            this.BusyIndicator1.IsBusy = true;
            lo.Completed += (s, a) =>
            {
                
                this.BusyIndicator1.IsBusy = false;
                if (lo.Error != null)
                {
                    MessageBox.Show(lo.Error.Message + "," + lo.Error.StackTrace);
                    return;
                }
                this.dataGrid1.ItemsSource = lo.Value;
                if (IsShowChart)
                    (this.chart1.Series[0] as ColumnSeries).ItemsSource = lo.Value;
            };

            HtmlWindow html = HtmlPage.Window;
            if (chkDownload.IsChecked == true)
            {
                // MessageBox.Show(uri.ToString());

                html.Navigate(uri);
            }



        }

    }
}
