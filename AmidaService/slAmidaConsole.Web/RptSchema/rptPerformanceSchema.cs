using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slAmidaConsole.Web.RptSchema
{
    public class rptPerformanceSchema
    {
        public string Operator { get; set; }
        public int? ProductTotal { get; set; }
        public int? VerifyTotal { get; set; }
        public int? Total { get; set; }

        public string XLabel
        {
            get {return Operator ;}


        }
    }
}