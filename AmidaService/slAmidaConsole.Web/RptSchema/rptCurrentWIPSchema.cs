using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

namespace slAmidaConsole.Web.RptSchema
{
    public class rptCurrentWIPSchema
    {
        [Display(Order=1)]
        public string MaskID { get; set; }
         [Display(Order = 2)]
        public int Processing  { get; set; }
         [Display(Order = 3)]
        public int Waiting  { get; set; }
         [Display(Order = 4)]
        public int Hold1  { get; set; }
         [Display(Order = 5)]
        public int Hold2  { get; set; }
         [Display(Order = 6)]
        public int Hold3  { get; set; }
         [Display(Order = 7)]
        public int Other  { get; set; }
         [Display(Order = 8)]
        public string Customer { get; set; }
         [Display(Order = 9)]
        public string RFDC { get; set; }
         [Display(Order = 10)]
        public string PF { get; set; }
         [Display(Order = 11)]
         public string Sponsor { get; set; }
        [Display(Order = 12)]
        public int  OnlineSingle { get; set; }
        [Display(Order = 13)]
        public int OnlineMulti { get; set; }
        [Display(Order = 14)]
        public int PEConfirmSingle { get; set; }
        [Display(Order = 15)]
        public int PEConfirmMulti { get; set; }
        [Display(Order = 16)]
        public int NewS { get; set; }
        [Display(Order = 17)]
        public int NewM { get; set; }
    }
}