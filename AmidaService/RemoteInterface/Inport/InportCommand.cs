using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteInterface.Inport
{
    [Serializable]
    public  class InportCommand
    {

        public string  leadingFilename;
        public string xmlcmd;
         public InportCommand(string xmlcmd,string leadingFilename)
         {
             this.xmlcmd = xmlcmd;
             this.leadingFilename = leadingFilename;
         }
    }
}
