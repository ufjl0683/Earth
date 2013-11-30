using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AmidaClientService
{
    public partial class Service : ServiceBase
    {
        public static string DeviceType="TESTER";
        AmidaClientService.AmidaClientExportThread ExportTask;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (args.Length == 0)
                Service.DeviceType = "TESTER";
            else
                Service.DeviceType = args[0];
            ExportTask = new AmidaClientService.AmidaClientExportThread();      
            
        }

        protected override void OnStop()
        {
            ExportTask.Exit();
        }
    }
}
