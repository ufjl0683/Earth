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
using System.ServiceModel.DomainServices.Client;
using slAmidaConsole.Web;

namespace slDBManager.Report.Wafer
{
    public partial class rptCurrentWIP : Page
    {
        public rptCurrentWIP()
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
          Uri  uri = new Uri(App.Current.Host.Source + "/../../DownLoadForm.aspx?rptid=4");
          InvokeOperation<slAmidaConsole.Web.RptSchema.rptCurrentWIPSchema[]> lo = null;
          slAmidaConsole.Web.EQ_DomainContext client = new EQ_DomainContext();
          lo = client.GetCurrentWIP();
              this.BusyIndicator1.IsBusy = true;
          lo.Completed += (s, a) =>
              {
                  this.BusyIndicator1.IsBusy = false;
                  this.dataGrid1.ItemsSource = lo.Value;
              };
          HtmlWindow html = HtmlPage.Window;
          if (chkDownload.IsChecked == true)
              html.Navigate(uri);
        }
    }
}
