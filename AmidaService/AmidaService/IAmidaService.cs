using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace AmidaServerService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService1"。
    [ServiceContract(CallbackContract=typeof(ICallBack))]
    public interface IAmidaService
    {
        [OperationContract]
        string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract]
        //void InsertIntoVerifyNote(VerifyNoteData data);

        [OperationContract]
    //   [FaultContract(typeof(string))]
        void Register(string key,string DeviceType);

        [OperationContract]
        void SayServerHello();

        [OperationContract]
     //   [FaultContract(typeof(string))]
         RegisterDeviceInfo[] GetAllConnectionInfo();

        [OperationContract]
       // [FaultContract(typeof(string))]
        void ExportCommand(string PCName,string CmdType, string xml);
        [OperationContract]
       
        void Down(string PCName,string UserID,string SubStatus);
        [OperationContract]
     //  [FaultContract(typeof(string))]
        void Release(string PCName,string UserID);

        [OperationContract]
        void NotifyRCP(string PCName, string title, string text);
        // TODO: 在此新增您的服務作業
    }
  
    public enum InportCmdType
    {
        InportFile
    };
    public interface ICallBack
    {

        [OperationContract(IsOneWay = true)]
        void ReceivedCommand(string xmlCmd, InportCmdType cmdType,string LeadingFileName);
        [OperationContract(IsOneWay = true)]
        void SayHello(string hello);

        [OperationContract(IsOneWay = true)]
        void NotifyConnectionChanged();

        [OperationContract(IsOneWay = true)]
        void NotifyStatusChanged(string pcname,RegisterDeviceInfo info);

        [OperationContract(IsOneWay = true)]
        void NotifyClientExported(string PCName, string CmdType);

        [OperationContract(IsOneWay = true)]
        void NotifyClientYieldChange(string PCName,double yield,string LotId);
    }
    // 使用以下範例中所示的資料合約，新增複合型別至服務作業
    //[DataContract]
    //public class ReportStatusChangedData
    //{
    //    [DataMember]
         

    //}
    //[DataContract]
    
    //public class VerifyNoteData
    //{

    //    [DataMember]
    //    public string WaferID { get; set; }
    //    [DataMember]
    //    public string TestVerify { get; set; }
    //    [DataMember]
    //    public DateTime TestVerifyDate { get; set; }
    //    [DataMember]
    //    public string TPS { get; set; }
    //    [DataMember]
    //    public string MAP { get; set; }
    //    [DataMember]
    //    public string RCP { get; set; }
    //    [DataMember]
    //    public string Operators { get; set; }
    //    [DataMember]
    //    public DateTime StartTimes { get; set; }
    //    [DataMember]
    //    public DateTime StopTimes { get; set; }
    //    [DataMember]
    //    public long TouchDo { get; set; }
    //    [DataMember]
    //    public int Pass { get; set; }
    //    [DataMember]
    //    public int Fail { get; set; }
    //    [DataMember]
    //    public string PCID { get; set; }

    //}
    [DataContract]
    public class RegisterDeviceInfo
    {
       
        [DataMember]
         [Display(Order=1)]
        public   string PcName { get; set; }
        [DataMember]
        public string DeviceType { get; set; }
        [DataMember]
        [Display(Order=2)]
        public string Status { get; set; }
         [DataMember]
        [Display(Order = 3)]
        public string SubStatus { get; set; }
        [DataMember]
        public DateTime ConnectedTime { get; set; }
        [DataMember]
        public double Progress{get;set;}  //percent
        [DataMember]
        public string CurrentWaferId { get; set; }
        [DataMember]
        public string WarningMessage { get; set; }
        [DataMember]
        public int WarningType { get; set; }
        [DataMember]
        public string ProbeCardId { get; set; } //ui
        [DataMember]
        public double TimeRemain { get; set; }
        [DataMember]
        public int total_num_wafer { get; set; }  //總共待測 Wafer 數
        [DataMember]
        public int tested_num_wafer { get; set; } //目前以策Wafer 數
        [DataMember]
        public int total_num_chip { get; set; }  //總待測chip數 ,Product Only
        [DataMember]
        public int tested_num_chip { get; set; }
        [DataMember]
        public string lot_id { get; set; }  // ui
        [DataMember]
       
        public DateTime StatusBeginTime { get; set; }
        [DataMember]
        public DateTime WarningBeginTime { get; set; }
        [DataMember]
        public string eq_comment { get; set; }
        [DataMember]
        public string eq_type { get; set; }
        [DataMember]
        public string eq_area { get; set; }
        [DataMember]
        public string eq_prober { get; set; }
        [DataMember]
        public double yield { get; set; }

        [DataMember]
        public bool IsExportPending { get; set; }
       
    }


     
}
