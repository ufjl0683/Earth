//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace sqltest
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserGroup
    {
        public tblUserGroup()
        {
            this.tblUser = new HashSet<tblUser>();
            this.tblUserGroupMenu = new HashSet<tblUserGroupMenu>();
        }
    
        public int GroupID { get; set; }
        public string GroupName { get; set; }
    
        public virtual ICollection<tblUser> tblUser { get; set; }
        public virtual ICollection<tblUserGroupMenu> tblUserGroupMenu { get; set; }
    }
}
