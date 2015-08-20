using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
 


namespace AmidaServerService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IRestService"。
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate="DoWork")]
        string  DoWork();

        [OperationContract]
        [WebGet]
       // [WebGet(UriTemplate = "GetConfig?OPID={OPID}&PCID={PCID}&SM={SM}&TestMode={TestMode}&LotID={LotID}&Wafer={Wafer}&AP={AP}&RCP={RCP}")]
        ConfigInfo GetConfig(string OPID, string PCID, string SM, string TestMode, string LotID, string Wafer, string PF, string RCP);

        [WebGet]
        // [WebGet(UriTemplate = "GetConfig?OPID={OPID}&PCID={PCID}&SM={SM}&TestMode={TestMode}&LotID={LotID}&Wafer={Wafer}&AP={AP}&RCP={RCP}")]
        ConfigInfo GetConfig2(string OPID, string PCID, string SM, string TestMode, string LotID, string Wafer, string PF, string RCP);
        [OperationContract]
        [WebGet]
        string AutoMES(string INOUT, string OPID, string PARTID, string EQPID, string OPENO);
         [OperationContract]
        [WebGet]
      string AutoPMS(string INOUT, string OPID, string PARTID, string EQPID, string OPENO, string SM, string Wafer);
         [OperationContract]
        [WebGet]
        string AutoMESPCM(string INOUT, string OPID, string PARTID, string EQPID/*, string OPENO*/);
    }
}
