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
using slAmidaConsole.AmidaService;

namespace slAmidaConsole
{
    public partial class MainPage : UserControl
    {
        System.Collections.ObjectModel.ObservableCollection<RegisterDeviceInfo> items = null;
        AmidaServiceClient client = new AmidaServiceClient();
        public MainPage()
        {
            InitializeComponent();
            
         // slAmidaConsole.AmidaService.RegisterDeviceInfo info = new AmidaService.RegisterDeviceInfo();
          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            client.OnRemoteConnectionChange += new EventHandler(client_OnRemoteConnectionChange);
            client.OnClientExportedCommand += new ClientExportedCommandHandler(client_OnClientExportedCommand);
            client.OnClientStatusChanged += new ClientStatusChangedHandler(client_OnClientStatusChanged);
            client.OnClientYieldChanged += new ClientYieldChangedHandler(client_OnClientYieldChanged);
            GetAllInfo();
           // FilterAndBinding();
            //client.getClient().GetAllConnectionInfoCompleted += (s, a) =>
            //    {
            //        if (a.Error != null)
            //        {
            //            MessageBox.Show(a.Error.Message);
            //            return;
            //        }
            //        listBox1.ItemsSource = a.Result;
            //        FilterAndBinding();
            //        listBox1_SizeChanged(null, null);
                  
            //    };

            
          
            //client.getClient().GetAllConnectionInfoAsync();
        }

        void SetYieldFields(RegisterDeviceInfo inf)
        {

            if (inf == null)
                return;
           // inf.yield = yield;
           


            if (inf.Status == "Product")
                inf.YieldColor = new SolidColorBrush((inf.yield < 80 && inf.yield > 0) ? Colors.Orange : Colors.Transparent);
            else
                inf.YieldColor = new SolidColorBrush(Colors.Transparent);
        }
        void client_OnClientYieldChanged(string pcname, double yield, string lotid)
        {

            RegisterDeviceInfo inf = (from n in items where n.PcName == pcname select n).FirstOrDefault<RegisterDeviceInfo>();
            if (inf == null)
                return;
            inf.yield = yield;

            SetYieldFields(inf);

            //if (inf.Status == "Product")
            //    inf.YieldColor = new SolidColorBrush((yield < 80  && yield >0) ? Colors.Red : Colors.White);
            //else
            //    inf.YieldColor = new SolidColorBrush(Colors.White);
          //  throw new NotImplementedException();
        }

        void client_OnClientStatusChanged(string Pcname, RegisterDeviceInfo info)
        {
            if (items == null)
                return;
           
            RegisterDeviceInfo inf = (from n in items where n.PcName == info.PcName select n).FirstOrDefault<RegisterDeviceInfo>();
            if (inf != null)
            {
                inf.ConnectedTime = info.ConnectedTime;
                inf.CurrentWaferId = info.CurrentWaferId;
                inf.ProbeCardId = info.ProbeCardId;
                inf.Status = info.Status;
                inf.tested_num_chip = info.tested_num_chip;
                inf.tested_num_wafer = info.tested_num_wafer;
                inf.TimeRemain = info.TimeRemain;
                inf.total_num_chip = info.total_num_chip;
                inf.total_num_wafer = info.total_num_wafer;
                inf.WarningMessage = info.WarningMessage;
                inf.WarningType = info.WarningType;
                inf.Progress = info.Progress;
                inf.StatusBeginTime = info.StatusBeginTime;
                inf.WarningBeginTime = info.WarningBeginTime;
                inf.eq_comment = info.eq_comment;
                inf.lot_id = info.lot_id;
                inf.yield = info.yield;
                inf.IsExportPending = info.IsExportPending;
                
                this.SetYieldFields(inf);
                //info.total_num_chip_string = "";  //force ui refresh
                //info.total_num_wafer_string = "";
                //info.tested_num_chip_string = "";
                //info.tested_num_wafer_string = "";
                this.Dispatcher.BeginInvoke(
                    new Action(
                            () =>
                            {
                                inf.total_num_chip_string = "";  //force ui refresh
                                inf.total_num_wafer_string = "";
                                inf.tested_num_chip_string = "";
                                inf.tested_num_wafer_string = "";

                            }
                        ));
            }
            else
            {
                items.Add(info);
            }
        
        //    FilterAndBinding();
            
        }

        void client_OnClientExportedCommand(string Pcname, string CmdType)
        {
            //GetAllInfo();
            //Binding();

            Grid panel = list.Where(n => (n.DataContext as AmidaService.RegisterDeviceInfo).PcName == Pcname).FirstOrDefault();
            if (panel != null)
                (panel.Resources["Storyboard1"] as Storyboard).Begin();
           
           
        }

        void client_OnRemoteConnectionChange(object sender, EventArgs e)
        {

            GetAllInfo();
          //  FilterAndBinding();
            //throw new NotImplementedException();
        }

        void client_OnSayHello(object sender, EventArgs e)
        {
           
        }
        void GetAllInfo()
        {
            client.getClient().GetAllConnectionInfoCompleted += (s, a) =>
            {
                if (a.Error != null)
                {
                    MessageBox.Show(a.Error.Message);
                    return;
                }

                foreach (RegisterDeviceInfo inf in a.Result)
                  SetYieldFields(inf);
                items = a.Result;
                FilterAndBinding();

            };
            client.getClient().GetAllConnectionInfoAsync();
        }
        void FilterAndBinding()
        {
            var exp = PredicateBuilder.True<RegisterDeviceInfo>();

            if (items != null)
            {
            //    if((bool)rdoAll.IsChecked)
            //      dataGrid1.ItemsSource=   listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) select n;
            //    else if ((bool)rdoIdle.IsChecked)
            //        dataGrid1.ItemsSource = listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) && n.Status == "Idle" select n;
            //    else if ((bool)this.rdoLem.IsChecked)
            //        dataGrid1.ItemsSource = listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) && n.Status == "LEM" select n;
            //    else if ((bool)this.rdoVerify.IsChecked)
            //        dataGrid1.ItemsSource = listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) && n.Status == "Verify" select n;
            //    else if ((bool)this.rdoProduct.IsChecked)
            //        dataGrid1.ItemsSource = listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) && n.Status == "Product" select n;
            //    else if ((bool)this.rdoWarning.IsChecked)
            //        dataGrid1.ItemsSource = listBox1.ItemsSource = from n in items where n.PcName.Contains(txtRCP.Text.Trim().ToUpper()) && (n.WarningMessage != null && n.WarningMessage.Trim() != "") select n;

                if (txtRCP.Text.Trim() != "")
                    exp = exp.And<RegisterDeviceInfo>(n => n.PcName.Contains(txtRCP.Text.Trim().ToUpper()));
                if(txtArea.Text.Trim()!="")
                    exp = exp.And<RegisterDeviceInfo>(n => n.eq_area!=null && n.eq_area.ToUpper().Contains(this.txtArea.Text.Trim().ToUpper()));
                
                if (((bool)rdoIdle.IsChecked))

                    exp = exp.And<RegisterDeviceInfo>(n => n.Status == "Idle");
                   
                else if ((bool)this.rdoLem.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n => n.Status == "LEM");
                 else if ((bool)this.rdoVerify.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n => n.Status == "Verify");
                else if ((bool)this.rdoProduct.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n => n.Status == "Product");
                else if ((bool)this.rdoWarning.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n=>(n.WarningMessage != null && n.WarningMessage.Trim() != ""));
                else if((bool)this.rdDown.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n => (n.Status=="Down"));
                else if ((bool)this.rdPending.IsChecked)
                    exp = exp.And<RegisterDeviceInfo>(n => (n.IsExportPending==true));

               dataGrid1.ItemsSource = listBox1.ItemsSource = items.AsQueryable<RegisterDeviceInfo>().Where<RegisterDeviceInfo>(exp);
            
            }
            //else

            //    listBox1.ItemsSource = items;
        }


        private void WrapPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WrapPanel panel = sender as WrapPanel;
            panel.Width = listBox1.ActualWidth;
        }

        System.Collections.Generic.List<Grid> list = new List<Grid>();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            list.Add(sender as Grid);
          
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            list.Remove(sender as Grid);
        }

        WrapPanel wrapPanel;
        private void WrapPanel_Loaded(object sender, RoutedEventArgs e)
        {
            wrapPanel = sender as WrapPanel;
        }

        private void listBox1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(wrapPanel !=null)
            wrapPanel.Width = listBox1.ActualWidth;
        }

        private void wafer_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as Wafer).BindingChanged();
         //   (sender as Wafer).On30SecTick += new Tick_30Sec_Event_Handler(MainPage_On30SecTick);
        }

        //void MainPage_On30SecTick(RegisterDeviceInfo info)
        //{
        //    int h, m, s;
        //    h = DateTime.Now.Subtract(info.StatusBeginTime).Hours;
        //    m = DateTime.Now.Subtract(info.StatusBeginTime).Minutes;
        //    s = DateTime.Now.Subtract(info.StatusBeginTime).Seconds;
        //    txtWarningTimeCount.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
        //    this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

        //    //throw new NotImplementedException();
        //}

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            //foreach( UIElement  element in (list[0] as Grid).Children)
            //{
            //    if (element is Wafer)

             
            //}
           

        }

        private void txtRCP_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterAndBinding();
        }

        private void radioButton5_Checked(object sender, RoutedEventArgs e)
        {
            FilterAndBinding();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
         //   this.listBox1.Visibility = System.Windows.Visibility.Collapsed;
            this.dataGrid1.Visibility = System.Windows.Visibility.Visible;

            ////if ((bool)checkBox1.IsChecked)
            ////{
            //    this.listBox1.ItemsPanel = this.Resources["DetailPanelTemplat"] as ItemsPanelTemplate;
            //    this.listBox1.ItemTemplate = this.Resources["DetailDataTemplate"] as DataTemplate;
            ////}
            ////else
            ////{
            //    //this.listBox1.ItemsPanel = this.Resources["NormalPanelTemplat"] as ItemsPanelTemplate;
            //    //this.listBox1.ItemTemplate = this.Resources["NormalDataTemplate"] as DataTemplate;
           
            ////}
            //FilterAndBinding();
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            //this.listBox1.ItemsPanel = this.Resources["NormalPanelTemplat"] as ItemsPanelTemplate;
            //this.listBox1.ItemTemplate = this.Resources["NormalDataTemplate"] as DataTemplate;
           // this.listBox1.Visibility = System.Windows.Visibility.Visible;
            this.dataGrid1.Visibility = System.Windows.Visibility.Collapsed;
            ////}
            //FilterAndBinding();
        }

        private void txtArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterAndBinding();
        }

        private void rdDown_Checked(object sender, RoutedEventArgs e)
        {
            FilterAndBinding();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
           if( this.listBox1.SelectedItems.Count==0)
           {
               MessageBox.Show("請先選取RCP");
               return;
           }
           
           cldSendMessage wnd = new cldSendMessage();
       //    wnd.Title = "send to " + (listBox1.SelectedItem as RegisterDeviceInfo).PcName;
           wnd.DataContext = this.listBox1.SelectedItems;
           wnd.Show();
           wnd.Unloaded += (s, a) =>
               {
                   if (wnd.DialogResult == false)
                       return;
                   foreach (RegisterDeviceInfo info in listBox1.SelectedItems)
                   {

                       client.getClient().NotifyRCPAsync(
                           (info).PcName,
                           App.UserName,wnd.Message

                           );
                   }
               };


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            cldSendMessage wnd = new cldSendMessage();
            //    wnd.Title = "send to " + (listBox1.SelectedItem as RegisterDeviceInfo).PcName;

            wnd.DataContext = this.listBox1.ItemsSource;;
            wnd.Show();
            wnd.Unloaded += (s, a) =>
            {
                if (wnd.DialogResult == false)
                    return;
                foreach (RegisterDeviceInfo info in this.listBox1.ItemsSource)
                {

                    client.getClient().NotifyRCPAsync(
                        (info).PcName,
                           App.UserName, wnd.Message

                        );
                }
            };

        }


    }
}
