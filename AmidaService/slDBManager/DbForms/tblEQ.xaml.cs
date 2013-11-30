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
using System.ServiceModel.DomainServices.Client;

namespace slDBManager.DbForms
{
    public partial class tblEQ : Page
    {
        System.Collections.ObjectModel.ObservableCollection<slAmidaConsole.Web.tblEQ> Items ;//= new System.Collections.ObjectModel.ObservableCollection<slAmidaConsole.Web.tblEQ>();
        slAmidaConsole.Web.EQ_DomainContext context;
        public tblEQ()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            context = new slAmidaConsole.Web.EQ_DomainContext();

            EntityQuery<slAmidaConsole.Web.tblEQ> q = from n in context.GetTblEQQuery()  orderby n.eqi_id select n;

            LoadOperation<slAmidaConsole.Web.tblEQ> lo = context.Load<slAmidaConsole.Web.tblEQ>(q);

            lo.Completed += (s, a) =>
                {
                    Items = new System.Collections.ObjectModel.ObservableCollection<slAmidaConsole.Web.tblEQ>(lo.Entities);
                   // lstEq.ItemsSource = Items;
                    Filter();
                };
              

        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
           
        }

     
        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (context.HasChanges)
            {
                MessageBox.Show("please save changes");
                e.Cancel = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            if (txtEQID.Text.Trim() == "")
                dataGrid1.ItemsSource = Items;
            else
           // {
               this.dataGrid1.ItemsSource = from n in Items where  n.eqi_id.ToUpper().Contains(txtEQID.Text.Trim().ToUpper()) orderby n.eqi_id select n;

              
            //}
        }

        private void tblEQDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void txtEQID_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // context.GetTblEQHistoryQuery()
          
            EntityQuery<slAmidaConsole.Web.tblEQ> q = from n in context.GetTblEQQuery() orderby n.eqi_id select n;

            LoadOperation<slAmidaConsole.Web.tblEQ> lo = context.Load<slAmidaConsole.Web.tblEQ>(q,LoadBehavior.MergeIntoCurrent,false);

            lo.Completed += (s, a) =>
            {

                Items = new System.Collections.ObjectModel.ObservableCollection<slAmidaConsole.Web.tblEQ>(lo.Entities);
                // lstEq.ItemsSource = Items;
                Filter();
                context.SubmitChanges();
            };
        
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            context.RejectChanges();
        }
    }
}
