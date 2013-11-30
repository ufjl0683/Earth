using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace slAmidaConsole.Web.PMS
{
    public class PMSHelper
    {

        public static WIP_Data[] GetWIP(string dept, string ope)
        {
 
          
 

            string req = GetWIPXmlRequest(dept, ope);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();

            string res = client.PMS_MainService(req);
            CheckError(res);


            return XmlToWIP_Data(res);
 

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

        public static WIP_Data[] XmlToWIP_Data(string xml)
        {

            System.Collections.Generic.List<WIP_Data> list = new List<WIP_Data>();

            XDocument doc = XDocument.Parse(xml);

            var q = from n in doc.Descendants("ROW")  select n;
            foreach (XElement element in q)
            {
                XElement[] cols = element.Descendants("COL").ToArray<XElement>();

                list.Add(new WIP_Data()
                {
                    ProductID = cols[0].Value.ToString().Trim(),
                    Status = cols[2].Value.ToString().Trim(),
                    Ope = cols[5].Value.ToString().Trim(),
                  //  PF=cols[11].Value.ToString().Trim()
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


        public  static PMS.GoodDies_Data[] GetTotalPassDieInfo(string partID, DateTime fromTime, DateTime toTime)
        //Partid  MaskID
        {
            string req = GetTotalPassDieInfoXmlRequest(partID, fromTime, toTime);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            string res = client.PMS_MainService(req);
            CheckError(res);
            return  XmlToGoodDies_Data( res);

        }

        public static PMS.GoodDies_Data[] GetTotalPassDieInfo(string partID)
        //Partid  MaskID
        {
            string req = GetTotalPassDieInfoXmlRequest(partID, DateTime.MinValue, DateTime.MaxValue);
            PMSService.WINServiceSoapClient client = new PMSService.WINServiceSoapClient();
            string res = client.PMS_MainService(req);
            CheckError(res);
            return XmlToGoodDies_Data( res);

        }

        private static  string GetTotalPassDieInfoXmlRequest(string partID, DateTime fromTime, DateTime toTime)
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

               new XElement("CLIINFO", "PIT"),
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
                     GoodDies =System.Convert.ToInt32( cols[1].Value.ToString())
                    
                });
            }

            return list.ToArray<GoodDies_Data>();
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

    }



    public class WIP_Data
    {
        public string ProductID { get; set; }
        public string Status { get; set; }
        public string Ope { get; set; }
        private string _PF;
        public string MaskID
        {

            get
            {
                return ProductID.Substring(0, 5);
            }
        }

        public string PF
        {
            set
            {
                _PF = value.ToUpper()[0].ToString();
            }

            get
            {
                return _PF;
            }
            
        }

    }


    public class GoodDies_Data
    {

       public  string ProductID { get; set; } //from pms

       public int GoodDies { get; set; }

       public string WaferID  //to TMS
       {
           get
           {
               return ProductID.Substring(0, 5) + "-" + ProductID.Substring(5, 4) + "_" + int.Parse(ProductID.Substring(10, 2)).ToString();
           }
       }
    }
}