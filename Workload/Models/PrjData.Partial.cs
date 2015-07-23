namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PrjDataMetaData))]
    public partial class PrjData
    {
    }
    
    public partial class PrjDataMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PrjNo { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string PrjE1 { get; set; }
        
        [StringLength(255, ErrorMessage="欄位長度不得大於 255 個字元")]
        public string PrjName { get; set; }
        public Nullable<int> PrjStart { get; set; }
        public Nullable<int> PrjEnd { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string Editor { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
