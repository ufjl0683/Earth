using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace slAmidaConsole.Web
{
    public partial class ProbecardWorkSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //System.Configuration.Configuration rootWebConfig =
            //    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/slAmidaConsole.Web");
          
        //    Label1.Text=   System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AmidaConnectionString"].ConnectionString;

            if (Request["PCID"] == null || Request["PCID"]=="" )
            {
                //Response.Write("ProbecardWorkSheet?PCID=ProcardID to query");
                //Response.End();
                //Response.End();
                this.dvTable.InnerText = "";
                return;
            }
            string PCID=Request["PCID"].ToString().Trim();
            this.Label1.Text = ConvertPCID(PCID);
            slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();

            var q = (from n in db.tblEQHistory
                     where n.probe_card_id == PCID && (n.status=="Verify" || n.status=="Product")
                     select new ProcardWorkLog()
                     {
                         Lot_ID = n.lot_id,
                         Num_Tested_Wafer = n.tested_num_wafer,
                          Wafer_ID=n.wafer_id_out,
                         OD = n.over_drive_out,
                         Operator = n.@operator,
                         RCP = n.eq_id,
                         TimeStamp = n.start_time,
                         TPS="",
                         NeedleBody =null,
                         NeedleLength=null,
                          NeedleStatus="",
                          status=n.status,
                           Comment="" ,
                         recipe=n.recipe


                     }).Union(

                      from n1 in db.PC_Rec_tbl
                      where n1.PC_ID == PCID
                      select new ProcardWorkLog()
                      {
                          Lot_ID = "",
                          Num_Tested_Wafer = 0,
                          Wafer_ID = "",
                          OD =null,
                          Operator =n1.Modifier,
                          RCP = "",
                          TimeStamp = n1.PC_rec_time,
                          TPS="",
                          NeedleBody=n1.Current_length_of_needle_body,
                          NeedleLength = n1.Currentmax_tip_size,
                          NeedleStatus= n1.PC_status,
                             status="",
                          Comment=n1.PC_comment,
                          recipe=""
                       
                         
                             
                             
                      }).OrderBy(k=>k.TimeStamp);

            string html="<table id=\"tblProbecardWorkSheet\"><thead><tr>";

            html += " <th>TimeStamp</th><th>Lot_ID</th><th>Wafer_ID</th><th>T/V</th><th>#</th><th>RCP</th><th>recipe</th><th>OD</th><th>Operator</th><th>針身</th><th>針點</th><th>卡況</th><th >備註</th>";


            html += "</th></thead>";
             
          //  Response.Write("<table id=\"tblProbecardWorkSheet\"</table>");
         //   Response.Flush();
            html += "<tbody>";
            int tested_wafer_acc_num = 0;
            foreach (ProcardWorkLog log in q)
            {   
                
                if(log.T_V=="T")
                     tested_wafer_acc_num += (int)(log.Num_Tested_Wafer==null?0:log.Num_Tested_Wafer);

            if (log.NeedleStatus != null && log.NeedleStatus.StartsWith("PE"))
                html += "<tr style=\"color:red\">";
                else
                html += "<tr>";

                html +="<td>"+ ((log.TimeStamp == null) ? "" : ((DateTime)log.TimeStamp).ToString("yyyy-MM-dd HH:mm:ss"))+"</td>";
                html+="<td>"+(log.Lot_ID==null?"":log.Lot_ID.ToString())+"</td>" ;
                html+="<td>"+( log.Wafer_ID == null ? "" : log.Wafer_ID.ToString() )+"</td>";
               // html += "<td>" + (log.status == null ? "" : log.status.ToString()) + "</td>";
                html += "<td>" + log.T_V + "</td>";
                html += "<td>" + tested_wafer_acc_num + "</td>";     //    (log.Num_Tested_Wafer == null ? "" : log.Num_Tested_Wafer.ToString()) + "</td>";
                html+= "<td>"+(log.RCP == null ? "" : log.RCP.ToString()  )+"</td>";
                html += "<td>" + (log.recipe == null ? "" : log.recipe.ToString()) + "</td>";
                html+= "<td>"+( log.OD == null ? "" : log.OD.ToString()  )+"</td>";
                html+= "<td>"+( log.Operator == null ? "" : log.Operator.ToString() )+"</td>";
                html += "<td>" + (log.NeedleBody == null ? "" : string.Format("{0:0.00}", log.NeedleBody)) + "</td>";
                html+= "<td>"+( log.NeedleLength == null ? "" : string.Format("{0:0.00}",log.NeedleLength ))+"</td>";
               
                html += "<td>" + (log.NeedleStatus == null ? "" : log.NeedleStatus.ToString()) + "</td>";
               
                html += "<td>" + (log.Comment == null ? "" : log.Comment.ToString()) + "</td>";
                html += "</tr>";
                // ,
                   //   new TableCell(){Text=},
                   //   new TableCell(){Text=},
                   //   new TableCell(){Text=},
                       
                   //   new TableCell(){Text=},
                   //    new TableCell(){Text=},
                   //         new TableCell(){Text=}
                      
                     
                   //});   
              //  this.tblProcardWorkSheet.Rows.Add(row);
            }

            html += "</tbody>";

            html += "</table>";
            this.dvTable.InnerHtml = html;
           
        }

        string ConvertPCID(string PCID)
        {
            try
            {
                string res = PCID.Substring(0, 5);
                string c6="";
                switch (PCID.Substring(17, 2))
                {
                    case "01":
                        c6 = " ";
                        break;
                    case "31":
                        c6 = "C";
                        break;
                    case "41":
                        c6 = "D";
                        break;
                    case "51":
                        c6 = "E";
                        break;
                    case "61":
                        c6 = "F";
                        break;
                    case "71":
                        c6 = "G";
                        break;
                    case "81":
                        c6 = "H";
                        break;
                }
                 res+=c6+"-";
                 string ch8 = "";
                 int tmp;
                 if (int.TryParse(PCID.Substring(15, 2), out tmp))
                     ch8 = " ";
                 else
                     ch8 = "V";// PCID.Substring(15, 1);
                 res += ch8;
                 string ch9 = "";
                 if (PCID.Substring(9, 1) != "S")
                     ch9 = PCID.Substring(9, 1);
                 else if (PCID.Substring(13, 1) == "M")
                     ch9 = "T";
                 else
                     ch9 = "S";
                 res += ch9;
                 res += PCID.Substring(6, 3);
                //  return PCID.Substring(0, 5) + "PC" + PCID.Substring(7, 2) + "-" + PCID.Substring(9, 1);
                return res;  //PCID.Substring(0,5)+ PCID.Substring(9, 1) + PCID.Substring(6, 3) + "-" + PCID.Substring(13, 1) + PCID.Substring(17, 2);

            }
            catch
            {
                return PCID;
            }
        }
       
    }
}