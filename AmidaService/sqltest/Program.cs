using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {

            sqltest.AmidaEntities db=new AmidaEntities();
            var q = from n in  db.tblEQHistory where n.start_time >= new DateTime(2015,7,1)  select n;
        }
    }
}
