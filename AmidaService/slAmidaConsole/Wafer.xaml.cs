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
    public delegate void Tick_30Sec_Event_Handler(RegisterDeviceInfo info);
    public partial class Wafer : UserControl
    {
        bool IsClosed = false;
        public event Tick_30Sec_Event_Handler On30SecTick;
        System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
        public Wafer()
        {
            InitializeComponent();

            //RegisterDeviceInfo info = this.DataContext as RegisterDeviceInfo;

            //info.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(info_PropertyChanged);

            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        bool isInTick = false;
        void tmr_Tick(object sender, EventArgs e)
        {
            if (isInTick)
                return;
            try
            {
                
                isInTick = true;
                RegisterDeviceInfo info = this.DataContext as RegisterDeviceInfo;
                if (this.On30SecTick != null)
                    this.On30SecTick(info);
                if (info == null) return;
                if (info.WarningMessage != null && info.WarningMessage != "")
                {

                    int h, m, s;
                    h = DateTime.Now.Subtract(info.WarningBeginTime).Hours;
                    m = DateTime.Now.Subtract(info.WarningBeginTime).Minutes;
                    s = DateTime.Now.Subtract(info.WarningBeginTime).Seconds;
                    txtWarningTimeCount.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
                    this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

                }
                else
                {
                    this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Collapsed;
                    info.WarningBeginTime = DateTime.MinValue; ;
                }

                info.StatusContinueTime = ""; //just invoke property change
            }
            catch (Exception ex)
            {
            }
            finally
            {
                isInTick = false;
            }
          //  throw new NotImplementedException();
        }


        public void BindingChanged()
        {
            RegisterDeviceInfo info = this.DataContext as RegisterDeviceInfo;

            info.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(info_PropertyChanged);
            this.SetStatus(info.Status);
            this.SetWarning(info.WarningMessage);
       
        }

        void info_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
            {
               
                SetStatus((sender as RegisterDeviceInfo).Status);
                (sender as RegisterDeviceInfo).StatusContinueTime = ""; // invoke property changed
            }
            else if (e.PropertyName == "WarningMessage")
            {
                SetWarning((sender as RegisterDeviceInfo).WarningMessage);
            }
        }

       

        public string ModeString = "";
        //private string _WarningMessage ="";
        //public string WarningMessage
        //{
        //    get
        //    { return _WarningMessage; }
        //}
        /// <summary>
        /// 傳遞狀態代碼
        /// 1=sleeping
        /// 2=testting
        /// 3=damage
        /// 4=fax
        /// default=legend
        /// </summary>
        /// <param name="stscode"></param>
        /// 
        void AllStop()
        {
            sleeping.Storyboard.Stop();
            testting.Storyboard.Stop();
            damage.Storyboard.Stop();
            fax.Storyboard.Stop();
            Down.Storyboard.Stop();

        }
        public void SetStatus(string stscode)  //Idle,Product,Verify,LEM
        {
            if (ModeString == stscode)
            {
                ModeString = stscode;
                return;
            }
            ModeString = stscode;
            RegisterDeviceInfo info = this.DataContext as RegisterDeviceInfo;
            //if (info.WarningMessage == "" || info.WarningMessage == null)
            //{
                switch (stscode)
                {
                    case "Idle":
                       
                     // VisualStateManager.GoToState(this, "sleeping", true);
                        AllStop();
                        sleeping.Storyboard.Begin();
                        break;
                     
                    case "Product":
                     //  VisualStateManager.GoToState(this, "testting", true);
                        AllStop();
                        testting.Storyboard.Begin();
                      
                        break;
                    case "Verify":
                      //  VisualStateManager.GoToState(this, "damage", true);
                        AllStop();
                        damage.Storyboard.Begin();
                        break;
                    case "LEM":
                        AllStop();
                        //VisualStateManager.GoToState(this, "fax", true);
                        fax.Storyboard.Begin();
                        break;
                    case "Down":
                        AllStop();
                        Down.Storyboard.Begin();
                        break;
                    //case 5:
                    //    Status_legend.Visibility = System.Windows.Visibility.Visible;
                    //    sleeping.Storyboard.Pause();
                    //    testting.Storyboard.Pause();
                    //    damage.Storyboard.Pause();
                    //    fax.Storyboard.Pause();
                    //    break;
                    //case 6:
                    //    Status_legend.Visibility = System.Windows.Visibility.Collapsed;
                    //    sleeping.Storyboard.Resume();
                    //    testting.Storyboard.Resume();
                    //    damage.Storyboard.Resume();
                    //    fax.Storyboard.Resume();
                    //    break;
                }
            //}
            //else
            //{
            //    switch (stscode)
            //    {
            //        case "Idle":
            //          //  VisualStateManager.GoToState(this, "sleeping", true);
            //            break;
            //        case "Product":
            //          //  VisualStateManager.GoToState(this, "testting", true);
            //            break;
            //        case "Verify":
            //          //  VisualStateManager.GoToState(this, "damage", true);
            //            break;
            //        case "LEM":
            //         //   VisualStateManager.GoToState(this, "fax", true);
            //            break;
            //        //case 5:
            //        //    Status_legend.Visibility = System.Windows.Visibility.Visible;
            //        //    sleeping.Storyboard.Pause();
            //        //    testting.Storyboard.Pause();
            //        //    damage.Storyboard.Pause();
            //        //    fax.Storyboard.Pause();
            //        //    break;
            //        //case 6:
            //        //    Status_legend.Visibility = System.Windows.Visibility.Collapsed;
            //        //    sleeping.Storyboard.Resume();
            //        //    testting.Storyboard.Resume();
            //        //    damage.Storyboard.Resume();
            //        //    fax.Storyboard.Resume();
            //        //    break;
            //    }
            //    StatusCoverterPause();
            //}

          
            
        }

        public void SetWarning(string mesg)
        {

            //this._WarningMessage = mesg;
            //Status_legend.DataContext = this;

            if (mesg == "" || mesg==null)
            {
                Status_legend.Visibility = System.Windows.Visibility.Collapsed;
                StatusCoverterResume();
            }
            else
            {
                Status_legend.Visibility = System.Windows.Visibility.Visible;
                StatusCoverterPause();
            }
        }

        public void StatusCoverterPause()
        {
            System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer() 
            { Interval = TimeSpan.FromSeconds(1) };
            switch (ModeString)
            {
                case "Idle":

                    tmr.Tick += (s, a) =>
                    {
                        sleeping.Storyboard.Pause();
                        tmr.Stop();
                    };
                    tmr.Start();
                    break;
                case "Product":
                    tmr.Tick += (s, a) =>
                    {
                        testting.Storyboard.Pause();
                        tmr.Stop();
                    };
                    tmr.Start();
                    
                    break;
                case "Verify":
                    tmr.Tick += (s, a) =>
                    {
                        damage.Storyboard.Pause();
                        tmr.Stop();
                    };
                    tmr.Start();
                    
                    break;
                case "LEM":
                    tmr.Tick += (s, a) =>
                    {
                        fax.Storyboard.Pause();
                        tmr.Stop();
                    };
                    tmr.Start();
                    
                    break;
                case "Down":
                     tmr.Tick += (s, a) =>
                    {
                        Down.Storyboard.Pause();
                        tmr.Stop();
                    };
                    tmr.Start();
                    break;
            }
        }

        public void Close()
        {
            IsClosed = true;
            this.tmr.Stop();
            
        }
        public void StatusCoverterResume()
        {
            System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
          
            tmr.Tick += (s, a) =>
                   {
                       AllStop();
                       switch (ModeString)
                       {
                           case "Idle":

                               sleeping.Storyboard.Begin();
                               tmr.Stop();

                               break;
                           case "Product":
                               testting.Storyboard.Begin();
                               break;
                           case "Verify":
                               damage.Storyboard.Begin();
                               break;
                           case "LEM":
                               fax.Storyboard.Begin();
                               break;
                           case "Down":
                               Down.Storyboard.Begin();
                               break;
                       }
                       tmr.Stop();
                   };
                    tmr.Start();
            
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.AllStop();
        }
        //private void UpdateStates(bool useTransitions)
        //{
        //    if (Value >= 0)
        //    {
        //        VisualStateManager.GoToState(this, "Positive", useTransitions);
        //    }
        //    else
        //    {
        //        VisualStateManager.GoToState(this, "Negative", useTransitions);
        //    }

        //    if (IsFocused)
        //    {
        //        VisualStateManager.GoToState(this, "Focused", useTransitions);
        //    }
        //    else
        //    {
        //        VisualStateManager.GoToState(this, "Unfocused", useTransitions);
        //    }

        //}

      
    }
}
