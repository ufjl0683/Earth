
namespace slAmidaConsole.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Data.Objects.DataClasses;


    // MetadataTypeAttribute 會將 sysdiagramsMetadata 識別為
    // 帶有 sysdiagrams 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(sysdiagrams.sysdiagramsMetadata))]
    public partial class sysdiagrams
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 sysdiagrams 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class sysdiagramsMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private sysdiagramsMetadata()
            {
            }

            public byte[] definition { get; set; }

            public int diagram_id { get; set; }

            public string name { get; set; }

            public int principal_id { get; set; }

            public Nullable<int> version { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblAlarmMetadata 識別為
    // 帶有 tblAlarm 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblAlarm.tblAlarmMetadata))]
    public partial class tblAlarm
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblAlarm 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblAlarmMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblAlarmMetadata()
            {
            }

            public Nullable<DateTime> end_time { get; set; }

            public string eq_id { get; set; }

            public int identify { get; set; }

            public Nullable<DateTime> start_time { get; set; }

            public string warning_message { get; set; }

            public Nullable<int> warning_type { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblEQMetadata 識別為
    // 帶有 tblEQ 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblEQ.tblEQMetadata))]
    public partial class tblEQ
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblEQ 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblEQMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblEQMetadata()
            {
            }

            public Nullable<long> current_identify { get; set; }

            public string current_test_wafer_id { get; set; }

            public Nullable<int> current_warning_identify { get; set; }
            [Display(AutoGenerateField = true, Order = 4)]
            public string eq_comment { get; set; }

            public string eq_prober { get; set; }

            public DateTime eq_release_time { get; set; }

            public string eq_tester { get; set; }

            public string eq_type { get; set; }
            [Display(AutoGenerateField=false,Order=-1,Name="EQID")]
            public string eqi_id { get; set; }

            public Nullable<int> expected_remain_time { get; set; }
            [Display(AutoGenerateField = false, Order =2 )]
            public string fab { get; set; }

            [Display(AutoGenerateField=false)]
            public string IsWarnig { get; set; }

            public string lot_id { get; set; }

            public string @operator { get; set; }

            public string probe_card_id { get; set; }

            public string recipe { get; set; }

            public Nullable<DateTime> start_time { get; set; }
            [Display(AutoGenerateField = false, Order = 3)]
            public string status { get; set; }

            public int tested_num_chip { get; set; }

            public int tested_num_wafer { get; set; }

            public int total_num_chip { get; set; }

            public int total_num_wafer { get; set; }
            public string wafer_id { get; set; }
           public Nullable<double> over_drive { get; set; }  // verify / product 開始測試之針壓
            public string sub_status { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblEQHistoryMetadata 識別為
    // 帶有 tblEQHistory 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblEQHistory.tblEQHistoryMetadata))]
    public partial class tblEQHistory
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblEQHistory 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblEQHistoryMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblEQHistoryMetadata()
            {
            }

            public string eq_comment { get; set; }

            public string eq_id { get; set; }

            public long identify { get; set; }

            public bool IsFinish { get; set; }

            public string lot_id { get; set; }

            public string @operator { get; set; }

            public string probe_card_id { get; set; }

            public string recipe { get; set; }

            public DateTime start_time { get; set; }

            public string status { get; set; }

            public Nullable<DateTime> stop_time { get; set; }

            public Nullable<int> tested_num_wafer { get; set; }

            public Nullable<int> total_num_wafer { get; set; }
            public string wafer_id_in { get; set; }  //verify/product 測試 wafer id 清單
            public string wafer_id_out { get; set; }  //verify/product 測試 wafer id 清單
           
            public Nullable<double> over_drive_in { get; set; }  // verify / product 開始測試之針壓
            public Nullable<double> over_drive_out { get; set; }  // verify / product 開始測試之針壓
            public string sub_status { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblUserMetadata 識別為
    // 帶有 tblUser 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblUser.tblUserMetadata))]
    public partial class tblUser
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblUser 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblUserMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblUserMetadata()
            {
            }

            public string Password { get; set; }

            public string UserID { get; set; }
            
            public int GroupID { get; set; }

            public string UserName { get; set; }
          
            [Include]
            public EntityCollection<tblUserGroup> tblUserGroup  { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblVerifyNoteMetadata 識別為
    // 帶有 tblVerifyNote 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblVerifyNote.tblVerifyNoteMetadata))]
    public partial class tblVerifyNote
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblVerifyNote 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblVerifyNoteMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblVerifyNoteMetadata()
            {
            }

            public Nullable<int> Fail { get; set; }

            public string HasWarning { get; set; }

            public string MAP { get; set; }

            public string Operators { get; set; }

            public Nullable<int> Pass { get; set; }
             [Display(Order = 7)]
            public string PCID { get; set; }

            public Nullable<int> ProbeShape { get; set; }

            public string RCP { get; set; }
            [Display( Order=1)]
            public long SeqNo { get; set; }
             [Display(Order = 2)]
            public Nullable<DateTime> StartTimes { get; set; }
             [Display(Order = 3)]
            public Nullable<DateTime> StopTimes { get; set; }
             [Display(Order = 4)]
            public string TestVerify { get; set; }

            public Nullable<DateTime> TestVerifyDate { get; set; }

            public Nullable<long> TouchDo { get; set; }
             [Display(Order = 7)]
            public string TPS { get; set; }
             [Display(Order = 5)]
            public string WaferID { get; set; }
             public Nullable<double> over_drive { get; set; }
        }

       
    }
    // MetadataTypeAttribute 會將 tblMenuMetadata 識別為
    // 帶有 tblMenu 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblMenu.tblMenuMetadata))]
    public partial class tblMenu
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblMenu 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblMenuMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblMenuMetadata()
            {
            }

            public int MenuGroupID { get; set; }

            public int MenuID { get; set; }

            public string MenuName { get; set; }

            public tblMenuGroup tblMenuGroup { get; set; }

            public EntityCollection<tblUserGroupMenu> tblUserGroupMenu { get; set; }

            public string XAML { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblMenuGroupMetadata 識別為
    // 帶有 tblMenuGroup 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblMenuGroup.tblMenuGroupMetadata))]
    public partial class tblMenuGroup
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblMenuGroup 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblMenuGroupMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblMenuGroupMetadata()
            {
            }

            public string GroupName { get; set; }

            public int MenuGroupID { get; set; }
            public int MenuOrder { get; set; }

            public EntityCollection<tblMenu> tblMenu { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblUserGroupMetadata 識別為
    // 帶有 tblUserGroup 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblUserGroup.tblUserGroupMetadata))]
    public partial class tblUserGroup
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblUserGroup 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblUserGroupMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblUserGroupMetadata()
            {
            }

            public int GroupID { get; set; }

            public string GroupName { get; set; }
            [Display(AutoGenerateField=false)]
            public EntityCollection<tblUser> tblUser { get; set; }
             [Display(AutoGenerateField = false)]
            public EntityCollection<tblUserGroupMenu> tblUserGroupMenu { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblUserGroupMenuMetadata 識別為
    // 帶有 tblUserGroupMenu 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblUserGroupMenu.tblUserGroupMenuMetadata))]
    public partial class tblUserGroupMenu
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblUserGroupMenu 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblUserGroupMenuMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblUserGroupMenuMetadata()
            {
            }

            public int GroupID { get; set; }

            public bool IsAllow { get; set; }

            public int MenuID { get; set; }
            [Include]
            public tblMenu tblMenu { get; set; }
            [Include]
            public tblUserGroup tblUserGroup { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 vwUserMenuAllowMetadata 識別為
    // 帶有 vwUserMenuAllow 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(vwUserMenuAllow.vwUserMenuAllowMetadata))]
    public partial class vwUserMenuAllow
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 vwUserMenuAllow 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwUserMenuAllowMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private vwUserMenuAllowMetadata()
            {
            }

            public int GroupID { get; set; }

            public string GroupName { get; set; }

            public bool IsAllow { get; set; }

            public int MenuGroupID { get; set; }

            public int MenuID { get; set; }

            public string MenuName { get; set; }

            public string UserID { get; set; }

            public string XAML { get; set; }

            public int MenuOrder { get; set; }
        }
    }

    [MetadataTypeAttribute(typeof(tblVerifyTimeLog.tblVerifyTimeLogMetadata))]
    public partial class tblVerifyTimeLog
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblVerifyTimeLog 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblVerifyTimeLogMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblVerifyTimeLogMetadata()
            {
            }

            public string MaskID { get; set; }

            public int Minute { get; set; }

            public long SeqNo { get; set; }
        }
    }

    // MetadataTypeAttribute 會將 tblVerifyTimeRefMetadata 識別為
    // 帶有 tblVerifyTimeRef 類別其他中繼資料的類別。
    [MetadataTypeAttribute(typeof(tblVerifyTimeRef.tblVerifyTimeRefMetadata))]
    public partial class tblVerifyTimeRef
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblVerifyTimeRef 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblVerifyTimeRefMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblVerifyTimeRefMetadata()
            {
            }

            public string MaskID { get; set; }

            public int Minutes { get; set; }
        }
    }


    [MetadataTypeAttribute(typeof(tblMaskInfo.tblMaskInfoMetadata))]
    public partial class tblMaskInfo
    {

        // 這個類別可讓您將自訂屬性 (Attribute) 附加到 tblMaskInfo 類別
        // 的 properties。
        //
        // 例如，下列程式碼將 Xyz 屬性標記為
        // 必要的屬性，並指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblMaskInfoMetadata
        {

            // 中繼資料類別本就不應該具現化。
            private tblMaskInfoMetadata()
            {
            }

            [Display(Order = 2)]
            public string Customer { get; set; }
             [Display(Order = 1)]
            public string MaskID { get; set; }
             [Display(Order = 3)]
            public string PF { get; set; }
             [Display(Order = 4)]
            public string RFDC { get; set; }
             [Display(Order = 5)]
            public string Sponsor { get; set; }
        }
    }
}
