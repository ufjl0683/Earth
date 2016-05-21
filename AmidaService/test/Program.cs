using System;
using System.Collections.Generic;
using System.Text;
//using //RemoteInterface;
using System.ServiceModel;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Linq; using System.Diagnostics;

using System.ComponentModel;
 
using System.Data;
using System.Linq;
 
namespace test
{

    //public class CheckFlag
    //{
    //    public int DC { get; set; }
    //    public int SCB { get; set; }
    //    public int Pick { get; set; }
    //    public int Sampling { get; set; }
    //    public int Sapphire { get; set; }
    //    public int CheckSRF { get; set; }
    //}

    public class CheckFlag
    {
        public int Comp { get; set; }
        public int Start { get; set; }
        public int Receipe { get; set; }

    }

    


 


    class Program
    {
        public    static string IPT_String="<?xml version=\"1.0\"?>\n"+ 
        "<REQ>\n" +
        "<CLIINFO>yuchilin.winfoundry.com;fe80::508:e0ff:787c:c2c2%10</CLIINFO>\n"+ 
        "<USERID>Loader</USERID>\n"+ 
        "<PERMISSION>R</PERMISSION>\n"+ 
        "<SRVPROCESSS>MCN_NUM</SRVPROCESSS>\n"+ 
        "<VERSION>1.0.0.0</VERSION>\n"+ 
        "<TASK>Qry_MCNNUM</TASK>\n"+
        "<ELE NAME=\"\">\n"+ 
                "<ATTR NAME=\"LotID\">@LotID</ATTR>\n"+ 
                "<ATTR NAME=\"WaferID\">@WaferID</ATTR>\n"+ 
       " </ELE>\n"+ 
       "</REQ>\n";


        static void Main(string[] args)
        {

            string MDBname = "BH638-002_2";
            string[] fileNameParts = MDBname.Replace("_", "-").Split(new char[] { '-' });
 
                  String LotID= fileNameParts[0].Substring(0, 5)+(char.IsLetter(fileNameParts[1][0])? fileNameParts[1]:"-"+fileNameParts[1]);
                  string WaferID = string.Format("{0:00}", int.Parse(fileNameParts[2]));
            ITP_Service.Service1SoapClient client = new ITP_Service.Service1SoapClient();
           // string querystr = IPT_String.Replace("@LotID", "VH638-003").Replace("@WaferID", "01");
          //  string querystr = IPT_String.Replace("@LotID", "CP233P002").Replace("@WaferID", "02");
            string querystr = IPT_String.Replace("@LotID", LotID).Replace("@WaferID", WaferID);
             string  res= client.ITP_WebService(querystr);
             System.Xml.XmlDocument doc = new XmlDocument();
             doc.LoadXml(res);
            
             Console.WriteLine(res);
             if (doc.GetElementsByTagName("ROW").Count > 0)
                 Console.WriteLine("MCNNUM:" + doc.GetElementsByTagName("ROW")[0].InnerText);
             else
             {
                 foreach (XmlElement e in doc.GetElementsByTagName("ATTR"))
                     Console.WriteLine(e.Attributes["NAME"].Value+":"+e.InnerText);
             }

             Console.ReadKey();
     //       string res = "[0000000I: skwerewr @recpipename][eee]";
     //       if (!res.StartsWith("[0000000I:"))
     //           return;

     //       else
     //       {

     //           int startpos, endpos;
     //           startpos = res.IndexOf('@');
     //           endpos = res.IndexOf(']');
     //           if (startpos == -1 || endpos == -1)
     //               return;
     //           string ReceipeID = res.Substring(startpos + 1, endpos - startpos - 1);  // res.Split(new char[] { '@' })[1].Trim(new char[] { ']' });
     //           //處理 Receipe ID here
     //           Console.WriteLine( "Success:" + ReceipeID);

     //       }
     //       Console.ReadKey();
     //       string EQPID = "RCP-031";
     //       System.IO.Directory.CreateDirectory("c:\\test\\PCM123\\import");

     //       if (EQPID.StartsWith("RCP"))
     //       {
     //           try
     //           {
     //               EQPID = "RCP-" + int.Parse(EQPID.Split(new char[] { '-' })[1]);
     //           }
     //           catch (Exception ex)
     //           {
     //               Console.WriteLine(ex.Message + "," + ex.StackTrace);

     //           }

     //          Console.WriteLine( "Fail:RCP name illegal!");
     //       }

     //    //   Console.WriteLine(DateTime.Now.ToLongDateString());
     //       //string s = "012-34567890123";
     //       //Console.WriteLine(s.IndexOf('-', s.IndexOf('-') + 1));

     //       WIP_Data[] data = GetWIP("PT", "");
     //       WIP_Data[] data1 = (from x in data where x.MaskID == "BP602" select x).ToArray();
     //       //Console.WriteLine(data1.Length);
     //   //   string xml=  GetCancelXmlRequest("memo", "partid", "productid", "routeid", "openo");
     //   //Console.WriteLine(xml);
     //      // SetTrackIn("AP428P326-06", "Multi-AP428-200","LAD-1");
     ////       SetCompleted("AH770P102-05");
     //  //   string res=  AutoMes("IN","aa","AS370-1.000","trk-07", "190.0300");
     // //    Console.WriteLine(res);
       //     GetPerformanceTotalBySql("it.Start_Time >= @p0 and it.Start_Time <@p1 and it.stop_time >=@p0 and it.stop_time <@p1", new DateTime(2015, 7, 1), new DateTime(2015, 7, 2)); 
                  
            Console.ReadKey();
        }


         


        public static  void GetPerformanceTotalBySql(string sql, DateTime Startimes, DateTime StopTimes)
        {
            // this.ObjectContext.tblVerifyNote.
            // slAmidaConsole.Web.AmidaEntities db = new AmidaEntities();
            //  var a =  this.ObjectContext.tblVerifyNote.Where("StartTimes< @p0",new System.Data.Objects.ObjectParameter("p0",new DateTime(2013,4,16)));

            //   a.ToArray();
            test.AmidaEntities ObjectContext = new AmidaEntities();
            try
            {
                Console.WriteLine("begin!!"+DateTime.Now.ToString());
               //     ObjectContext.tblEQHistory.Where(

                //var q = from n in ObjectContext.tblEQHistory.Where(sql, new System.Data.Objects.ObjectParameter("p0", Startimes), new System.Data.Objects.ObjectParameter("p1", StopTimes))
                var q = from n in ObjectContext.tblEQHistory
                        where n.start_time > new DateTime(2015, 7, 1) && n.stop_time < new DateTime(2015, 7, 2)
                        group n by n.@operator into g

                        select new
                        {
                            Operator = g.Key,
                            ProductTotal = g.Count(p => p.status == "Product"),
                            VerifyTotal = g.Count(p => p.status == "Verify"),
                            Total = g.Count(p => p.status == "Product" || p.status == "Verify")
                        };
                      //  select n;

                Console.WriteLine("foreach!!" + DateTime.Now.ToString());
                    foreach (var d in q)
                    {
                        Console.WriteLine(d.Operator+","+ d.ProductTotal);
                    }

                    Console.WriteLine("end!!" + DateTime.Now.ToString());
                }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static  string AutoMes(string INOUT, string userid, string partid, string eqpid, string openo)
        {
            string feedfilename = Guid.NewGuid().ToString() + ".txt";
            try
            {
                System.Diagnostics.Process process;
              
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename));
                sw.Write(userid + " " + partid + " " + eqpid + " " + openo);
                sw.Close();
                process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\AutoMES.exe", INOUT + " " + AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename);

                if (!process.WaitForExit(3000))
                    return "Fail:Timeout";

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out"))
                    return "Fail:output file not found!";
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                string res = sr.ReadLine();
                sr.Close();
                if (!res.StartsWith("[0000000I:"))
                    return "Fail:" + res;

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message;
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename);
                }
                catch { ;}


                try
                {

                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                }
                catch { ;}
            }


        }


        public static string AutoMesPMS(string INOUT, string userid, string partid, string eqpid/*, string openo*/)
        {
            string feedfilename = Guid.NewGuid().ToString() + ".txt";
            try
            {
                System.Diagnostics.Process process;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename));
                sw.Write(userid + " " + partid + " " + eqpid + " " /*+ openo*/);
                sw.Close();
                process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\AutoMESPMS.exe", INOUT + " " + AppDomain.CurrentDomain.BaseDirectory + "AutoMes\\" + feedfilename);

                if (!process.WaitForExit(3000))
                    return "Fail:Timeout";

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out"))
                    return "Fail:output file not found!";
                System.IO.StreamReader sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                string res = sr.ReadLine();
                sr.Close();
                if (!res.StartsWith("[0000000I:"))
                    return "Fail:" + res;
                else
                {
                    // must fill here

                    if (INOUT == "IN")
                        ;
                    // string Recipe=res.Split(new ch[]{})
                   return "Success";
                }
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message;
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename);
                }
                catch { ;}


                try
                {

                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"AutoMes\" + feedfilename + ".out");
                }
                catch { ;}
            }


        }

        //static  void File_Test()
        //  {
        //      string[] files = System.IO.Directory.GetFiles("c:\\export");


        //      System.Collections.Generic.List<string> list = new List<string>();
        //      foreach (string filename in files)
        //          list.Add(filename);

        //      list.Sort(new FileComparer());

        //      files = list.ToArray();

        //      foreach(string file in files)
        //      Console.WriteLine(file);
        //  }




        public static void SetTrackIn(string PartID, string recipe,string equid)
        {
            string res, req;
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            req = GetPartInfoXMLRequest("001", PartID);
            res = client.PMS_MainService(req);
            //  res = File.ReadAllText("0_PT000V_PartInfo_result.xml");
            CheckError(res);
            string productid, routeid, status, openo, eqpid,pdid,fen,pen,custid;

            ParsePartInfoResult(res, out status, out productid, out routeid, out  openo, out eqpid,out pdid,out fen,out pen,out custid);

            if (status != "Waiting")
                throw new Exception("TrackIn:Status not Waiting");
            req = SetPartTrackInXMLRequest(PartID, productid, routeid, openo, equid, recipe, "03424", "2");

            res = client.PMS_MainService(req);
            CheckError(res);
            //res = SetPartTrackInXMLRequest(PartID, productid, routeid, openo, eqpid, "2", "xxx", "xxx");

        }
        public static CheckFlag GetCheckFlag(string PartID )
        {
            string res, req;
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            req = GetPartInfoXMLRequest("001", PartID);
            res = client.PMS_MainService(req);
            CheckError(res);
            string productid, routeid, status, openo, eqpid,pdid,fen,pen,custid;

            ParsePartInfoResult(res, out status, out productid, out routeid, out  openo, out eqpid,out pdid,out fen,out pen,out custid);
            
            req = GetCheckFlagXMLRequest(routeid, openo );
            
            res = client.PMS_MainService(req);
            CheckError(res);

            CheckFlag checkflag = XmlToCheckFlag(res);
            return checkflag;
        }

        public static CheckFlag XmlToCheckFlag(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            var q = from n in doc.Descendants("COL") select n;
            XElement[] cols = q.ToArray<XElement>();
            return new CheckFlag()
            {
                Comp = int.Parse(cols[0].Value),
                Start = int.Parse(cols[1].Value),
                Receipe = int.Parse(cols[2].Value)
                //DC = int.Parse(cols[0].Value),
                //SCB = int.Parse(cols[1].Value),

                //Pick = int.Parse(cols[2].Value),
                //Sampling = int.Parse(cols[3].Value),
                //Sapphire = int.Parse(cols[4].Value),
                //CheckSRF = int.Parse(cols[5].Value)
            };
                  
                        
                      
                      
        }

        public void SetCancel(string PartID,string memo)
        {
            string res, req;
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            req = GetPartInfoXMLRequest("001", PartID);
            res = client.PMS_MainService(req);
            CheckError(res);
            string productid, routeid, status, openo, eqpid,pdid,fen,pen,custid;
            ParsePartInfoResult(res, out status, out productid, out routeid, out  openo, out eqpid,out pdid,out fen,out pen,out custid);
            req = GetCancelXmlRequest(memo,PartID,productid,routeid,openo);
            res=  client.PMS_MainService(req);
            CheckError(res);

        }

        public static string GetDC2XmlRequest(string partid,string productid,string routeid,string openo,string userid,string password,string pdid,string fen,string pen,string custid)
        {
             
            XDocument doc = new XDocument(
         new XElement("REQ",

             new XElement("CLIINFO", "TMS"),
             new XElement("FUNCTION", "PT000V_PartInfo"),
             new XElement("VERSION", "2.4.0.2"),
             new XElement("ELE", new XAttribute("NAME", "EDC_RCP_After"),



                 new XElement("ATTR", new XAttribute("NAME", "PartID"), partid),
                 new XElement("ATTR", new XAttribute("NAME", "RouteID"), routeid),
                  new XElement("ATTR", new XAttribute("NAME", "PDID"), pdid),
                 
                 new XElement("ATTR", new XAttribute("NAME", "ProductID"),productid),
                 new XElement("ATTR", new XAttribute("NAME", "OpeNo"), openo),
                 new XElement("ATTR", new XAttribute("NAME", "UserID"), userid),
                 new XElement("ATTR", new XAttribute("NAME", "Password"), password),
                 new XElement("ATTR", new XAttribute("NAME", "FEN"), fen),
                 new XElement("ATTR", new XAttribute("NAME", "PEN"), pen),
                  new XElement("ATTR", new XAttribute("NAME", "CustID"), custid)
                 )


     )
     );





            return "<?xml version=\"1.0\"?>\n" + doc.ToString();
        }
        private  static string GetCancelXmlRequest(string memo, string PartID, string ProductID, string RouteID, string OpeNo)
        {
         //   XDocument doc;
            XDocument doc = new XDocument(
           new XElement("REQ",

               new XElement("CLIINFO", "PIT"),
               new XElement("FUNCTION", "PT052V_OpStartCancel"),
               new XElement("VERSION", "2.4.0.2"),
               new XElement("ELE", new XAttribute("NAME", "Confirm_After"),

                   
                 
                   new XElement("ATTR", new XAttribute("NAME", "UserID"), "xx"),
                   new XElement("ATTR", new XAttribute("NAME", "Password"), "xx"),
                    new XElement("ATTR", new XAttribute("NAME", "Memo"), memo) 
                   ),
                   new XElement("ELE", new XAttribute("NAME", ""),
                   new XElement("ATTR", new XAttribute("NAME", "PartID"), PartID),
                   new XElement("ATTR", new XAttribute("NAME", "ProductID"), ProductID),
                   new XElement("ATTR", new XAttribute("NAME", "RouteID"), RouteID),
                   new XElement("ATTR", new XAttribute("NAME", "OpeNo"), OpeNo))


       )
       );





            return "<?xml version=\"1.0\"?>\n" + doc.ToString();

        }
        public static void SetCompleted(string PartID)
        {
            string res, req;
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            req = GetPartInfoXMLRequest("001", PartID);
            res = client.PMS_MainService(req);
            CheckError(res);
            string productid, routeid, status, openo, eqpid, pdid, fen, pen, custid;

            ParsePartInfoResult(res, out status, out productid, out routeid, out  openo, out eqpid, out pdid, out fen, out pen, out custid);
            if (status != "Processing")
                throw new Exception("SetCompleted:Status not Processing");

            CheckFlag checkflag = GetCheckFlag(PartID);

            //if (!(checkflag.DC >= 0 && checkflag.DC <= 2 &&
            //    checkflag.SCB >= 0 && checkflag.SCB <= 1 &&
            //    checkflag.Pick >= 0 && checkflag.Pick <= 1 &&
            //     checkflag.Sampling == 0 && checkflag.Sapphire == 0 && checkflag.CheckSRF == 0))
            if(checkflag.Comp!=0 && checkflag.Comp!=20 && checkflag.Comp!=21)
            {
                throw new Exception("error:check flag error");
            }


            //if (checkflag.DC == 0 && checkflag.CheckSRF == 0 && checkflag.Pick == 0
            //    && checkflag.Sampling == 0 && checkflag.Sapphire == 0 && checkflag.SCB == 0)
            if(checkflag.Comp==0)
            {
                req = SetPartOpComXMLRequest(PartID, productid, routeid, openo, "03424", "2");
                res = client.PMS_MainService(req);
                CheckError(res);
                return;

            }
          //  else if (checkflag.DC == 2)
            else if(checkflag.Comp==21)
            {
                req = GetDC2XmlRequest(PartID, productid, routeid, openo, "03424", "2", pdid, fen, pen, custid);
                res = client.PMS_MainService(req);
               
                CheckDC2Error(res);
                CheckError(res);

                return;

            }
            else
            {
                throw new Exception("check flag error!");
            }


        }

        
       

           

        //public static string GetTotalPassDieInfo(string partID, DateTime fromTime, DateTime toTime)
        ////Partid  MaskID
        //{
        //    string req = GetTotalPassDieInfoXmlRequest(partID, fromTime, toTime);
        //    PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
        //    string res = client.PMS_MainService(req);
        //    CheckError(res);
        //    return res;

        //}

        //public static string GetTotalPassDieInfo(string partID)
        ////Partid  MaskID
        //{
        //    string req = GetTotalPassDieInfoXmlRequest(partID, DateTime.MinValue, DateTime.MaxValue);
        //    PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
        //    string res = client.PMS_MainService(req);
        //    CheckError(res);
        //    return res;

        //}
        private static string GetTotalPassDieInfoXmlRequest(string partID, DateTime fromTime, DateTime toTime)
        {
            string strBegDate, strEndDate;
            if (fromTime == DateTime.MinValue)
                strBegDate = strEndDate = null;
            else
            {
                strBegDate = fromTime.ToString("yyyy-MM-dd HH:mm:ss");
                strEndDate = toTime.ToString("yyyy-MM-dd HH:mm:ss");

            }
            XDocument doc = new XDocument(
              new XElement("REQ",

               new XElement("CLIINFO", "angusleu.winfoundry.com;192.168.23.68"),
               new XElement("FUNCTION", "CT001V_TMS"),
               new XElement("VERSION", "1.0.0.0"),
                new XElement("ELE", new XAttribute("NAME", "Report_ALL"),

                  new XElement("ATTR", new XAttribute("NAME", "PartID"), partID),
                   new XElement("ATTR", new XAttribute("NAME", "FromTime"), strBegDate),
                    new XElement("ATTR", new XAttribute("NAME", "ToTime"), strEndDate)
                  )
          ));
            return "<?xml version=\"1.0\"?>\n" + doc.ToString();
        }
        //change return type in the feature
        public static WIP_Data[] GetWIP(string dept, string ope)
        {

            string req = GetWIPXmlRequest(dept, ope);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();

            string res = client.PMS_MainService(req);
            CheckError(res);


            return XmlToWIP_Data(res);

        }

        private static WIP_Data[] XmlToWIP_Data(string xml)
        {

            System.Collections.Generic.List<WIP_Data> list = new List<WIP_Data>();

            XDocument doc = XDocument.Parse(xml);

            var q = from n in doc.Descendants("ROW") select n;
            foreach (XElement element in q)
            {
                XElement[] cols = element.Descendants("COL").ToArray<XElement>();

                list.Add(new WIP_Data()
                {
                    ProductID = cols[0].Value.ToString().Trim(),
                    Status = cols[2].Value.ToString().Trim(),
                    Ope = cols[5].Value.ToString().Trim()
                });
            }

            return list.ToArray<WIP_Data>();
            //     XElement[] cols = q.ToArray<XElement>();

            //status = cols[8].Value.ToString().Trim();
            //productid = cols[2].Value.ToString().Trim();
            //routeid = cols[16].Value.ToString().Trim();
            //eqpid = cols[62].Value.ToString().Trim();
            //openo = cols[18].Value.ToString().Trim();
        }



        private static string GetWIPXmlRequest(string dept, string ope)
        {
            XDocument doc = new XDocument(
                new XElement("REQ",

                 new XElement("CLIINFO", "PT"),
                 new XElement("FUNCTION", "CT001V_TMS"),
                 new XElement("VERSION", "1.0.0.0"),
                  new XElement("ELE", new XAttribute("NAME", "Report_WIP"),

                    new XElement("ATTR", new XAttribute("NAME", "Dept"), dept),
                     new XElement("ATTR", new XAttribute("NAME", "Ope"), ope)



                    )
            ));

            return "<?xml version=\"1.0\"?>\n" + doc.ToString();
        }

        private static string GetCheckFlagXMLRequest(string RouteID, string OpeNO)
        {
            XDocument doc = new XDocument(
          new XElement("REQ",

              new XElement("CLIINFO", "angusleu.winfoundry.com;192.168.23.68"),
              new XElement("FUNCTION", "PT000V_PartInfo"),
              new XElement("VERSION", "1.0.0.0"),
              new XElement("ELE", new XAttribute("NAME", "CheckFlag"),

              new XElement("ATTR", new XAttribute("NAME", "ROUTE_ID"), RouteID),
              new XElement("ATTR", new XAttribute("NAME", "OPE_NO"), OpeNO)


                 /* new XElement("ATTR", new XAttribute("NAME", "CheckType"), CheckType) */
                     )
      )
      );





            return "<?xml version=\"1.0\"?>\n" + doc.ToString();
            // <?xml version="1.0"?>
            // -<REQ><CLIINFO>angusleu.winfoundry.com;192.168.23.68</CLIINFO>
            //<FUNCTION>PT000V_PartInfo</FUNCTION><VERSION>1.0.0.0</VERSION>
            //-<ELE NAME="CheckFlag">
            //<ATTR NAME="ROUTE_ID">PRECA3UONN.00</ATTR>
            //<ATTR NAME="OPE_NO">810.0300</ATTR>
            //<ATTR NAME="CheckType">checkDC</ATTR></ELE></REQ
        }
        //class CallBack : ServiceReference1.IAmidaServiceCallback
        //{
        //    public void ReceivedCommand(string xmlCmd, ServiceReference1.InportCmdType cmdType, string LeadingFileName)
        //    {
        //       // throw new NotImplementedException();
        //    }

        //    public void SayHello(string hello)
        //    {
        //      //  throw new NotImplementedException();
        //    }

        //    public void NotifyConnectionChanged()
        //    {
        //      //  throw new NotImplementedException();
        //    }

        //    public void NotifyStatusChanged(string pcname, ServiceReference1.RegisterDeviceInfo info)
        //    {
        //      //  throw new NotImplementedException();
        //    }

        //    public void NotifyClientExported(string PCName, string CmdType)
        //    {
        //      //  throw new NotImplementedException();
        //    }
        //}

        private static string GetPartInfoXMLRequest(string cliinfo, string partid)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root, node, node_1;
            XmlDeclaration dec;
            //  doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec = doc.CreateXmlDeclaration("1.0", "", ""));
            root = doc.CreateElement("REQ");
            doc.AppendChild(root);

            node = doc.CreateElement("CLIINFO");
            node.InnerText = cliinfo;
            root.AppendChild(node);
            node = doc.CreateElement("FUNCTION");
            node.InnerText = "PT000V_PartInfo";
            root.AppendChild(node);
            node = doc.CreateElement("VERSION");
            node.InnerText = "1.0.0.0";
            root.AppendChild(node);
            node = doc.CreateElement("ELE");
            XmlAttribute attr = doc.CreateAttribute("NAME");
            attr.Value = "PARTINFO";
            node.Attributes.Append(attr);
            attr = doc.CreateAttribute("NAME");
            attr.Value = "PARTINFO";
            node_1 = doc.CreateElement("ATTR");
            node_1.Attributes.Append(attr);
            node_1.InnerText = partid;
            node.AppendChild(node_1);
            root.AppendChild(node);
            return doc.InnerXml;
        }

        private static string SetPartTrackInXMLRequest(string PartID, string ProductID, string RouteID, string OpeNO, string EQPID, string recipe, string UserID, string Password)
        {
            XDocument doc = new XDocument(
            new XElement("REQ",

                new XElement("CLIINFO", "angusleu.winfoundry.com;192.168.23.68"),
                new XElement("FUNCTION", "PT002V_PartTrackIn"),
                new XElement("VERSION", "1.0.0.0"),
                new XElement("ELE", new XAttribute("NAME", "OperationStart"),
                    new XElement("ATTR", new XAttribute("NAME", "PartID"), PartID),
                    new XElement("ATTR", new XAttribute("NAME", "ProductID"), ProductID),
                    new XElement("ATTR", new XAttribute("NAME", "RouteID"), RouteID),
                    new XElement("ATTR", new XAttribute("NAME", "OpeNo"), OpeNO),
                    new XElement("ATTR", new XAttribute("NAME", "EQPID"), EQPID),
                    new XElement("ATTR", new XAttribute("NAME", "recipe"), recipe),
                    new XElement("ATTR", new XAttribute("NAME", "UserID"), UserID),
                    new XElement("ATTR", new XAttribute("NAME", "Password"), Password)
                    )
        )
        );





            return "<?xml version=\"1.0\"?>\n" + doc.ToString();


            //    <?xml version="1.0"?>
            //    <REQ>
            //   <CLIINFO>angusleu.winfoundry.com;192.168.23.68</CLIINFO>
            // <FUNCTION>PT002V_PartTrackIn</FUNCTION>
            //  <VERSION>1.0.0.0</VERSION>
            // <ELE NAME="OperationStart">
            //<ATTR NAME="PartID">WS679P071-01</ATTR>
            //<ATTR NAME="ProductID">WS679A-5000NPLSH6AX1.00</ATTR>
            //<ATTR NAME="RouteID">PRECD1UNNN.00</ATTR>
            //<ATTR NAME="OpeNo">810.0242</ATTR>
            //<ATTR NAME="EQPID">BPS-1</ATTR>
            //<ATTR NAME="recipe">2</ATTR>
            //<ATTR NAME="UserID">XXXX</ATTR>
            //<ATTR NAME="Password">XXXX</ATTR>
            //</ELE></REQ>
        }

        private static string SetPartOpComXMLRequest(string PartID, string ProductID, string RouteID, string OpeNO, string UserID, string Password)
        {
            XDocument doc = new XDocument(
           new XElement("REQ",

               new XElement("CLIINFO", "angusleu.winfoundry.com;192.168.23.68"),
               new XElement("FUNCTION", "PT000V_PartInfo"),
               new XElement("VERSION", "1.0.0.0"),
               new XElement("ELE", new XAttribute("NAME", "OperationComplete"),
                   new XElement("ATTR", new XAttribute("NAME", "PartID"), PartID),
                   new XElement("ATTR", new XAttribute("NAME", "ProductID"), ProductID),
                   new XElement("ATTR", new XAttribute("NAME", "RouteID"), RouteID),
                   new XElement("ATTR", new XAttribute("NAME", "OpeNo"), OpeNO),


                   new XElement("ATTR", new XAttribute("NAME", "UserID"), UserID),
                   new XElement("ATTR", new XAttribute("NAME", "Password"), Password)
                   )
       )
       );





            return "<?xml version=\"1.0\"?>\n" + doc.ToString();
            //  <?xml version="1.0"?>
            // -<REQ><CLIINFO>angusleu.winfoundry.com;192.168.23.68</CLIINFO>
            //<FUNCTION>PT000V_PartInfo</FUNCTION>
            //<VERSION>1.0.0.0</VERSION>
            //-<ELE NAME="OperationComplete">
            //<ATTR NAME="PartID">WH949P447-06</ATTR>
            //<ATTR NAME="ProductID">WH949A=2U00VP8XB2M31.00</ATTR>
            //<ATTR NAME="RouteID">PRECA3UONN.00</ATTR>
            //<ATTR NAME="OpeNo">810.0300</ATTR>
            // <ATTR NAME="UserID">02118</ATTR>
            //<ATTR NAME="Password">432</ATTR></ELE></REQ>
        }

        private static void CheckDC2Error(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            if (doc.Descendants("COL").FirstOrDefault()!=null)
            {
                throw new Exception(doc.Descendants("COL").FirstOrDefault().Value.Trim());
            }
        }
        private static void CheckError(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            if (doc.Descendants("ELE").Attributes("NAME").First().Value == "ERROR")
            {
                XElement[] attrs = doc.Descendants("ATTR").ToArray();
                throw new Exception(attrs[0].Value.Trim() + "," + attrs[1].Value.Trim());
            }
        }
        private static void ParsePartInfoResult(string xml, out string status, out string productid, out string routeid, out string openo, out string eqpid,out string pdid,out string fen,out string pen,out string custid)
        {


            XDocument doc = XDocument.Parse(xml);

            var q = from n in doc.Descendants("COL") select n;
            XElement[] cols = q.ToArray<XElement>();
            status = cols[8].Value.ToString().Trim();
            productid = cols[2].Value.ToString().Trim();
            routeid = cols[16].Value.ToString().Trim();
            eqpid = cols[62].Value.ToString().Trim();
            openo = cols[18].Value.ToString().Trim();
            pdid = cols[17].Value.ToString().Trim();
            fen = cols[26].Value.ToString().Trim();
            pen = cols[27].Value.ToString().Trim();
            custid = cols[40].Value.ToString().Trim();
        }

        public static  GoodDies_Data[] GetTotalPassDieInfo(string partID, DateTime fromTime, DateTime toTime)
        //Partid  MaskID
        {
            string req = GetTotalPassDieInfoXmlRequest(partID, fromTime, toTime);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            string res = client.PMS_MainService(req);
            CheckError(res);
            return XmlToGoodDies_Data(res);

        }
        public static GoodDies_Data[] GetTotalPassDieInfo(string partID)
        //Partid  MaskID
        {
            string req = GetTotalPassDieInfoXmlRequest(partID, DateTime.MinValue, DateTime.MaxValue);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            string res = client.PMS_MainService(req);
            CheckError(res);
            return XmlToGoodDies_Data(res);

        }

        //private static string GetTotalPassDieInfoXmlRequest(string partID, DateTime fromTime, DateTime toTime)
        //{
        //    string strBegDate, strEndDate;
        //    if (fromTime == DateTime.MinValue)
        //        strBegDate = strEndDate = null;
        //    else
        //    {
        //        strBegDate = fromTime.ToString("yyyy-MM-dd HH:mm:ss");
        //        strEndDate = toTime.ToString("yyyy-MM-dd HH:mm:ss");

        //    }
        //    XDocument doc = new XDocument(
        //      new XElement("REQ",

        //       new XElement("CLIINFO", "angusleu.winfoundry.com;192.168.23.68"),
        //       new XElement("FUNCTION", "CT001V_TMS"),
        //       new XElement("VERSION", "1.0.0.0"),
        //        new XElement("ELE", new XAttribute("NAME", "Report_All"),

        //          new XElement("ATTR", new XAttribute("NAME", "PartID"), partID),
        //           new XElement("ATTR", new XAttribute("NAME", "FromTime"), strBegDate),
        //            new XElement("ATTR", new XAttribute("NAME", "ToTime"), strEndDate)
        //          )
        //  ));
        //    return "<?xml version=\"1.0\"?>\n" + doc.ToString();
        //}
        public static GoodDies_Data[] XmlToGoodDies_Data(string xml)
        {
            System.Collections.Generic.List<GoodDies_Data> list = new List<GoodDies_Data>();

            XDocument doc = XDocument.Parse(xml);

            var q = from n in doc.Descendants("ROW") select n;
            foreach (XElement element in q)
            {
                XElement[] cols = element.Descendants("COL").ToArray<XElement>();

                list.Add(new GoodDies_Data()
                {
                    ProductID = cols[0].Value.ToString().Trim(),
                    GoodDies = System.Convert.ToInt32(cols[1].Value.ToString())

                });
            }

            return list.ToArray<GoodDies_Data>();
        }





    }
    public class GoodDies_Data
    {

        public string ProductID { get; set; }

        public int GoodDies { get; set; }
    }
    public class WIP_Data
    {
        public string ProductID { get; set; }
        public string Status { get; set; }
        public string Ope { get; set; }
        public string MaskID
        {

            get
            {
                return ProductID.Substring(0, 5);
            }
        }
    }

        public class FileComparer : IComparer<string>
        {


            public int Compare(string x, string y)
            {
                try
                {
                    return (int)(System.IO.File.GetLastWriteTime(x) - System.IO.File.GetLastWriteTime(y)).TotalMilliseconds;
                }
                catch
                {
                    return int.MaxValue;
                }
            }
        }
    

}