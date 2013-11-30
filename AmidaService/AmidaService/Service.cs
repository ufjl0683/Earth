using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using RemoteInterface;


namespace AmidaService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("AmidaService"))
                System.Diagnostics.EventLog.CreateEventSource(new System.Diagnostics.EventSourceCreationData("AmidaService", "AmidaLog"));
        }

        public static AmidaServerService.AmidaService MyServiceObject;
        public static AmidaServerService.RestService MyRestObj;
        public static EventNotifyServer NotifyServer;

        protected override void OnStart(string[] args)
        {

        


            MyServiceObject = new AmidaServerService.AmidaService();
           ServiceHost host = new ServiceHost(MyServiceObject);
           MyRestObj=new AmidaServerService.RestService();
           ServiceHost restHost = new ServiceHost(MyRestObj);
            host.Open();
            restHost.Open();
            ServerFactory.SetChannelPort(9090);
            ServerFactory.RegisterRemoteObject(typeof(RemoteObject), "AmidaService");

            NotifyServer = new EventNotifyServer(9091);
            
            //EventLog mylog = new EventLog() { Source = "AmidaService" };
            //mylog.WriteEntry("AmidaService started!");

           

        }

        protected override void OnStop()
        {
            //EventLog mylog = new EventLog() { Source = "AmidaService" };
            //mylog.WriteEntry("AmidaService stop!");
        }
    }
}
