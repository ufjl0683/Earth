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
using System.Windows.Media.Imaging;
using slAmidaConsole.Web;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Browser;
using System.Windows.Controls.DataVisualization.Charting ;

namespace slDBManager.Report.Wafer
{
    public partial class rptPerformanceIndex : Page
    {
        public rptPerformanceIndex()
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
            string wherestr = "";
            slAmidaConsole.Web.EQ_DomainContext client = new EQ_DomainContext();


            //var q = from n in client.GetTblVerifyNoteQuery() where n.StartTimes == new DateTime(2013, 1, 1) select n; ;
            //client.Load(q);

            if (txtOperator.Text.Trim() != "")
                wherestr += " it.operator like '" + this.txtOperator.Text + "%' and";



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
                wherestr += string.Format("  it.Start_Time >= @p0 and it.Start_Time <@p1 and it.stop_time >=@p0 and it.stop_time <@p1  and");
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
                wherestr += string.Format("  it.Start_Time >= @p0   and");

            }




            wherestr = wherestr.TrimEnd(new char[] { 'a', 'n', 'd' });


            Uri uri;

            InvokeOperation<slAmidaConsole.Web.RptSchema.rptPerformanceSchema[]> lo = null;
            if (datecnt == 2)
            {
                lo = client.GetPerformanceTotalBySql(wherestr, DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtStopDate.Text));
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=2&wherestr=" + wherestr + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + txtStopDate.Text.Trim());
            }
            else if (datecnt == 1)
            {
                lo = client.GetPerformanceTotalBySql(wherestr, DateTime.Parse(txtStartDate.Text), DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=2&wherestr=" + wherestr + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
            }
            else
            {
                lo = client.GetPerformanceTotalBySql(wherestr, DateTime.MinValue, DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=2&wherestr=" + wherestr + "&starttimes=" + DateTime.MinValue.ToShortDateString() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());

            }
            this.BusyIndicator1.IsBusy = true;
            lo.Completed += (s, a) =>
            {
                this.BusyIndicator1.IsBusy = false;
                this.dataGrid1.ItemsSource = lo.Value;
                if (IsShowChart)
                    (this.chart1.Series[0] as ColumnSeries).ItemsSource = lo.Value;
            };

            HtmlWindow html = HtmlPage.Window;
            if (chkDownload.IsChecked == true)
                html.Navigate(uri);
        }

    }
}
