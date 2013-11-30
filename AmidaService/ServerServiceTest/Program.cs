using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Diagnostics;
using AmidaServerService;
using AmidaService;
using RemoteInterface;


namespace ServerServiceTest
{
    class Program
    {
      // static AmidaServerService.AmidaService service;
       // static AmidaServerService.EventNotifyServer NotifyServer;
        
        static void Main(string[] args)
        {
         //   string xml =AmidaService.WinPosWS.WS_XML_Factory.GetPartInfoXMLRequest("david", "WS321-09");

        //    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
          //  doc.InnerXml = xml;
            ServiceHost host = new ServiceHost(AmidaService.Service.MyServiceObject = new AmidaServerService.AmidaService());
            host.Open();

            ServiceHost RestHost = new ServiceHost(AmidaService.Service.MyRestObj = new RestService());

            RestHost.Open();
            Console.WriteLine("Host Started!");

            EventLog mylog = new EventLog() { Source = "AmidaService" };
            mylog.WriteEntry("AmidaService started!");

       //     new  System.Threading.Thread(Task).Start();


            ServerFactory.SetChannelPort(9090);
            ServerFactory.RegisterRemoteObject(typeof(RemoteObject), "AmidaService");
           
            AmidaService.Service.NotifyServer = new EventNotifyServer(9091);
            Console.ReadLine();
          //  Task();
        }

        static void  Task()
        {
            while(true)
            {

                AmidaService.Service.NotifyServer.NotifyAll(
                    new NotifyEventObject( EventEnumType.Message,System.Environment.MachineName, new NotifyMessage()
                    { text="hello", title="Message from Admin"})
                     
                    
                    );
                //foreach (RegisterData regdata in AmidaService.Service.MyServiceObject.dictClientCallBacks.Values.ToArray<RegisterData>())
                //{
                    
                   

                //    //System.Threading.ThreadPool.QueueUserWorkItem((s)=>
                //    //{
                //    //  ((RegisterData)s).Callback.ReceivedCommand("Hi export file from  server", AmidaServerService.InportCmdType.InportFile,"Test"); 

                //    //},regdata);
               
                 
                //}
                System.Threading.Thread.Sleep(1000 * 10);
                
            }
        }
    }
}
