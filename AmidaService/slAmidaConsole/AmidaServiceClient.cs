using System;
using System.Collections.Generic;
using System.Linq;
using slAmidaConsole.AmidaService;
//using System.Web;

namespace slAmidaConsole
{

    public delegate void ClientExportedCommandHandler (string Pcname,string CmdType);
    public delegate void ClientYieldChangedHandler (string pcname,double yield,string lotid);
    public delegate void ClientStatusChangedHandler(string Pcname,RegisterDeviceInfo info);
    public class AmidaServiceClient:IAmidaServiceCallback
    {
        public event EventHandler OnSayHello;
        public event EventHandler OnRemoteConnectionChange;
        public event ClientExportedCommandHandler OnClientExportedCommand;
        public event ClientStatusChangedHandler OnClientStatusChanged;
        public event ClientYieldChangedHandler OnClientYieldChanged;
        MyClient myclient;
        public AmidaServiceClient()
        {
            myclient = new MyClient(new System.ServiceModel.InstanceContext(this), "CustomBinding_IAmidaService");

        }

        public slAmidaConsole.AmidaService.AmidaServiceClient getClient()
        {
            return myclient;
        }
        public void ReceivedCommand(string xmlCmd, InportCmdType cmdType, string LeadingFileName)
        {
            //throw new NotImplementedException();
          //  AmidaService.RegisterDeviceInfo info=new RegisterDeviceInfo( ){ 
        }

        public void SayHello(string hello)
        {
            if (this.OnSayHello != null)
                this.OnSayHello(this, null);
          //  throw new NotImplementedException();
        }




        public void NotifyConnectionChanged()
        {

            if (OnRemoteConnectionChange != null)
                this.OnRemoteConnectionChange(this, null);
          //  throw new NotImplementedException();
        }


        public void NotifyClientExported(string PCName, string CmdType)
        {
            if (this.OnClientExportedCommand != null)
                this.OnClientExportedCommand(PCName, CmdType);
          //  throw new NotImplementedException();
        }


        public void NotifyStatusChanged(string pcname, RegisterDeviceInfo info)
        {
            if (this.OnClientStatusChanged != null)
                this.OnClientStatusChanged(pcname,info);
           // throw new NotImplementedException();
        }


        public void NotifyClientYieldChange(string PCName, double yield, string LotId)
        {
            if (this.OnClientYieldChanged != null)
                this.OnClientYieldChanged(PCName, yield, LotId);
           // throw new NotImplementedException();
        }
    }

   
}