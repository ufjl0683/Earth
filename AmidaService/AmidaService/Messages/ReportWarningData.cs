using System;
using System.Collections.Generic;
using System.Text;

namespace AmidaClientService20.Messages
{
   public  class ReportWarningData
    {
       public string eq_id { get; set; }  //機台編號
       public string warning_message{get;set;} //警告訊息內容，建議不要含中文字,若含中文字需 utf-8 編碼
       public int warning_type { get; set; }   // 1. continue_fail,2.command fail 
       public DateTime timestamp {get;set;}  //發生警告訊息之時間戳記
       public string eq_operator { get; set; }
       public string WaferID { get; set; }
       public string probe_card_id { get; set; }
       public bool isfinished { get; set; }  //是否已處置 ,通知時 為true/操作員已處理為 false

    }
}
