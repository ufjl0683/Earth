using System;
using System.Collections.Generic;
using System.Text;

namespace AmidaClientService20.Messages
{
    public class ReportProgressData
    {
        public string eq_id { get; set; }  //機台編號
      //  public string fab { get; set; }    // FAB1~3
        public string status { get; set; }  //Product,Verify,Idle,LEM
        public string current_test_wafer_id { get; set; }  //目前測試中的WaferID, Product Verify
        public int total_num_wafer { get; set; }  //總共待測 Wafer 數
        public int tested_num_wafer { get; set; } //目前以策Wafer 數
        public int total_num_chip { get; set; }  //總待測chip數 ,Product Only
        public int tested_num_chip {get;set;}    //目前已測 Chip 數,Product only
        public DateTime timestamp {get;set;}   //檔案輸出時間戳記

    }
}
