using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace slAmidaConsole.Web.RptSchema
{
    public class rptRCPStatusIndex
    {
        [Display(Order=1)]
        public string EqID { get; set; }
             [Display(Order = 2)]
        public string Status { get; set; }
             [Display(Order = 6)]
        public string Area { get; set; }
             [Display(Order = 5)]
        public string EQ_Type { get; set; }
             [Display(Order = 4)]
        public string TesterType { get; set; }
             [Display(Order = 3)]
        public double TotalTime { get; set; }
     }
    public class rptStatusDetail
    {
        public string eqid { get; set; }
        public string Status{get;set;}
        public DateTime? starttimes { get; set; }
        public DateTime? stoptimes { get; set; }
        public string Area { get; set; }
        public string EQ_Type { get; set; }
        public string EQ_Tester { get; set; }
        public double TotalHours
        {
            get
            {
                if (starttimes == null || stoptimes == null)
                    return 0;
                return   (((DateTime)stoptimes).Subtract((DateTime)starttimes).TotalHours) ;
            }
        }
    }
}



 