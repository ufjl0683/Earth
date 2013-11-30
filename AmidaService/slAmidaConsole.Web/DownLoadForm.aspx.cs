using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Reflection;
//using System.Windows.Forms;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace slAmidaConsole.Web
{
    public partial class DownLoadForm : System.Web.UI.Page
    {

        string filename="download"  ;
        int rptid;
        slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
        //string selectday, selectYestaday,Istilt,Zaxis;
        protected void Page_Load(object sender, EventArgs e)
        {
            //WriteXls();
            //string sensorID = Request["id"].ToString(), selectDate ="";
            
            //selectDate = Request["date"].ToString();
            //Istilt = Request["Istilt"].ToString();

           
            Response.Clear();
           // Export_CVS_Funtion(sensorID,selectDate);

           DataTable dt= ExportExcel( );
           if (dt != null)
           {
               GridView1.DataSource = dt;
               GridView1.DataBind();
               Response.Clear();
               Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
               Response.ContentType = "application/vnd.ms-excel";
               Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html\";charset=\"utf-8\">");

               //   StringWriter sw = new StringWriter();

               //  HtmlTextWriter htw = new HtmlTextWriter(sw);

               //關閉換頁跟排序
               GridView1.AllowSorting = false;
               GridView1.AllowPaging = false;
               Response.Clear();
           }
        }
        
        private DataTable ExportExcel( )
        {
            DataTable dt ;//= new DataTable("TouchDo");
            rptid = System.Convert.ToInt32(Request["rptid"]);

            if (rptid == 1)
                return GenerateRtpTouchDo();
            else if (rptid == 2)
                return GenerateRtpPerformanceIndex();
            else if (rptid == 3)
                return GenerateRptRCPProductivity();
            else if (rptid == 4)
                return GenerateTblCurrentWIP();
            else if (rptid == 5)
                return GenerateYeildVSOp();
            else if (rptid == 6)
                return GenerateYieldVSRCP();
            else if (rptid == 7)
                return GenerateYeildVSPC();
            else if (rptid == 9)
                return GenerateStatusIndex();
            else if (rptid == 11)
            {
                DownLoadDatableToCsv(CreateCSVString(GenerateTblVerifyNote()));
                return null;
            }
            else if (rptid == 12)
            {
                DownLoadDatableToCsv(CreateCSVString(GenerateTblEQ()));
                return null;
                //  return GenerateTblEQ();
            }
            else if (rptid == 13)
            {
                DownLoadDatableToCsv(CreateCSVString(GenerateTblEQHistory()));
                return null;

                // return GenerateTblEQHistory();
            }
            else if (rptid == 14)
            {
                DownLoadDatableToCsv(CreateCSVString(GenerateTblAlarm()));
                return null;
                //  return GenerateTblAlarm();
            }
            else
                return null;
        //string connstr=    System.Configuration.ConfigurationManager.
        // ConnectionStrings["AmidaEntities"].ConnectionString;
        //SqlConnection conn = new SqlConnection(sql);
        //conn.Open();

        //conn.Close();

        }
        DataTable GenerateStatusIndex()
        {
            string status ;

            this.lblTitle.Text = "RCP Status Index";
            if (Request["status"] == null)
                status = "";
            else
                status = Request["status"].ToString().Trim();
            DateTime start_times, stop_times;
            start_times = Convert.ToDateTime(Request["starttimes"]);
            stop_times = Convert.ToDateTime(Request["stoptimes"]);

            AmidaEntities db = new AmidaEntities();


            var q = from n in db.tblEQHistory select n;/*join m in db.tblEQ on n.eq_id equals m.eqi_id select new { n.eq_id, n.start_time, n.stop_time, n.IsFinish, n.status, m.eq_area, m.eq_type, m.eq_tester }; */
            if (status.Trim() != "")
                q = q.Where(n => n.status == status);
           // q = q.Where(n => n.start_time >= starttimes && n.stop_time <= stoptimes && n.IsFinish == true);
            q = q.Where(n => !(n.start_time < start_times && n.stop_time < start_times || n.start_time > stop_times && n.stop_time > stop_times) || n.start_time <= start_times && n.stop_time == null);
            var q1 = from n in q
                     join m in db.tblEQ on n.eq_id equals m.eqi_id
                     select new RptSchema.rptStatusDetail()
                     {
                         Status = n.status,
                         Area = m.eq_area,
                         eqid = n.eq_id,
                         EQ_Tester = m.eq_tester,
                         EQ_Type = m.eq_prober,
                         starttimes = (n.start_time < start_times) ? start_times : n.start_time,
                         stoptimes = (n.stop_time == null || n.stop_time > stop_times) ? stop_times : n.stop_time


                     };




            var q2 = from n in q1.ToList()
                     group n by new { n.eqid, n.Status, n.EQ_Tester, n.EQ_Type, n.Area }
                         into g
                         select new RptSchema.rptRCPStatusIndex()
                         {
                             EqID = g.Key.eqid,
                             Area = g.Key.Area,
                             Status = g.Key.Status,
                             EQ_Type = g.Key.EQ_Type,
                             TesterType = g.Key.EQ_Tester,
                             TotalTime = g.Sum(p => p.TotalHours)
                         };

            DataSet.rptRCPStatusIndexDataTable table = new DataSet.rptRCPStatusIndexDataTable();

            foreach (RptSchema.rptRCPStatusIndex n in q2)
            {
                DataSet.rptRCPStatusIndexRow row = table.NewrptRCPStatusIndexRow();
                row.Area = n.Area;
                row.Status = n.Status;
                row.TotalTime = n.TotalTime;
                row.EQID = n.EqID;
                row.EQType = n.EQ_Type;
                row.TesterType = n.TesterType;
                table.AddrptRCPStatusIndexRow(row);
            }
            return table;

        }
        DataTable GenerateYieldVSRCP()
        {
              string MaskID = Request["maskid"].ToString();
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            string rcp="";
            this.lblTitle.Text = "Yield VS RCP";
           
#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/WIP-Result.xml")));
#else
          
            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID,StartTimes,StopTimes );
#endif    
          
            if (Request["rcp"] == null)
                rcp = "";
            else
                rcp = Request["rcp"].ToString().Trim();

         //  this.lblTitle.Text = data.Count().ToString();
            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if(rcp!="")
                q = from n in db.tblVerifyNote where n.TestVerify == "Test" && n.Operators == rcp && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                  q = from n in db.tblVerifyNote where n.TestVerify == "Test" &&   n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
         

            var q1 = from n in data
              
                join m in q on n.WaferID equals m.WaferID
              
                select new
                {
                  m.WaferMask , m.RCP,m.Pass,n.GoodDies,Ratio=(double)m.Pass/n.GoodDies
                }    ;

            var q2 = (from n in q1 orderby n.Ratio
                     group n by n.RCP into g
                     select new RptSchema.rptYieldVSRCPSchema()
                     {
                         RCP = g.Key,
                         Max = g.Max(k => k.Ratio),
                         Min = g.Min(k => k.Ratio),
                         Avg = g.Average(k => k.Ratio),
                         Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                         Count=g.Count()

                     })  ;
            DataSet.rptYieldVSRCPDataTable table = new DataSet.rptYieldVSRCPDataTable();
            foreach (RptSchema.rptYieldVSRCPSchema item in q2)
            {
                DataSet.rptYieldVSRCPRow row = table.NewrptYieldVSRCPRow();
                row.XLabel = item.RCP;
                row.RCP = item.RCP;
                row.Max = item.Max;
                row.Min = item.Min;
                row.Avg = item.Avg;
                row.Medium = item.Medium;
                row.Count = item.Count;
                table.AddrptYieldVSRCPRow(row);

            }
            return table; 
         }
        DataTable GenerateYeildVSOp( )
        {
             string MaskID = Request["maskid"].ToString();
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            string oper="";
            this.lblTitle.Text = "Yield VS Op";
           
#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/WIP-Result.xml")));
#else
          
            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID,StartTimes,StopTimes );
#endif    
          
            if (Request["operator"] == null)
                oper = "";
            else
                oper = Request["operator"].ToString().Trim();

         //  this.lblTitle.Text = data.Count().ToString();
            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if(oper!="")
                q = from n in db.tblVerifyNote where n.TestVerify == "Test" && n.Operators == oper && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                  q = from n in db.tblVerifyNote where n.TestVerify == "Test" &&   n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
         

            var q1 = from n in data
              
                join m in q on n.WaferID equals m.WaferID
              
                select new
                {
                  m.WaferMask , m.Operators,m.Pass,n.GoodDies,Ratio=(double)m.Pass/n.GoodDies
                }    ;

            var q2 = (from n in q1   orderby n.Ratio
                     group n by n.Operators into g
                     select new RptSchema.rptYieldVSOpSchema()
                     {
                         Operator = g.Key,
                         Max = g.Max(k => k.Ratio),
                         Min = g.Min(k => k.Ratio),
                         Avg = g.Average(k => k.Ratio),
                         Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                         Count=g.Count()

                     })  ;
            DataSet.rptYieldVSOpDataTable table = new DataSet.rptYieldVSOpDataTable();
            foreach (RptSchema.rptYieldVSOpSchema item in q2)
            {
                DataSet.rptYieldVSOpRow row = table.NewrptYieldVSOpRow();
                row.XLabel = item.Operator;
                row.Operator = item.Operator;
                row.Max = item.Max;
                row.Min = item.Min;
                row.Avg = item.Avg;
                row.Medium = item.Medium;
                row.Count = item.Count;
                  
                table.AddrptYieldVSOpRow(row);

            }
            return table; 
        }
        DataTable GenerateYeildVSPC()
        {
            string MaskID = Request["maskid"].ToString();
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            string pc = "";
            this.lblTitle.Text = "Yield VS PC";

#if DEBUG
            PMS.GoodDies_Data[] data;
            data = PMS.PMSHelper.XmlToGoodDies_Data(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/WIP-Result.xml")));
#else
          
            PMS.GoodDies_Data[] data = PMS.PMSHelper.GetTotalPassDieInfo(MaskID,StartTimes,StopTimes );
#endif

            if (Request["operator"] == null)
                pc = "";
            else
                pc = Request["operator"].ToString().Trim();

            //  this.lblTitle.Text = data.Count().ToString();
            IQueryable<tblVerifyNote> q = null; //db.tblVerifyNote.Where(n=>n.WaferID=="WS999");
            if (pc != "")
                q = from n in db.tblVerifyNote where n.TestVerify == "Test" && n.PCID.StartsWith(pc) && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators
            else
                q = from n in db.tblVerifyNote where n.TestVerify == "Test" && n.WaferID.StartsWith(MaskID) select n;  // where n.Operators


            var q1 = from n in data

                     join m in q on n.WaferID equals m.WaferID

                     select new
                     {
                         m.WaferMask,
                         m.PCID,
                         m.Pass,
                         n.GoodDies,
                         Ratio = (double)m.Pass / n.GoodDies
                     };

            var q2 = (from n in q1 orderby n.Ratio
                      group n by n.PCID into g
                      select new RptSchema.rptYieldVSPCSchema()
                      {
                          PCID = g.Key,
                          
                          Max = g.Max(k => k.Ratio),
                          Min = g.Min(k => k.Ratio),
                          Avg = g.Average(k => k.Ratio),
                          Medium = g.Skip(g.Count() / 2).Take(1).ToArray()[0].Ratio,
                          Count=g.Count()

                      });
            DataSet.rptYieldVSPCDataTable table = new DataSet.rptYieldVSPCDataTable();
            foreach (RptSchema.rptYieldVSPCSchema item in q2)
            {
                DataSet.rptYieldVSPCRow row = table.NewrptYieldVSPCRow();
                row.XLabel = item.XLabel;
                row.PCID = item.PCID;
                row.Max = item.Max;
                row.Min = item.Min;
                row.Avg = item.Avg;
                row.Medium = item.Medium;
                row.Count = item.Count;
                table.AddrptYieldVSPCRow(row);

            }
            return table;
        }
        DataTable GenerateTblCurrentWIP()
        {
 
#if DEBUG
            PMS.WIP_Data[] data;
           data=PMS.PMSHelper.XmlToWIP_Data( System.IO.File.ReadAllText(Server.MapPath("~/App_Data/WIP-Result.xml")));
#else
            PMS.WIP_Data[] data = PMS.PMSHelper.GetWIP("PT", "");
#endif


           var PC_WIPStatusCnt = from n in db.vwPC_RECWIPStatus
                   group n by n.MaskID into g
                   select new
                   {
                       MaskID=g.Key,
                       OnlineSingle = g.Count(k => k.WIP_STATUS == "OS"),
                       OnlineMulti = g.Count(k => k.WIP_STATUS == "OM"),
                       PEConfirmSingle = g.Count(k => k.WIP_STATUS == "PS"),
                       PEConfirmMulti = g.Count(k => k.WIP_STATUS == "PM"),
                       NewS = g.Count(k => k.WIP_STATUS == "NS"),
                       NewM = g.Count(k => k.WIP_STATUS == "NM")
                   };

           var q = from n in data

                   where n.Status.Trim() != ""
                   group n by n.MaskID into g   join  m in PC_WIPStatusCnt.ToList() on g.Key equals m.MaskID  into gp 

                   from k in gp.DefaultIfEmpty()

                   select new RptSchema.rptCurrentWIPSchema()
                   {
                       MaskID = g.Key,
                       Processing = g.Where(p => p.Status.Trim() == "Processing").Count(),
                       Waiting = g.Where(p => p.Status.Trim() == "Waiting").Count(),
                       Hold1 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0030" || p.Ope == "780.0150")).Count(),
                       Hold2 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0040" || p.Ope == "780.0200")).Count(),
                       Hold3 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "500.0100" || p.Ope == "780.0225" || p.Ope == "780.0250" || p.Ope == "792.0500")).Count(),
                       Other = g.Count() ,
                        OnlineSingle=k==null?0:k.OnlineSingle,
                        OnlineMulti=k==null?0:k.OnlineMulti,
                        PEConfirmSingle=k==null?0:k.PEConfirmSingle,
                        PEConfirmMulti=k==null?0:k.PEConfirmMulti,
                       NewS = k == null ? 0 : k.NewS,
                       NewM = k == null ? 0 : k.NewM
                   };
            
            
            //var q = from n in data

            //        where n.Status.Trim() != ""
            //        group n by n.MaskID into g
            //        select new RptSchema.rptCurrentWIPSchema()
            //        {
            //            MaskID = g.Key,
            //            Processing = g.Where(p => p.Status.Trim() == "Processing").Count(),
            //            Waiting = g.Where(p => p.Status.Trim() == "Waiting").Count(),
            //            Hold1 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0030" || p.Ope == "780.0150")).Count(),
            //            Hold2 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "450.0040" || p.Ope == "780.0200")).Count(),
            //            Hold3 = g.Where(p => p.Status.Trim() == "Hold" && (p.Ope == "500.0100" || p.Ope == "780.0225" || p.Ope == "780.0250" || p.Ope == "792.0500")).Count(),
            //            Other = g.Count()
            //        };
           RptSchema.rptCurrentWIPSchema[] array = q.ToArray();

            foreach (RptSchema.rptCurrentWIPSchema item in array)
            {
                item.Other = item.Other - item.Processing - item.Waiting - item.Hold1 - item.Hold2 - item.Hold3;
                tblMaskInfo minfo = db.tblMaskInfo.FirstOrDefault(n => n.MaskID == item.MaskID);
                if (minfo != null)
                {
                    item.PF = minfo.PF;
                    item.RFDC = minfo.RFDC;
                    item.Sponsor = minfo.Sponsor;
                    item.Customer = minfo.Customer;
                   
                }
                //item.Other = item.Other - item.Processing - item.Waiting - item.Hold1 - item.Hold2 - item.Hold3;

              
            }
            

            // (500.0100)
//(780.0225)(780.0250)
//(780.0280)(792.0500)

            DataSet.rptCurrentWIPDataTable table = new DataSet.rptCurrentWIPDataTable();
            foreach (RptSchema.rptCurrentWIPSchema schema in array)
            {
                DataSet.rptCurrentWIPRow row = table.NewrptCurrentWIPRow();
                row.MaskID = schema.MaskID;
                row.Processing  = schema.Processing;
                row.Waiting  = schema.Waiting;
                row.Hold1  = schema.Hold1;
                row.Hold2 = schema.Hold2;
                row.Hold3 = schema.Hold3;
                row.Other = schema.Other; //- schema.Processing - schema.Waiting - schema.Hold1 - schema.Hold2 - schema.Hold3;
                row.PF = schema.PF;
                row.RFDC = schema.RFDC;
                row.Customer = schema.Customer;
                row.Sponsor = schema.Sponsor;
                row.PEConfirmMulti = schema.PEConfirmMulti;
                row.PEConfirmSingle = schema.PEConfirmSingle;
                row.OnlineSingle=schema.OnlineSingle;
                row.OnlineMulti=schema.OnlineMulti;
                row.NewS = schema.NewS;
                row.NewM = schema.NewM;
                table.AddrptCurrentWIPRow(row);
                
                              
            }

                this.lblTitle.Text = "Current WIP";
                 this.description.InnerHtml=" Hold1(450.0030)(780.0150) <br> Hold2 (450.0040)(780.0200)<br> "+
                    "Hold3(500.0100)(780.0225)(780.0250)(780.0280)(792.0500)";
          //  table.Columns[1].ColumnName = "處理";
                
            return table;

        }
        DataTable GenerateTblAlarm()
        {
            string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            this.lblTitle.Text = "Alarm";
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            System.Data.SqlClient.SqlDataAdapter adp = new SqlDataAdapter("select * from tblAlarm where start_time>='" + StartTimes.ToString("yyy-MM-dd") + "' and end_time<='" + StopTimes.ToString("yyy-MM-dd") + "'",
              new System.Data.SqlClient.SqlConnection(GetConnectionString()));
            DataTable table = new DataTable();
            adp.Fill(table);
            return table;
        }
        DataTable GenerateTblEQHistory()
        {
            string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            this.lblTitle.Text = "EQ History";
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            System.Data.SqlClient.SqlDataAdapter adp = new SqlDataAdapter("select * from tblEqHistory where start_time>='" + StartTimes.ToString("yyy-MM-dd") + "' and stop_time<='" + StopTimes.ToString("yyy-MM-dd") + "'",
              new System.Data.SqlClient.SqlConnection(GetConnectionString()));
            DataTable table = new DataTable();
            adp.Fill(table);
            return table;
        }
        DataTable GenerateTblVerifyNote()
        {
             string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            this.lblTitle.Text = "VerifyNote";
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            System.Data.SqlClient.SqlDataAdapter adp = new SqlDataAdapter("select * from tblVerifyNote where starttimes>='" + StartTimes.ToString("yyy-MM-dd") + "' and stoptimes<='" + StopTimes.ToString("yyy-MM-dd") + "'",
              new System.Data.SqlClient.SqlConnection(GetConnectionString()));
         DataTable table=new DataTable();
         adp.Fill(table);
         return table;
            
        }
        DataTable GenerateTblEQ()
        {
            string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            this.lblTitle.Text = "tblEQ";
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            System.Data.SqlClient.SqlDataAdapter adp = new SqlDataAdapter("select * from tblEQ where start_time>='" + StartTimes.ToString("yyy-MM-dd") + "' and start_time<='" + StopTimes.ToString("yyy-MM-dd") + "'",
              new System.Data.SqlClient.SqlConnection(GetConnectionString()));
            DataTable table = new DataTable();
            adp.Fill(table);
            return table;

        }

      public  string GetConnectionString()
        {


          // return @"Data Source=4820tg-PC\SQLEXPRESS;Initial Catalog=Amida;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AmidaConnectionString"].ConnectionString;

            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/slAmidaConsole.Web");
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["AmidaConnectionString"];
                if (connString != null)
                    return connString.ConnectionString;
                else
                {
                   int cnt= rootWebConfig.ConnectionStrings.ConnectionStrings.Count;
                   string ret = "";
                   for (int i = 0; i < cnt; i++)
                       ret += rootWebConfig.ConnectionStrings.ConnectionStrings[i].ConnectionString;

                    throw new Exception("connString:"+ret);
                }
            }
            return "";



        }

        public string CreateCSVString (DataTable dt ) // strFilePath 為輸出檔案路徑 (含檔名)
        {
          //  StreamWriter sw = new StreamWriter(strFilePath, false);
                    StringBuilder sb=new StringBuilder();
            int intColCount = dt.Columns.Count;

            if (dt.Columns.Count > 0)
               sb.Append(dt.Columns[0]);
            for (int i = 1; i < dt.Columns.Count; i++) 
               sb.Append("," + dt.Columns[i]);

           sb.Append("\r\n");
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Columns.Count > 0 && !Convert.IsDBNull(dr[0]))
                
                    sb.Append(Encode(Convert.ToString(dr[0])));
               
                for (int i = 1; i < intColCount; i++)
                {
                    if (dr[i] is DateTime)
                        sb.Append( ","+ ((DateTime)dr[i]).ToString("yyyy/MM/dd HH:mm:ss"));
                    else
                        sb.Append("," + dr[i]);

                }
                 sb.Append("\r\n");
            }
            return sb.ToString();
  //  sw.Close();
        }

public string Encode(string strEnc)
{
    return System.Web.HttpUtility.UrlEncode(strEnc);
}
        public void DownLoadDatableToCsv(string csv)
        { string attachment = "attachment; filename=download.csv";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            Response.Charset = "big5";
          
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5");

            
                HttpContext.Current.Response.Write(csv);
                HttpContext.Current.Response.End();
        }



        DataTable GenerateRptRCPProductivity()
        {
            DataSet ds = new DataSet();
            string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            this.lblTitle.Text = "RCP Productivity";
            if (whereStr.Trim() == "")
            {
                var q = from n in this.db.tblVerifyNote
                        group n by new {n.RCP,n.TestVerify} into g
                        select new RptSchema.rptRCPProductivitySchema
                        {
                             RCP = g.Key.RCP,
                             Number=g.Count(),
                             TestVerify=g.Key.TestVerify
                        };
                foreach (RptSchema.rptRCPProductivitySchema r in q)
                {
                    ds.rptRCPProductivity.AddrptRCPProductivityRow(r.XLabel, r.RCP, r.TestVerify, (long)r.Number);
                }

                return ds.rptRCPProductivity;
                //   return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
            else
            {
                var q = from n in this.db.tblVerifyNote.Where(whereStr, new System.Data.Objects.ObjectParameter("p0", StartTimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                        group n by new { n.RCP, n.TestVerify } into g
                        select new RptSchema.rptRCPProductivitySchema
                        {
                            RCP = g.Key.RCP,
                            Number = g.Count(),
                            TestVerify = g.Key.TestVerify
                        };
                foreach (RptSchema.rptRCPProductivitySchema r in q)
                {
                    ds.rptRCPProductivity.AddrptRCPProductivityRow(r.XLabel, r.RCP,r.TestVerify, (long)r.Number);
                }

                return ds.rptRCPProductivity;
                //  return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
        }
        DataTable GenerateRtpTouchDo()
        {
            DataSet ds = new DataSet();
            string whereStr = Request["wherestr"].ToString() ;
            DateTime StartTimes, StopTimes;
            StartTimes=Convert.ToDateTime(Request["starttimes"]);
            StopTimes=Convert.ToDateTime(Request["stoptimes"]);
            this.lblTitle.Text = "RptTouchDo";
            if (whereStr.Trim() == "")
            {
                var q =from p in
                           (from n in this.db.tblVerifyNote  join m in db.PC_tbl on  n.PCID equals m.PC_ID 
                           into gs
                        from k in gs.DefaultIfEmpty()  select new {n.PCID,n.Pass,n.Fail,n.TouchDo,k.PC_status }     )
                        group p by new {p.PCID,p.PC_status} into g
                        select new RptSchema.RptTouchDownSchema
                        {
                             PCID = g.Key.PCID,
                             Touch_Down_Total  = (long)g.Sum(p => p.TouchDo),
                            Pass_Total = (long)g.Sum(p => p.Pass),
                            Fail_Total = (long)g.Sum(p => p.Fail),
                             PC_Status= g.Key.PC_status??""
                             
                        };
                foreach (RptSchema.RptTouchDownSchema r in q)
                {
                    ds.rptTouchDo.AddrptTouchDoRow(r.XLabel, r.PCID,(long) r.Touch_Down_Total,(long) r.Pass_Total, (long)r.Fail_Total,r.PC_Status);
                }

                return ds.rptTouchDo;
             //   return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
            else
            {
                var q = from p in
                            (from n in this.db.tblVerifyNote.Where(whereStr, new System.Data.Objects.ObjectParameter("p0", StartTimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                             join m in db.PC_tbl on n.PCID equals m.PC_ID 
                        
                           into gs
                        from k in gs.DefaultIfEmpty()  select new {n.PCID,n.Pass,n.Fail,n.TouchDo,k.PC_status }     )
                        group p by new {p.PCID,p.PC_status} into g
                        select new RptSchema.RptTouchDownSchema
                        {
                             PCID = g.Key.PCID,
                             Touch_Down_Total  = (long)g.Sum(p => p.TouchDo),
                            Pass_Total = (long)g.Sum(p => p.Pass),
                            Fail_Total = (long)g.Sum(p => p.Fail),
                             PC_Status= g.Key.PC_status??""
                             
                        };
                foreach (RptSchema.RptTouchDownSchema r in q)
                {
                    ds.rptTouchDo.AddrptTouchDoRow(r.XLabel, r.PCID, (long)r.Touch_Down_Total, (long)r.Pass_Total, (long)r.Fail_Total,r.PC_Status);
                }

                return ds.rptTouchDo;
              //  return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
          
        }

        DataTable GenerateRtpPerformanceIndex()
        {
            DataSet ds = new DataSet();
            string whereStr = Request["wherestr"].ToString();
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
            this.lblTitle.Text = "RptPerformanceIndex";
            if (whereStr.Trim() == "")
            {
                var q = from n in this.db.tblEQHistory
                        group n by n.@operator into g
                        select new RptSchema.rptPerformanceSchema
                        {
                            Operator ="'"+ g.Key,
                            ProductTotal   =  g.Count(p => p.status=="Product"),
                            VerifyTotal  =  g.Count(p => p.status=="Verify"),
                            Total =  g.Count(p => p.status == "Product" || p.status == "Verify")
                        };
                foreach (RptSchema.rptPerformanceSchema r in q)
                {
                    ds.rptPerformanceIndex.AddrptPerformanceIndexRow(r.XLabel, r.Operator, (long)r.ProductTotal, (long)r.VerifyTotal,(long) r.Total);
                }

                return ds.rptPerformanceIndex;
                //   return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
            else
            {
                var q = from n in this.db.tblEQHistory.Where(whereStr, new System.Data.Objects.ObjectParameter("p0", StartTimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                        group n by n.@operator into g
                        select new RptSchema.rptPerformanceSchema
                        {
                            Operator = "'"+g.Key,
                            ProductTotal = g.Count(p => p.status == "Product"),
                            VerifyTotal = g.Count(p => p.status == "Verify"),
                            Total = g.Count(p => p.status == "Product" || p.status == "Verify")
                        };
                foreach (RptSchema.rptPerformanceSchema r in q)
                {
                    ds.rptPerformanceIndex.AddrptPerformanceIndexRow(r.XLabel, r.Operator, (long)r.ProductTotal, (long)r.VerifyTotal, (long)r.Total);
                }

                return ds.rptPerformanceIndex;
                //  return q.ToArray<RptSchema.RptTouchDownSchema>();
            }

        }

        //private System.Data.DataSet dataSet;
        //private void Export_CVS_Funtion(string sensorID,string selectDate)
        //{

        //    SqlConnection conn = new SqlConnection("server=192.192.161.2;database=SSHMC01;uid=david;pwd=ufjl0683@");
            
        //    conn.Open();
            
        //    SqlCommand s_com = new SqlCommand();


        //    if (Istilt == "1")
        //        Zaxis = "溫度";
        //    else
        //        Zaxis = "Z軸";
            

        //    //DateTime DT = Convert.ToDateTime(selectDate);
        //    //selectDate = string.Format("{0:G}", DT);//2005-11-5 14:23:23
        //    if (selectDate != " ")//other days
        //    {
        //        DateTime ConverterTime = Convert.ToDateTime(selectDate);

        //        //2012/10/01 10:30:00
        //        //2012/10/01 下午 10:30:00
        //        selectday = ConverterTime.ToString("yyyy") + "/" + ConverterTime.ToString("MM") + "/" + ConverterTime.ToString("dd") + " " + ConverterTime.ToString("HH:mm:ss");
        //        selectYestaday = ConverterTime.ToString("yyyy") + "/" + ConverterTime.ToString("MM") + "/" + (Convert.ToInt32(ConverterTime.ToString("dd")) + 1).ToString() + " " + ConverterTime.ToString("HH:mm:ss");

        //        s_com.CommandText = "SELECT    TIMESTAMP As '時間', VALUE0 As 'X軸', VALUE1 As 'Y軸', VALUE2 As " + Zaxis + "  FROM          tblTC10MinDataLog WHERE      (TIMESTAMP >= '" + selectday + "') AND   (TIMESTAMP < '" + selectYestaday + "') AND (SENSOR_ID = '" + sensorID + "') AND (ISVALID = 'Y') ORDER BY TIMESTAMP";
        //    }
        //    else//today
        //    {
        //        s_com.CommandText = "SELECT    TIMESTAMP As '時間', VALUE0 As 'X軸', VALUE1 As 'Y軸', VALUE2 As " + Zaxis + "  FROM          tblTC10MinDataLog WHERE      (TIMESTAMP >= CONVERT(char(11),GETDATE() , 120)) AND (SENSOR_ID = '" + sensorID + "' ) AND (ISVALID = 'Y') ORDER BY TIMESTAMP";
        //        DateTime ConverterTime = Convert.ToDateTime(DateTime.Today);
        //        selectday = ConverterTime.ToString("yyyy") + "/" + ConverterTime.ToString("MM") + "/" + ConverterTime.ToString("dd") + " " + ConverterTime.ToString("HH:mm:ss");
                
        //    }
        //    s_com.Connection = conn;    //select convert(char(19),GETDATE()+2,120)


            




            
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(s_com);
        //    sda.Fill(dt);
            

        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //    DateTime parsed;

        //    if (DateTime.TryParseExact(selectday, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsed))
        //    {
        //        filename = parsed.ToString("yyyyMMdd") + "-SensorID_" + Request["id"].ToString();
        //    }
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);

        //    //關閉換頁跟排序
        //    GridView1.AllowSorting = false;
        //    GridView1.AllowPaging = false;

        //    //'移去不要的欄位
        //    //GridView1.Columns.RemoveAt(GridView1.Columns.Count - 1);
        //    //GridView1.DataBind();

        //    //    建立假HtmlForm避免以下錯誤()
        //    //    Control() 'GridView1' of type 'GridView' must be placed inside 
        //    //a form tag with runat=server. 
        //    //    另一種做法是override(VerifyRenderingInServerForm後不做任何事)
        //    //這樣就可以直接GridView1.RenderControl(htw);

        //    ////System.Web.UI.HtmlControls.HtmlForm hf = new System.Web.UI.HtmlControls.HtmlForm();
        //    ////Controls.Add(hf);
        //    ////hf.Controls.Add(GridView1);
        //    ////hf.RenderControl(htw);
        //    Response.Clear();
        //    //GridView1.RenderControl(htw);
        //    //Response.Write(sw.ToString());




            

        //    conn.Close();



        //}

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }






















        //private void WriteXls()
        //{
        //    Console.WriteLine("WriteXls");
        //    //啟動Excel應用程式
        //    xlApp = new Microsoft.Office.Interop.Excel.Application();

        //    if (xlApp == null)
        //    {
        //        Console.WriteLine("Error! xlApp");
        //        return;
        //    }
        //    //用Excel應用程式建立一個Excel物件，也就是Workbook。並取得Workbook中的第一個sheet。這就是我們要操作資料的地方。
        //    wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        //    ws = (Worksheet)wb.Worksheets[1];
        //    if (ws == null)
        //    {
        //        Console.WriteLine("Error! ws");
        //    }
        //    //要在Excel儲存資料，有三種方式，以下分別介紹。利用Range物件，設定要儲存資料的儲存格範圍。
        //    // Select the Excel cells, in the range c1 to c7 in the worksheet.
        //    Range aRange = ws.get_Range("C1", "C11");
        //    if (aRange == null)
        //    {
        //        Console.WriteLine("Could not get a range. Check to be sure you have the correct versions of the office DLLs.");
        //    }
        //    // Fill the cells in the C1 to C7 range of the worksheet with the number 6.  
        //    Object[] args = new Object[1];
        //    args[0] = 7;
        //    aRange.Value2 = args;
        //    //衍生自上面方法，但是在儲存資料的時候，可以用InvokeMember呼叫aRange的資料成員(成員函式?)。
        //    //aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
        //    //利用Cells屬性，取得單一儲存格，並進行操作。
        //    string[] number = { "A", "B", "C", "D", "E", "F", "G", "H" };
        //    foreach (string s in number)
        //    {
        //        Range aRange2 = (Range)ws.Cells["1", s];
        //        Object[] args2 = new Object[1];
        //        args2[0] = s;
        //        aRange2.Value2 = args2;
        //    }

        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
        //    saveFileDialog1.Title = "Save an Image File";
        //    saveFileDialog1.ShowDialog();







        //    //最後，呼叫SaveAs function儲存這個Excel物件到硬碟。
        //    wb.SaveAs(@"C:\test2.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, mObj_opt, mObj_opt, mObj_opt, mObj_opt, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, mObj_opt, mObj_opt, mObj_opt, mObj_opt, mObj_opt);

        //    Console.WriteLine("save");
        //    wb.Close(false, mObj_opt, mObj_opt);
        //    xlApp.Workbooks.Close();
        //    xlApp.Quit();
        //    //刪除 Windows工作管理員中的Excel.exe 進程，  
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(aRange);

        //    xlApp = null;
        //    wb = null;
        //    ws = null;
        //    aRange = null;

        //    //呼叫垃圾回收  
        //    GC.Collect();
        //}
     


    }
}