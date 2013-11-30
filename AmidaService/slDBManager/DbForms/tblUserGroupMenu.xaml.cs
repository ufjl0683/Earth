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

namespace slDBManager.DbForms
{
    public partial class tblUserGroupMenu : Page
    {
        slAmidaConsole.Web.EQ_DomainContext db = new slAmidaConsole.Web.EQ_DomainContext();
        public tblUserGroupMenu()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EntityQuery<slAmidaConsole.Web.tblUserGroupMenu> qry = db.GetTblUserGroupMenuQuery();
            db.Load<slAmidaConsole.Web.tblUserGroupMenu>(qry).Completed+=(s,a)=>
            {
                LoadOperation<slAmidaConsole.Web.tblUserGroupMenu> lo = s as LoadOperation<slAmidaConsole.Web.tblUserGroupMenu>;
                if (lo.Error != null)
                {
                    MessageBox.Show(lo.Error.Message);
                    return;
                }

              //  this.dataGrid1.ItemsSource = lo.Entities;

            };

            db.Load<slAmidaConsole.Web.tblUserGroup>(db.GetTblUserGroupQuery()).Completed += (s, a) =>
                {
                    comboBox1.ItemsSource = (s as LoadOperation<slAmidaConsole.Web.tblUserGroup>).Entities;
                };
            db.Load<slAmidaConsole.Web.tblMenu>(db.GetTblMenuQuery()); 

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int groupid = ((sender as ComboBox).SelectedItem as slAmidaConsole.Web.tblUserGroup).GroupID;
             var q= from n in db.tblUserGroupMenus where n.GroupID==groupid  select n;
             this.dataGrid1.ItemsSource = q;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Saved to Db ok!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            db.RejectChanges();
        }

    }
}
