//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace sqltest
{
    using System;
    using System.Collections.Generic;
    
    public partial class PC_Rec_tbl
    {
        public int Idx { get; set; }
        public string PC_ID { get; set; }
        public string PC_org_status { get; set; }
        public string PC_status { get; set; }
        public string EQ_ID_for_PC { get; set; }
        public string PC_code_for_EQ { get; set; }
        public string PC_backreason { get; set; }
        public Nullable<float> PC_tip_level { get; set; }
        public Nullable<float> Currentmax_tip_size { get; set; }
        public Nullable<float> Current_length_of_needle_body { get; set; }
        public Nullable<int> Current_touchdown { get; set; }
        public Nullable<short> Current_times_of_adjusting_needle { get; set; }
        public Nullable<short> PC_ndl_position { get; set; }
        public string Modifier { get; set; }
        public string PC_ndl_pos_Modifier { get; set; }
        public string PC_comment { get; set; }
        public Nullable<System.DateTime> PC_rec_time { get; set; }
        public Nullable<System.DateTime> PC_ndl_pos_rec_time { get; set; }
    }
}
