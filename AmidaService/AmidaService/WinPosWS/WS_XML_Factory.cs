using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AmidaService.WinPosWS
{
   public class WS_XML_Factory
    {
       public static string GetPartInfoXMLRequest(string cliinfo,string productid)
       {
           XmlDocument doc = new XmlDocument();
           XmlElement root,node,node_1;
           XmlDeclaration dec;
         //  doc.CreateXmlDeclaration("1.0", "utf-8", null);
           doc.AppendChild(dec=  doc.CreateXmlDeclaration("1.0", "", ""));
           root= doc.CreateElement("REQ");
           doc.AppendChild(root);

           node= doc.CreateElement("CLIINFO");
           node.InnerText = cliinfo;
           root.AppendChild(node);
           node = doc.CreateElement("FUNCTION");
           node.InnerText="PT000V_PartInfo";
           root.AppendChild(node);
           node = doc.CreateElement("VERSION");
           node.InnerText = "1.0.0.0";
           root.AppendChild(node);
           node=doc.CreateElement("ELE");
           XmlAttribute attr=doc.CreateAttribute("NAME");
           attr.Value="PARTINFO";
           node.Attributes.Append(attr);
           attr = doc.CreateAttribute("NAME");
           attr.Value = "PARTINFO";
           node_1=doc.CreateElement("ATTR");
           node_1.Attributes.Append(attr);
           node_1.InnerText=productid;
            node.AppendChild(node_1);
            root.AppendChild(node);
            return doc.InnerXml;
       }


      

    }
}
