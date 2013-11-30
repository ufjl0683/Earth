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
using System.Windows.Browser;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls.DataVisualization.Charting;

namespace slDBManager.Report.Yield
{
    public partial class rptYieldVSOP : Page
    {
        public rptYieldVSOP()
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
         //   string wherestr = "";
            slAmidaConsole.Web.EQ_DomainContext client = new EQ_DomainContext();



            if (this.txtWaferMask.Text.Trim() == "")
            {
                MessageBox.Show("WaferMask must not be empty!");
                return;
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
           

            }




       


            Uri uri;
            
            InvokeOperation<slAmidaConsole.Web.RptSchema.rptYieldVSOpSchema[]> lo = null;
            if (datecnt == 2)
            {
                lo = client.GetYieldVSOP(txtWaferMask.Text.Trim(),txtOperator.Text.Trim() , DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtStopDate.Text));
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=5&maskid=" + txtWaferMask.Text.Trim() + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + txtStopDate.Text.Trim()+"&operator="+txtOperator.Text.Trim());
            }
            else if (datecnt == 1)
            {
                lo = client.GetYieldVSOP(txtWaferMask.Text.Trim(),txtOperator.Text, DateTime.Parse(txtStartDate.Text), DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=5&maskid=" + txtWaferMask.Text + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.Date+"&operator="+txtOperator.Text.Trim());
            }
            else
            {
                lo = client.GetYieldVSOP(txtWaferMask.Text.Trim(), txtOperator.Text, new DateTime(1900,1,1), DateTime.MaxValue);
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=5&maskid=" + txtWaferMask.Text.Trim() + "&starttimes=" + new DateTime(1900,1,1).ToShortDateString() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString()+"&operator="+txtOperator.Text.Trim());

            }
            this.BusyIndicator1.IsBusy = true;
            lo.Completed += (s, a) =>
            {
                this.BusyIndicator1.IsBusy = false;
                this.dataGrid1.ItemsSource = lo.Value;
                if (IsShowChart)
                {
                    (this.chart1.Series[0] as LineSeries).ItemsSource = lo.Value;
                    (this.chart1.Series[1] as ColumnSeries).ItemsSource = lo.Value;
                    (this.chart1.Series[2] as LineSeries).ItemsSource = lo.Value;
                }
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
