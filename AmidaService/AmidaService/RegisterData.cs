using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmidaServerService;

namespace AmidaService
{
  
    public class RegisterData
    {

        public RegisterDeviceInfo info;

      
        public string Key
        {
            get
            {
                return info.PcName + "-" + info.DeviceType;
            }
        }
        public AmidaServerService.ICallBack Callback;
    }
}
