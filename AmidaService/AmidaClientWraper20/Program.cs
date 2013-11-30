using System;
using System.Collections.Generic;
using System.Text;

namespace AmidaClientWraper20
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0)
                AmidaClientService20.Service.DestIP = "127.0.0.1";
            else
            AmidaClientService20.Service.DestIP = args[0];
            new AmidaClientService20.AmidaClientExportThread();
            Console.ReadKey();
        }
    }
}
