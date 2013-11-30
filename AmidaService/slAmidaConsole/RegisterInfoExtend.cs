using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using slAmidaConsole.AmidaService;

namespace slAmidaConsole.AmidaService
{
    public partial class RegisterDeviceInfo
    {

       
        bool _IsBusy;
         
        public bool IsBusy { 
            get{
                
                return _IsBusy;
               }
            set{
                if (value != _IsBusy)
                {
                    _IsBusy = value;
                    this.RaisePropertyChanged("IsBusy");
                }
            }
        }
       
        public string StatusContinueTime
        {
            get
            {
                int h, m, s;
                h =(int) DateTime.Now.Subtract(this.StatusBeginTime).TotalHours;
                m = DateTime.Now.Subtract(this.StatusBeginTime).Minutes;
                s = DateTime.Now.Subtract(this.StatusBeginTime).Seconds;
                 return string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
                
               // this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

            }
            set
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("StatusContinueTime"));
              
               // RaisePropertyChanged("StatusContinueTime");
            }
        }

       
      
        public string total_num_wafer_string
        {
            get
            {
                if (this.Status.ToUpper() == "IDLE")
                    return "NA";
                else
                    return this.total_num_wafer.ToString();

                // this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

            }
            set
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("total_num_wafer_string"));
              
                //RaisePropertyChanged("total_num_wafer_string");
            }
        }

        public string total_num_chip_string
        {
            get
            {
                if (this.Status.ToUpper() == "IDLE" )
                    return "NA";
                else
                    return this.total_num_chip.ToString();

               
                // this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

            }
            set
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("total_num_chip_string"));
                //RaisePropertyChanged("total_num_chip_string");
            }
        }

        public string tested_num_chip_string
        {
            get
            {
                if (this.Status.ToUpper() == "IDLE" )
                    return "NA";
                else
                    return this.tested_num_chip.ToString();


                // this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

            }
            set
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("tested_num_chip_string"));
              
              //  RaisePropertyChanged("tested_num_chip_string");
            }
        }
        public string tested_num_wafer_string
        {
            get
            {
                if (this.Status.ToUpper() == "IDLE" )
                    return "NA";
                else
                    return this.tested_num_wafer.ToString();


                // this.txtWarningTimeCount.Visibility = System.Windows.Visibility.Visible;

            }
            set
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("tested_num_wafer_string"));
              
              //  RaisePropertyChanged("tested_num_wafer_string");
            }
        }

        private string _MiscRemark="";
        public string MiscRemark {
            get
            {
                return _MiscRemark;
            }
            set
            {
                if (value != _MiscRemark)
                {
                    _MiscRemark = value;
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("MiscRemark"));
                }
            }
        }

       
        

        private SolidColorBrush _YieldBrush;//=new SolidColorBrush(Colors.White);
        public SolidColorBrush YieldColor
        {
            get
            {
                if (_YieldBrush == null)
                    _YieldBrush = new SolidColorBrush(Colors.White);
               // System.Diagnostics.Debug.WriteLine(_YieldBrush.ToString());
                return _YieldBrush;
            }
            set
            {
                if (value != _YieldBrush)
                {
                    _YieldBrush = value;
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("YieldColor"));
                }
            }
        }


       // bool _IsEnableDownRelease;
        public bool IsEnableDownRelease
        {
            get
            {
               // 
                if( this.IsExportPending)
                    return false;
                return this.Status == "Release" || this.Status == "Down" || this.Status == "Idle";
                         
            }

            set
            {
                RaisePropertyChanged("IsEnableDownRelease");
            }

            

        }

      

    }
}
