namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MonthDataMetaData))]
    public partial class MonthData
    {
    }
    
    public partial class MonthDataMetaData
    {
        [Required]
        public int MonthPK { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Year { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Month { get; set; }
        public Nullable<int> Week { get; set; }
    
        public virtual ICollection<PrjData> PrjData { get; set; }
        public virtual ICollection<PrjData> PrjData1 { get; set; }
        public virtual ICollection<Worksheet> Worksheet { get; set; }
    }
}
