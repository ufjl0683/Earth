using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace slAmidaConsole.Web.RptSchema
{
    public class rptYieldVSOpSchema
    {
        [Display(Order=1)]
        public string Operator { get; set; }
         [Display(Order = 2)]
        public double Max { get; set; }
         [Display(Order = 5)]
        public double Min { get; set; }
          [Display(Order = 4)]
        public double Avg { get; set; }
          [Display(Order = 3)]
        public double Medium { get; set; }
          [Display(Order = 7)]
          public int Count { get; set; }
    }
}