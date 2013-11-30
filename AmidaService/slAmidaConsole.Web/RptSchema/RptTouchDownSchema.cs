using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slAmidaConsole.Web.RptSchema
{
    [Serializable]
    public class RptTouchDownSchema
    {

        public string PCID { get; set; }
        public long? Touch_Down_Total { get; set; }
        public long? Pass_Total { get; set; }
        public long? Fail_Total { get; set; }
        public string PC_Status { get; set; }
      //  =LEFT(A4,5) & "PC" & MID(A4,8,2) & "-" & MID(A4,10,1)

        public string XLabel
        {
            get
            {
                try
                {
                  //  return PCID.Substring(0, 5) + "PC" + PCID.Substring(7, 2) + "-" + PCID.Substring(9, 1);
                    return PCID.Substring(9, 1) +PCID.Substring(6, 3) +"-"+ PCID.Substring(13, 1)+PCID.Substring(17,2);
                
                }
                catch
                {
                    return PCID;
                }
            }
        }
    }
}