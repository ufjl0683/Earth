using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace slAmidaConsole.Web.RptSchema
{
    public class rptYieldVSPCSchema
    {
          [Display(Order = 1)]
        public string XLabel
        {
            get
            {
                try
                {
                    //  return PCID.Substring(0, 5) + "PC" + PCID.Substring(7, 2) + "-" + PCID.Substring(9, 1);
                    return PCID.Substring(9, 1) + PCID.Substring(6, 3) + "-" + PCID.Substring(13, 1) + PCID.Substring(17, 2);

                }
                catch
                {
                    return PCID;
                }
            }
        }
          [Display(Order = 2)]
        public string PCID { get; set; }
          [Display(Order = 3)]
        public double Max { get; set; }
          [Display(Order = 6)]
        public double Min { get; set; }
          [Display(Order = 5)]
        public double Avg { get; set; }
          [Display(Order = 4)]
        public double Medium { get; set; }
          [Display(Order = 7)]
          public int Count { get; set; }
    }
}