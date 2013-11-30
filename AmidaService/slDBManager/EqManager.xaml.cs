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
using slAmidaConsole.Web;

namespace slAmidaConsole
{
    public partial class EqManager : Page
    {
        string userid,username;
        System.Collections.ObjectModel.ObservableCollection<vwUserMenuAllow> MenuInfos;
        public EqManager()
        {
            InitializeComponent();
          
          //  this.frame2.Navigating += new System.Windows.Navigation.NavigatingCancelEventHandler(frame2_Navigating);

        }

        void frame2_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            slDBManager.WebService.WebServiceSoapClient client = new slDBManager.WebService.WebServiceSoapClient();
               userid=  this.NavigationContext.QueryString["userid"].ToString();
             username = this.NavigationContext.QueryString["username"].ToString();
             slAmidaConsole.App.UserID = (slDBManager.App.Current as slDBManager.App).UserID = userid;
             slAmidaConsole.App.UserName = (slDBManager.App.Current as slDBManager.App).UserName = username;
            this.txtUserID.Text = username + " login!";
            client.IsUserLoginCompleted += (s, a) =>
                {
                    if (!a.Result)
                        NavigationService.Navigate(
                            new Uri("/Login.xaml", UriKind.Relative));

                    LoadMenu(userid);
                };

            client.IsUserLoginAsync(userid);
            
        }

        private void LoadMenu(string userid)
        {
            slAmidaConsole.Web.EQ_DomainContext db = new Web.EQ_DomainContext();

            EntityQuery< vwUserMenuAllow> qry = from n in db.GetVwUserMenuAllowQuery() where n.UserID == userid && n.IsAllow select n;
            LoadOperation<vwUserMenuAllow> lo = db.Load<vwUserMenuAllow>(qry);
            lo.Completed += (s, a) =>
                {
                    if (lo.Error != null)
                    {
                        MessageBox.Show(lo.Error.Message);
                        return;
                       
                    }


                    MenuInfos = new System.Collections.ObjectModel.ObservableCollection<vwUserMenuAllow>(lo.Entities);

                    var q = (from n in MenuInfos group n by new { n.GroupName, n.MenuOrder} into gn select new MenuInfo { MainMenu = gn.Key.GroupName, MenuOrder=gn.Key.MenuOrder, Menus = gn.ToList<vwUserMenuAllow>() }).OrderBy(x=>x.MenuOrder);
                    this.accordin.ItemsSource = q.ToList<MenuInfo>();
                    //    var MainMenus = (from n in MenuInfos select n.GroupName).Distinct<string>();

                //    foreach (string mainmenu in MainMenus)
                //    {
                //        AccordionItem item = new AccordionItem() { Header = mainmenu };
                //        var q = from n in MenuInfos where n.GroupName == mainmenu select n;
                //        item.DataContext = q;
                //        this.accordin.Items.Add (item);
                       
                //    }

                };


        }

        private void hyperlinkButton2_Click(object sender, RoutedEventArgs e)
        {
         //   this.NavigationService.GoBack();

            slDBManager.WebService.WebServiceSoapClient client = new slDBManager.WebService.WebServiceSoapClient();
            client.LogoutAsync(userid);
            NavigationService.Navigate(
                         new Uri("/Login.xaml", UriKind.Relative));

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.txtMenuSelect.Text = (sender as HyperlinkButton).Content.ToString();
        }

    

       

        //protected override 
        
    }


   public  class MenuInfo
    {
        public string MainMenu { get; set; }
        public int? MenuOrder { get; set; }
        public List<vwUserMenuAllow> Menus { get; set; }
        
    }

}
