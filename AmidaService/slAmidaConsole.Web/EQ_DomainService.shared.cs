using System;
using System.Collections.Generic;
using System.Linq;
 
namespace slAmidaConsole.Web
{
    public partial class tblUser
    {
        //public override bool Equals(object obj)
        //{
        //    slAmidaConsole.Web.tblUserGroup userGroup = obj as slAmidaConsole.Web.tblUserGroup;
        //    if (userGroup == null)
        //        return false;
        //    else
        //    {
        //        return userGroup.GroupID == this.GroupID;

        //    }
        //    //return base.Equals(obj);
        //}
        public string GroupName
        {
            get
            {
                return this.tblUserGroup.GroupName;
            }
        }
    }

    public partial class tblVerifyNote
    {
       

        public string WaferMask
        {
            get
            {
                return this.WaferID.Substring(0, 5);
            }
        }
    }
}