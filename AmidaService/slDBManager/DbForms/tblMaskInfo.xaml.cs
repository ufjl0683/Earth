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
    public partial class tblMaskInfo : Page
    {

        slAmidaConsole.Web.EQ_DomainContext db = new slAmidaConsole.Web.EQ_DomainContext();
        public tblMaskInfo()
        {
            InitializeComponent();
            
        }

        void LoadDb()
        {
            var q = db.GetTblMaskInfoQuery();
            var lo= db.Load(q);
            lo.Completed += (s, a) =>
                {
                    if (lo.HasError)
                    {
                        MessageBox.Show(lo.Error.StackTrace);
                        return;
                    }
                    this.dataGrid1.ItemsSource = lo.Entities;
                };
        }
        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadDb();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (db.HasChanges)
            {
                MessageBox.Show("please save changes");
                e.Cancel = true;
            }

             
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            db.tblMaskInfos.Add(
                new slAmidaConsole.Web.tblMaskInfo() { MaskID="MaskID here " });
            this.dataGrid1.ItemsSource = db.tblMaskInfos;
           
          
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                db.SubmitChanges().Completed+=(s,a)=>
                    {
                        if (((SubmitOperation)s).Error != null)
                        {
                            MessageBox.Show(((SubmitOperation)s).Error.Message);
                            return;
                        }
                         MessageBox.Show("ok");
                    };
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            db.RejectChanges();
        }

        private void dataGrid1_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
          
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem == null)
                return;
    

        if(   MessageBox.Show("確定要刪除"+ (dataGrid1.SelectedItem as slAmidaConsole.Web.tblMaskInfo).MaskID  ,"tblMaskInfo", MessageBoxButton.OKCancel  )== MessageBoxResult.Cancel)
            return;
            db.tblMaskInfos.Remove(dataGrid1.SelectedItem as slAmidaConsole.Web.tblMaskInfo);
            dataGrid1.ItemsSource = db.tblMaskInfos;
        }

        private void txtMaskFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMaskFilter.Text.Trim() == "")
                dataGrid1.ItemsSource = db.tblMaskInfos;
            else
                dataGrid1.ItemsSource = from n in db.tblMaskInfos where n.MaskID.StartsWith(txtMaskFilter.Text.Trim()) select n;
    
        }

      
    }
}
