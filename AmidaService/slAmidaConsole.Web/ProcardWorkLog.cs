using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slAmidaConsole.Web
{
    public class ProcardWorkLog
    {
        public DateTime? TimeStamp { get; set; }
        public string Lot_ID { get; set; }
        public string Wafer_ID_IN { get; set; }
        public string Wafer_ID_OUT { get; set; }
        public int? Num_Tested_Wafer { get; set; }
        public string TPS { get; set; }
        public double? OD_OUT { get; set; }
        public double? OD_IN { get; set; }
        public string RCP { get; set; }
        public string Operator { get; set; }
        public double? NeedleBody { get; set; }
        public double? NeedleLength { get; set; }
        public string NeedleStatus { get; set; }
        public string Comment { get; set; }
        public string recipe { get; set; }
        public string status { get; set; }
        public string T_V
        {

            get{
                if (Is_pc_rec_tbl)
                    return "";
                if (status == "Product")
                    return "T";
                else
                    return "V";
            }
        
        
        }
        public bool Is_pc_rec_tbl
        {
            get;
            set;

        }
    }
}