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

namespace WaferStatus
{
    public partial class Wafer : UserControl
    {
        public Wafer()
        {
            InitializeComponent();
            
       

          
        }

       

        public string ModeString = "";
        private string _WarningMessage ="";
        public string WarningMessage
        {
            get
            { return _WarningMessage; }
        }
        /// <summary>
        /// 傳遞狀態代碼
        /// 1=sleeping
        /// 2=testting
        /// 3=damage
        /// 4=fax
        /// default=legend
        /// </summary>
        /// <param name="stscode"></param>
        public void SetStatus(string stscode)  //Idle,Product,Verify,LEM
        {
            ModeString = stscode;
            if (WarningMessage == "")
            {
                switch (stscode)
                {
                    case "Idle":
                        VisualStateManager.GoToState(this, "sleeping", true);
                        break;
                    case "Product":
                        VisualStateManager.GoToState(this, "testting", true);
                        break;
                    case "Verify":
                        VisualStateManager.GoToState(this, "damage", true);
                        break;
                    case "LEM":
                        VisualStateManager.GoToState(this, "fax", true);
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
            }
            else
            {
                switch (stscode)
                {
                    case "Idle":
                        VisualStateManager.GoToState(this, "sleeping", true);
                        break;
                    case "Product":
                        VisualStateManager.GoToState(this, "testting", true);
                        break;
                    case "Verify":
                        VisualStateManager.GoToState(this, "damage", true);
                        break;
                    case "LEM":
                        VisualStateManager.GoToState(this, "fax", true);
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
                StatusCoverterPause();
            }

          
            
        }

        public void SetWarning(string mesg)
        {

            this._WarningMessage = mesg;
            Status_legend.DataContext = this;

            if (mesg == "")
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
            }
        }

        public void StatusCoverterResume()
        {
            
            switch (ModeString)
            {
                case "Idle":
                    sleeping.Storyboard.Resume();
                    break;
                case "Product":
                    testting.Storyboard.Resume();
                    break;
                case "Verify":
                    damage.Storyboard.Resume();
                    break;
                case "LEM":
                    fax.Storyboard.Resume();
                    break;
            }
            
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
