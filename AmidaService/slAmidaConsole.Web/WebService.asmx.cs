using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
 

namespace slAmidaConsole.Web
{
    /// <summary>
    /// WebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
    // [System.Web.Script.Services.ScriptService]
        
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession=true )]
       
        public void RegisterSession(string userid)
        {
            this.Context.Session["userid"] = userid;
            
        }
        [WebMethod(EnableSession = true)]
        public void Logout(string userid)
        {
            this.Context.Session.Remove(userid);
        }
        [WebMethod(EnableSession = true)]
     
        public bool IsUserLogin(string userid)
        {
            if (Context.Session["userid"] == null)
                return false;
            else
             return Context.Session["userid"].ToString()==userid;
        }
    }
}
