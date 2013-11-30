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
using slAmidaConsole.Web;
using System.ServiceModel.DomainServices.Client;

namespace slDBManager
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EQ_DomainContext context = new EQ_DomainContext();

            this.busyIndicator1.IsBusy = true;
            EntityQuery<tblUser> q = (from n in context.GetTblUserQuery() where n.UserID == txtUserID.Text && n.Password == txtPassword.Password select n);

            LoadOperation<tblUser> lo = context.Load<tblUser>(q);
            lo.Completed += (s, a) =>
            {
                if (lo.Error != null)
                {
                    MessageBox.Show(lo.Error.Message);
                    this.busyIndicator1.IsBusy = false;
                    return;
                }

                tblUser user = lo.Entities.FirstOrDefault<tblUser>();
                if (user == null)
                {
                    MessageBox.Show("帳號密碼錯誤 !");
                    this.busyIndicator1.IsBusy = false;
                    return;
                };



               // slDBManager.WebContext client = new WebContext();


                WebService.WebServiceSoapClient client = new WebService.WebServiceSoapClient();

                client.RegisterSessionCompleted += (ss, aa) =>
                {
                    if (aa.Error != null)
                    {
                        MessageBox.Show(aa.Error.Message);
                        this.busyIndicator1.IsBusy = false;
                        return;
                    }
                    this.busyIndicator1.IsBusy = true;
                    this.NavigationService.Navigate(new Uri("/EqManager.xaml?userid="+user.UserID+"&username="+user.UserName,UriKind.Relative));

                };

                client.RegisterSessionAsync(user.UserID);



            };
        }

        private void LayoutRoot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button1_Click(null, null);
        }

       

    }
}
