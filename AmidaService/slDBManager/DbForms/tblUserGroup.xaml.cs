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
    public partial class tblUserGroup : Page
    {
        slAmidaConsole.Web.EQ_DomainContext db=new slAmidaConsole.Web.EQ_DomainContext();
        public tblUserGroup()
        {
            InitializeComponent();
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EntityQuery<slAmidaConsole.Web.tblUserGroup> qry = db.GetTblUserGroupQuery();
            LoadOperation<slAmidaConsole.Web.tblUserGroup> lo = db.Load<slAmidaConsole.Web.tblUserGroup>(qry);
            lo.Completed += (s, a) =>
                {
                    if (lo.Error != null)
                    {
                        MessageBox.Show(lo.Error.Message);
                        return;
                    }
                    this.dataGrid1.ItemsSource = lo.Entities;
                };
         

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            db.tblUserGroups.Add(new slAmidaConsole.Web.tblUserGroup() { GroupName="Input Group Name here" 
              });
            dataGrid1.ItemsSource = db.tblUserGroups;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            db.RejectChanges();
            dataGrid1.ItemsSource = db.tblUserGroups;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SubmitChanges();
               
                MessageBox.Show("DB Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
            {
                db.tblUserGroups.Remove(dataGrid1.SelectedItem as slAmidaConsole.Web.tblUserGroup);
                dataGrid1.ItemsSource = db.tblUserGroups.ToList(); ;
            }
        }

    }
}
