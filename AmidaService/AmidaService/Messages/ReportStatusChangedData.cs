using System;
using System.Collections.Generic;
using System.Text;

namespace AmidaClientService20.Messages
{
   public  class ReportStatusChangedData
    {
        public string eq_id { get; set; }     //機台編號
       public string eq_status { get; set; }  //機台狀態 Product,Verify,Idle,LEM
       public string lot_id { get; set; }     // Lot ID
       public string probe_card_id { get; set; } //ProbeCardID
       public string recipe { get; set; }           //recipe file name
       public string fab{get;set;}                  //fab1~3
       public string  eq_operator {get;set;}     //操作員編號
       public int total_num_wafer { get; set; }  //待測總wafer數
       public DateTime start_time { get; set; }    //起始時間
       public string wafer_id { get; set; }  //verify/product 測試 wafer id 清單
       public double over_drive { get; set; }  // verify / product 開始測試之針壓
       public string sub_status { get; set; }
    }

   
}
