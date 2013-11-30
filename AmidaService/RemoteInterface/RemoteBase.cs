using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteInterface
{
    abstract public class RemoteClassBase : MarshalByRefObject
    {

        public string HelloWorld()
        {
            return "HelloWorld!";
        }




    }
}
