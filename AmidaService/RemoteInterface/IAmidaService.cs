using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteInterface
{
    public interface IAmidaService
    {
      

        void Register(string key, string DeviceType);

      
        void SayServerHello();

      

      
        void ExportCommand(string PcName, string CmdType, string xml);

        void ReportExportPending(string PcName, bool IsPending);
        
    }

    public enum InportCmdType
    {
        InportFile
    };
}
