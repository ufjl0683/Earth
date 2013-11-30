using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmidaService
{
  public  class RemoteObject:RemoteInterface.RemoteClassBase,RemoteInterface.IAmidaService
    {
        public void Register(string key, string DeviceType)
        {
            try
            {
                Service.MyServiceObject.RegisterFromRemoting(key, DeviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
                throw new RemoteInterface.RemoteException(ex.Message + "," + ex.StackTrace);
            }
            //throw new NotImplementedException();
        }

        public void SayServerHello()
        {
           // throw new NotImplementedException();
        }

        public void ExportCommand(string PCName,string CmdType, string xml)
        {
            try
            {
                Service.MyServiceObject.ExportCommand(PCName, CmdType, xml);
            }
            catch (Exception ex)
            {
                throw new RemoteInterface.RemoteException(ex.Message + "," + ex.StackTrace);
            }
           // throw new NotImplementedException();
        }

        public void Down(string PcName,string UserID)
        {
            Messages.ImportCmdData cmdData=new Messages.ImportCmdData(){ Cmd="Down", start_time=DateTime.Now,eq_operator=UserID};
            System.Xml.Serialization.XmlSerializer sr=new System.Xml.Serialization.XmlSerializer(typeof( Messages.ImportCmdData));
            System.IO.MemoryStream ms=new System.IO.MemoryStream();
            sr.Serialize(ms,cmdData);
            string xmlcmd= System.Text.Encoding.Unicode.GetString(ms.ToArray());
            RemoteInterface.Inport.InportCommand inportCmd=new RemoteInterface.Inport.InportCommand(xmlcmd,"Down"+System.Guid.NewGuid().ToString() );
            Service.NotifyServer.NotifyAll(new RemoteInterface.NotifyEventObject(RemoteInterface.EventEnumType.InportCommand, PcName, inportCmd));

        }
        public void Release(string PcName, string UserID)
        {
            Messages.ImportCmdData cmdData = new Messages.ImportCmdData() { Cmd = "Release", eq_operator =UserID,start_time=DateTime.Now };
            System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(Messages.ImportCmdData));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            sr.Serialize(ms, cmdData);
            string xmlcmd = System.Text.Encoding.Unicode.GetString(ms.ToArray());
            RemoteInterface.Inport.InportCommand inportCmd = new RemoteInterface.Inport.InportCommand(xmlcmd, "Release" + System.Guid.NewGuid().ToString());
            Service.NotifyServer.NotifyAll(new RemoteInterface.NotifyEventObject(RemoteInterface.EventEnumType.InportCommand, PcName, inportCmd));
        }

      public   void ReportExportPending(string PcName, bool IsPending)
      {
          try
          {
              Service.MyServiceObject.ReportExportPending(PcName, IsPending); 
          }
          catch (Exception ex)
          {
              throw new RemoteInterface.RemoteException(ex.Message + "," + ex.StackTrace);
          }
      }


          
    }
}
