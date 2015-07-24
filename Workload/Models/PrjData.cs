//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrjData
    {
        public PrjData()
        {
            this.audit_edit = new HashSet<audit_edit>();
            this.budget_plan = new HashSet<budget_plan>();
            this.Worksheet = new HashSet<Worksheet>();
        }
    
        public string PrjNo { get; set; }
        public string PrjE1 { get; set; }
        public string PrjName { get; set; }
        public Nullable<int> PrjStart { get; set; }
        public Nullable<int> PrjEnd { get; set; }
        public string Editor { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ICollection<audit_edit> audit_edit { get; set; }
        public virtual ICollection<budget_plan> budget_plan { get; set; }
        public virtual MonthData MonthData { get; set; }
        public virtual MonthData MonthData1 { get; set; }
        public virtual ICollection<Worksheet> Worksheet { get; set; }
    }
}
