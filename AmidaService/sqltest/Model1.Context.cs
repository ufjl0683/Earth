﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AmidaEntities : DbContext
    {
        public AmidaEntities()
            : base("name=AmidaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PC_Rec_tbl> PC_Rec_tbl { get; set; }
        public DbSet<PC_tbl> PC_tbl { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblAlarm> tblAlarm { get; set; }
        public DbSet<tblEQ> tblEQ { get; set; }
        public DbSet<tblEQHistory> tblEQHistory { get; set; }
        public DbSet<tblMaskInfo> tblMaskInfo { get; set; }
        public DbSet<tblMenu> tblMenu { get; set; }
        public DbSet<tblMenuGroup> tblMenuGroup { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
        public DbSet<tblUserGroup> tblUserGroup { get; set; }
        public DbSet<tblUserGroupMenu> tblUserGroupMenu { get; set; }
        public DbSet<tblVerifyNote> tblVerifyNote { get; set; }
        public DbSet<tblVerifyTimeLog> tblVerifyTimeLog { get; set; }
        public DbSet<tblVerifyTimeRef> tblVerifyTimeRef { get; set; }
    }
}
