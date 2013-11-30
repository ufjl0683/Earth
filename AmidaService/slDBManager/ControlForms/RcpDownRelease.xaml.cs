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
using System.Windows.Controls.Primitives;
using slAmidaConsole.AmidaService;
using System.Windows.Threading;

namespace slDBManager.ControlForms
{
    public partial class RcpDownRelease : Page, slAmidaConsole.AmidaService.IAmidaServiceCallback
    {
        AmidaServiceClient client;
        System.Collections.Generic.Dictionary<string,slAmidaConsole.AmidaService.RegisterDeviceInfo> dictDeviceInfo=new Dictionary<string,slAmidaConsole.AmidaService.RegisterDeviceInfo>();
        System.Collections.Generic.Dictionary<string, System.Windows.Threading.DispatcherTimer> dictToggleButtons = new Dictionary<string, DispatcherTimer>();
        System.Threading.Timer tmr30sec;
        public RcpDownRelease()
        {
            InitializeComponent();
//OnNavigatedTo(null);
        }

        // 使用者巡覽至這個頁面時執行。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            client = new AmidaServiceClient(
              new System.ServiceModel.InstanceContext(this));



            client.RegisterCompleted += (ss, aa) =>
                {
                    client.GetAllConnectionInfoCompleted += (s, a) =>
                    {
                        if (a.Error != null)
                            return;
                        foreach (slAmidaConsole.AmidaService.RegisterDeviceInfo info in a.Result)
                        {
                            if(dictDeviceInfo.ContainsKey(info.PcName))
                                continue;
                            dictDeviceInfo.Add(info.PcName, info);
                        }
                        this.dataGrid1.ItemsSource = a.Result;

                    };
                    client.GetAllConnectionInfoAsync();
                };

            client.RegisterAsync(Guid.NewGuid().ToString(), "CONSOLE");

           //tmr30sec = new System.Threading.Timer(new System.Threading.TimerCallback(tmr30sec_tick));
           //tmr30sec.Change(30 * 1000, 30 * 1000);
           
        }

        //void tmr30sec_tick(object sender)
        //{
        //    if (client.State == System.ServiceModel.CommunicationState.Opened)
        //    {
        //        client.SayServerHelloAsync();
        //        textBlock1.Text = "tmr tick";
        //    }

        //    //else
        //    //{
        //    //    tmr30sec.Change(System.Threading.Timeout.Infinite, 0);
        //    //}
        //}
        public void ReceivedCommand(string xmlCmd, slAmidaConsole.AmidaService.InportCmdType cmdType, string LeadingFileName)
        {
          //  throw new NotImplementedException();
        }

        public void SayHello(string hello)
        {
          //  throw new NotImplementedException();
        }

        public void NotifyConnectionChanged()
        {
           // throw new NotImplementedException();
        }

        delegate void DelegateUpdateTimerAndButtonState(RegisterDeviceInfo obj);
        public void NotifyStatusChanged(string pcname, slAmidaConsole.AmidaService.RegisterDeviceInfo info)
        {
             
           
            if (!dictDeviceInfo.ContainsKey(pcname))
                return;
            //  Dispatcher.BeginInvoke(new Action(()=>{
            dictDeviceInfo[info.PcName].Status = info.Status.Trim();
            dictDeviceInfo[info.PcName].SubStatus = info.SubStatus ;// info.SubStatus.Trim();
            dictDeviceInfo[info.PcName].IsExportPending = info.IsExportPending;

            //只為了觸發 
            dictDeviceInfo[info.PcName].IsEnableDownRelease = true;

            Dispatcher.BeginInvoke(new DelegateUpdateTimerAndButtonState(UpdateTimerAndButtonState), info);
        }


        public void UpdateTimerAndButtonState (RegisterDeviceInfo info)
        {

          //  this.textBlock1.Text = info.Status;
            if (dictToggleButtons.ContainsKey(info.PcName))
            {
                DispatcherTimer but = dictToggleButtons[info.PcName];
                if (info.Status == "Idle")
                {
                   
                  //  but.Foreground = new SolidColorBrush(Colors.Black);

                   if(but!=null)
                   {

                       but.Stop();
                       dictDeviceInfo[info.PcName].IsBusy = false;
                       dictDeviceInfo[info.PcName].MiscRemark = "Success";
                       //info.IsBusy = false;
                       //info.MiscRemark = "Success";
                       // (but.DataContext as RegisterDeviceInfo).IsBusy = false;
                       // (but.DataContext as RegisterDeviceInfo).MiscRemark = "Success";
                       but = null;
                   }
                }
                else if (info.Status == "Down")
                {
                   
                   // but.Foreground = new SolidColorBrush(Colors.Black);
                    if (but  != null)
                    {
                        but.Stop();

                        dictDeviceInfo[info.PcName].IsBusy = false;
                        dictDeviceInfo[info.PcName].MiscRemark = "Success";
                       // info.IsBusy = false; ;
                       //info.MiscRemark = "Success";
                        but  = null;

                    }
                    //else
                    //{
                    //    MessageBox.Show(info.PcName+"but tag null");
                    //}

                }
                else
                {
                 
                    info.IsBusy = false; ;
                   // but.Foreground = new SolidColorBrush(Colors.Black);
                   
                }
            }
            //else
            //{
            //    MessageBox.Show(info.PcName + " button not found!");
            //}
        }
        public void NotifyClientExported(string PCName, string CmdType)
        {
          //  throw new NotImplementedException();
        }

        private void ToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            
             Button but = sender as  Button;
            //slAmidaConsole.AmidaService.RegisterDeviceInfo info = but.DataContext as slAmidaConsole.AmidaService.RegisterDeviceInfo;
           
              

            //    if (dictToggleButtons.ContainsKey(info.PcName))
            //        return;
            //    dictToggleButtons.Add(info.PcName, but);
            
        }

        private void ToggleButton_Unloaded(object sender, RoutedEventArgs e)
        {
           
             Button but = sender as  Button;
            slAmidaConsole.AmidaService.RegisterDeviceInfo info = but.DataContext as slAmidaConsole.AmidaService.RegisterDeviceInfo;
            if (info == null)
                return;
            if (dictToggleButtons.ContainsKey(info.PcName))

                dictToggleButtons.Remove(info.PcName);
        }

       

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
             Button but = sender as  Button;
             if (but.Content.ToString() == "NA")
                 return;
        //    but.IsEnabled = false;
            


                     RegisterDeviceInfo info = but.DataContext as RegisterDeviceInfo;
                     System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
                     if (!dictToggleButtons.ContainsKey(info.PcName))
                         dictToggleButtons.Add(info.PcName, tmr);
                     else
                     {
                         dictToggleButtons[info.PcName] = tmr;
                     }

                     // but.Tag = tmr;


                     tmr.Interval = TimeSpan.FromMinutes(2);
                     if (!info.IsBusy)
                     {
                         if (but.Content.ToString() == "Down")
                         {
                              chldDownSubStatusChoice f = new chldDownSubStatusChoice();
                     f.Show();
                     f.Closed += (ss, aa) =>
                         {
                             if (f.DialogResult != true)
                                 return;
                             //  MessageBox.Show("Call Down");
                             client.DownAsync(info.PcName, (App.Current as App).UserID, f.Result);
                             client.DownCompleted += (s, a) =>
                                 {
                                     if (a.Error != null)
                                         MessageBox.Show(a.Error.Message + "," + a.Error.StackTrace);

                                 };
                         };
                         }
                         else
                             client.ReleaseAsync(info.PcName, (App.Current as App).UserID);

                         (but.DataContext as RegisterDeviceInfo).IsBusy = true;


                     }
                     //    but.Foreground = new SolidColorBrush(Colors.Red);
                     info.MiscRemark = "";
                     tmr.Tick += (s, a) =>
                     {
                         tmr.Stop();

                         info.IsBusy = false; ;
                         // but.Foreground = new SolidColorBrush(Colors.Black);
                         info.MiscRemark = "TimeOut";

                     };
                     tmr.Start();
                 

        }

        //public void ReceivedCommand(string xmlCmd,   InportCmdType cmdType, string LeadingFileName)
        //{
        //    throw new NotImplementedException();
        //}

        //public void NotifyStatusChanged(string pcname,  RegisterDeviceInfo info)
        //{
        //    throw new NotImplementedException();
        //}

        public void NotifyClientYieldChange(string PCName, double yield, string LotId)
        {
         //   throw new NotImplementedException();
        }
    }
}
