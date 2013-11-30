using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using AmidaClientServiceDll.AmidaService;

namespace AmidaClientServiceWrapper
{
    class Program
    {
        static void Main(string[] args)
        {

         //   AmidaClientServiceWrapper.AmidaService.VerifyNoteData data;
            //AmidaService.VerifyNoteData data = new AmidaService.VerifyNoteData()
            //{
            //     Fail=0,
            //      MAP="map",
            //       Operators="operators",
            //        Pass=100,
            //         PCID="pcid",
            //          RCP="RCP",
            //           StartTimes=DateTime.Now,
            //            StopTimes=DateTime.Now,
            //             TestVerify="testverify",
            //              TestVerifyDate=DateTime.Now,
            //               TouchDo=1234,
            //                TPS="tps",
            //                 WaferID="waferid"
                             
            //};
           // System.Xml.Serialization.XmlSerializer sz = new System.Xml.Serialization.XmlSerializer(typeof(VerifyNoteData));

           // System.IO.FileStream fs = System.IO.File.OpenRead("example.xml");
           //data = sz.Deserialize(fs) as VerifyNoteData;
           // fs.Close();
            AmidaClientService.Service.DeviceType = "WANA";
            new AmidaClientService.AmidaClientExportThread();
            Console.ReadLine();
        }
    }
}
