using System;
using System.Collections.Generic;
using System.Text;

namespace AmidaClientService20.Messages
{
    public class VerifyNoteData
    {

       
        public string WaferID { get; set; }
        
        public string TestVerify { get; set; }
      
        public DateTime TestVerifyDate { get; set; }
       
        public string TPS { get; set; }
        
        public string MAP { get; set; }
       
        public string RCP { get; set; }
       
        public string Operators { get; set; }
        
        public DateTime StartTimes { get; set; }
      
        public DateTime StopTimes { get; set; }
       
        public long TouchDo { get; set; }
       
        public int Pass { get; set; }
        
        public int Fail { get; set; }
       
        public string PCID { get; set; }

        public string HasWarning { get; set; }

      //  public int WarningType { get; set; }

        public int ProbeShape { get; set; }

    }
}
