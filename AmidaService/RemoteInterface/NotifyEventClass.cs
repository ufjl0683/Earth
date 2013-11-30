using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteInterface
{
    [Serializable]
   public  class NotifyEventObject
    {
        public EventEnumType type;
        public object EventObj=null;
       public string deviceName;
    //   public int port=-1;

       //public NotifyEventObject(EventEnumType type, object objEvent)
       // {
       //     this.EventObj = objEvent;
       //     this.type = type;
       //     this.devip = "*";
       // }
       public NotifyEventObject(EventEnumType type, string deviceName, object objEvent)
       {
           this.type = type;
           this.deviceName = deviceName;
           this.EventObj = objEvent;
         //  this.port = -1;//all
       }
       //public NotifyEventObject(EventEnumType type, string device_ip,int port, object objEvent):this( type,  device_ip,  objEvent)
       //{
       //    this.port=port;
       //}
    }

  public  enum EventEnumType
    {
      TEST,
      InportCommand,
      Message
     
      //  TC_Connect_Status_Change


       
        
    }


   
}
