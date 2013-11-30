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
using System.ComponentModel;

namespace slDBManager.DbForms
{
    public partial class tblUser : Page
    {
        slAmidaConsole.Web.EQ_DomainContext db = new slAmidaConsole.Web.EQ_DomainContext();
        public tblUser()
        {
            InitializeComponent();
          
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            (this.Resources["MyUserGroupList"] as MyUserGroupList).Context = db;
        }
        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            //EntityQuery<slAmidaConsole.Web.tblUserGroup> qry1 = db.GetTblUserGroupQuery();
            //LoadOperation<slAmidaConsole.Web.tblUserGroup> lo1 = db.Load<slAmidaConsole.Web.tblUserGroup>(qry1);
            //lo1.Completed += (s, a) =>
            //{
            //    if (lo1.Error != null)
            //    {
            //        MessageBox.Show(lo1.Error.Message);
            //        return;
            //    }
            //  this.Resources.Add("CBItem", lo1.Entities.ToList());

              

               
            //};

            EntityQuery<slAmidaConsole.Web.tblUser> qry = db.GetTblUserQuery();
            LoadOperation<slAmidaConsole.Web.tblUser> lo = db.Load<slAmidaConsole.Web.tblUser>(qry);
            lo.Completed += (ss, aa) =>
            {
                if (lo.Error != null)
                {
                    MessageBox.Show(lo.Error.Message);
                    return;
                }
               // lo.Entities.ToArray()[0].EntityState
                this.dataGrid1.ItemsSource = lo.Entities;
            };
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
         //   (sender as ComboBox).ItemsSource = (this.Resources["UserGroupSource"] as DomainDataSource).Data;

            //   (from n in db.tblUserGroups select new UserGroupComboItem { GroupID = n.GroupID, GroupName = n.GroupName }).ToList();
            //(sender as ComboBox).DisplayMemberPath = "GroupName";
            //(sender as ComboBox).SelectedValuePath = "GroupID";
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.db.RejectChanges();
            this.dataGrid1.ItemsSource = db.tblUsers;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.db.tblUsers.Add(new slAmidaConsole.Web.tblUser() {UserID="Input ID here", GroupID = 1, Password = "1234" } );
            this.dataGrid1.ItemsSource = db.tblUsers.ToList();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid1.SelectedItem != null)
            {
                this.db.tblUsers.Remove(dataGrid1.SelectedItem as slAmidaConsole.Web.tblUser);
                this.dataGrid1.ItemsSource = db.tblUsers.ToList();
            }


        }

        private void tblUserGroupDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

       

    }

   public class MyUserGroupList  
    {
        slAmidaConsole.Web.EQ_DomainContext _Context;

        public MyUserGroupList()
        {
        }
        public slAmidaConsole.Web.EQ_DomainContext Context
        {


            set
            {
                _Context  = value;
                _Context.Load(_Context.GetTblUserGroupQuery());
               
                 
            }
        }

        public EntitySet<slAmidaConsole.Web.tblUserGroup> List
        {
            get
            {
              return  _Context.tblUserGroups;
            }
        }
        
    }


}
