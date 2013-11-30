using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteInterface
{
    [Serializable]
   public  class NotifyMessage
    {
        public string title;
        public string text;
        public DateTime TimeStamp;
        public string Key;
        public bool IsFinish;
        public NotifyMessage Clone()
        {
            return (NotifyMessage)this.MemberwiseClone();
        }

        
    }
}
