//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class t會員
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t會員()
        {
            this.t參加者 = new HashSet<t參加者>();
            this.t聚會 = new HashSet<t聚會>();
            this.t留言 = new HashSet<t留言>();
            this.t檢舉 = new HashSet<t檢舉>();
        }
    
        public int f會員Id { get; set; }
        public string f會員信箱 { get; set; }
        public string f會員密碼 { get; set; }
        public string f會員姓名 { get; set; }
        public string f會員電話 { get; set; }
        public Nullable<int> f性別 { get; set; }
        public string f自我介紹 { get; set; }
        public string f會員照片 { get; set; }
        public Nullable<int> f權限 { get; set; }
        public System.DateTime f會員建立日期 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t參加者> t參加者 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t聚會> t聚會 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t留言> t留言 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t檢舉> t檢舉 { get; set; }
    }
}
