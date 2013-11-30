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
using slDBManager.WebService;
namespace slDBManager.DbForms
{
    public partial class ChangeUserPassword : Page
    {
        public ChangeUserPassword()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox2.Password == "" || passwordBox1.Password == "")
            {
                MessageBox.Show("password   must not be null ! ");
                return;
            }
            if (this.passwordBox1.Password != this.passwordBox2.Password )
            {
                MessageBox.Show("both passwords   must  be identical! ");
                    return;
            }

            slAmidaConsole.Web.EQ_DomainContext db = new slAmidaConsole.Web.EQ_DomainContext();
            EntityQuery<slAmidaConsole.Web.tblUser> qry = db.GetTblUserQuery().Where(n => n.UserID == ((slDBManager.App)App.Current).UserID);

            LoadOperation < slAmidaConsole.Web.tblUser > lo = db.Load <slAmidaConsole.Web.tblUser > (qry);
            lo.Completed += (s, a) =>
                {
                    if (lo.Error != null)
                    {
                        MessageBox.Show(lo.Error.Message);
                        return;
                    }
                    slAmidaConsole.Web.tblUser userinfo = lo.Entities.FirstOrDefault();
                    userinfo.Password = passwordBox1.Password;
                    db.SubmitChanges();
                    this.Dispatcher.BeginInvoke(()=>
                    passwordBox1.Password = passwordBox2.Password = ""
                    );
                    MessageBox.Show("change password ok!");
                };
                 
           
        }

    }
}
