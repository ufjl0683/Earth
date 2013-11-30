using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace slAmidaConsole.Web
{
     
    public partial class TouchDownTest : System.Web.UI.Page
    {
        slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.GridView1.DataSource = GenerateRtpTouchDo();
            this.GridView1.DataBind();
        }
        DataTable GenerateRtpTouchDo()
        {
            DataSet ds = new DataSet();
            string whereStr = "it.PCID like 'AH317%' ";
            DateTime StartTimes, StopTimes;
            StartTimes = Convert.ToDateTime(Request["starttimes"]);
            StopTimes = Convert.ToDateTime(Request["stoptimes"]);
         //   this.lblTitle.Text = "RptTouchDo";
            if (whereStr.Trim() == "")
            {
                var q = from n in this.db.tblVerifyNote
                        group n by n.PCID into g
                        select new RptSchema.RptTouchDownSchema
                        {
                            PCID = g.Key,
                            Touch_Down_Total = (long)g.Sum(p => p.TouchDo),
                            Pass_Total = (long)g.Sum(p => p.Pass),
                            Fail_Total = (long)g.Sum(p => p.Fail)
                        };
                foreach (RptSchema.RptTouchDownSchema r in q)
                {
                    ds.rptTouchDo.AddrptTouchDoRow(r.XLabel, r.PCID, (long)r.Touch_Down_Total, (long)r.Pass_Total, (long)r.Fail_Total,r.PC_Status);
                }

                return ds.rptTouchDo;
                //   return q.ToArray<RptSchema.RptTouchDownSchema>();
            }
            else
            {
                var q = from n in this.db.tblVerifyNote.Where(whereStr, new System.Data.Objects.ObjectParameter("p0", StartTimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                        group n by n.PCID into g
                        select new RptSchema.RptTouchDownSchema
                        {
                            PCID = g.Key,
                            Touch_Down_Total = (long)g.Sum(p => p.TouchDo),
                            Pass_Total = (long)g.Sum(p => p.Pass),
                            Fail_Total = (long)g.Sum(p => p.Fail)
                        };
                foreach (RptSchema.RptTouchDownSchema r in q)
                {
                    ds.rptTouchDo.AddrptTouchDoRow(r.XLabel, r.PCID, (long)r.Touch_Down_Total, (long)r.Pass_Total, (long)r.Fail_Total ,r.PC_Status);
                }

                return ds.rptTouchDo;
                //  return q.ToArray<RptSchema.RptTouchDownSchema>();
            }

        }
    }
}