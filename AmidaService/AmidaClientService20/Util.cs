using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace AmidaClientService20
{
    class Util
    {
        public static void WriteEventLog(string mesg)
        {
            System.Diagnostics.EventLog verifylog = new System.Diagnostics.EventLog() { Source = "AmidaClientService" };
            verifylog.WriteEntry(mesg);
        }
    }
}
