﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjCooking.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbCookingEntities : DbContext
    {
        public dbCookingEntities()
            : base("name=dbCookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t參加者> t參加者 { get; set; }
        public virtual DbSet<t評價> t評價 { get; set; }
        public virtual DbSet<t會員> t會員 { get; set; }
        public virtual DbSet<t聚會> t聚會 { get; set; }
        public virtual DbSet<t建議食材> t建議食材 { get; set; }
    }
}
