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
using System.Windows.Browser;

namespace slDBManager.Report.RawData
{
    public partial class rptVerifyNoteTable : Page
    {
        public rptVerifyNoteTable()
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
            int datecnt = 0;
            Uri uri;
            string wherestr="";
            this.tblVerifyNoteDomainDataSource.FilterDescriptors.Clear();
            if (txtStartDate.Text.Trim() != "" && txtStopDate.Text.Trim() != "")
            {
                DateTime res,res1;
                if (!DateTime.TryParse(txtStartDate.Text.Trim(), out res))
                {
                    MessageBox.Show("Start Date format error!");
                    return;
                }
                if (!DateTime.TryParse(this.txtStopDate.Text.Trim(), out res1))
                {
                    MessageBox.Show("End Date format error!");
                    return;
                }
                datecnt = 2;
            
                this.tblVerifyNoteDomainDataSource.FilterDescriptors.Add(
                   new FilterDescriptor() { Operator = FilterOperator.IsGreaterThanOrEqualTo, PropertyPath="StartTimes", Value = res });
                this.tblVerifyNoteDomainDataSource.FilterDescriptors.Add(
                  new FilterDescriptor() { Operator = FilterOperator.IsLessThanOrEqualTo, Value = res1 , PropertyPath="StopTimes"});
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=11&wherestr=" + wherestr + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + txtStopDate.Text.Trim());
               wherestr += string.Format("  it.StartTimes >= @p0 and it.StopTimes <@p1  and");
            }
            else if (txtStartDate.Text.Trim() != "" && txtStopDate.Text.Trim() == "")
            {
                DateTime res;
                if (!DateTime.TryParse(txtStartDate.Text.Trim(), out res))
                {
                    MessageBox.Show("Start Date format error!");
                    return;
                }
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=11&wherestr=" + wherestr + "&starttimes=" + txtStartDate.Text.Trim() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
                datecnt = 1;
                wherestr += string.Format("  it.StartTimes >= @p0   and");
                this.tblVerifyNoteDomainDataSource.FilterDescriptors.Add(
                  new FilterDescriptor() { Operator = FilterOperator.IsGreaterThanOrEqualTo, Value = res ,PropertyPath="StartTimes"});
            }
            else
            {
                uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=11&wherestr=" + wherestr + "&starttimes=" + DateTime.MinValue.ToShortDateString() + "&stoptimes=" + DateTime.MaxValue.ToShortDateString());
                //MessageBox.Show("StartDate must not be empty!");
                //return;
            }
            this.tblVerifyNoteDomainDataSource.Load();


            wherestr = wherestr.TrimEnd(new char[] { 'a', 'n', 'd' });

            this.BusyIndicator1.IsBusy = true;
            HtmlWindow html = HtmlPage.Window;
            if (chkDownload.IsChecked == true)
                html.Navigate(uri);
        }

        private void tblVerifyNoteDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            this.BusyIndicator1.IsBusy = false;

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

    }
}
