using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmidaService.Messages
{
     public class ImportCmdData
    {
         public string Cmd { get; set; }

         public string param1 { get; set; }
         public string param2 { get; set; }
         public string param3 { get; set; }
         public string eq_operator { get; set; }
         public DateTime start_time { get; set; }

    }
}
