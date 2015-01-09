using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Text;

namespace PCMClientService
{
    class Program
    {
        static void Main(string[] args)
        {
          string  BaseDirectory = @"C:\TMS\";

          if (args.Length == 0)
                 AmidaClientService20.Service.DestIP = "10.14.2.18";
           //   AmidaClientService20.Service.DestIP = "127.0.0.1";
          else
              AmidaClientService20.Service.DestIP = args[0];

          StreamReader rd= new StreamReader(    System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "config.txt"));
            string s;
            while(( s=rd.ReadLine())!=null)
            {
                s=s.Trim();
                if (s != "")
                    new AmidaClientService20.AmidaClientExportThread(s,BaseDirectory+s+"\\");
            }


            Console.ReadKey();
        }
    }
}
