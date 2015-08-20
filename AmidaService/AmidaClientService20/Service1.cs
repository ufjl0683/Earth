using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using System.Text;

namespace AmidaClientService20
{
    public partial class Service : ServiceBase
    {
        public static string DestIP;
       public AmidaClientExportThread thread;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ServerConfig.txt"))
                DestIP = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "ServerConfig.txt").Trim();
            else
            {
                Util.WriteEventLog(AppDomain.CurrentDomain.BaseDirectory + "ServerConfig.txt");
                DestIP = args[0];
            }

           

            thread = new AmidaClientService20.AmidaClientExportThread();
        }

        protected override void OnStop()
        {
        

        }
    }
}
