using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slAmidaConsole.Web.RptSchema
{
    public class rptRCPProductivitySchema
    {

        public string RCP { get; set; }
        public string TestVerify { get; set; }
        public int? Number { get; set; }
        public string XLabel
        {
            get
            {
                return RCP;
            }
        }
    }
}