namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(WorksheetMetaData))]
    public partial class Worksheet
    {
    }
    
    public partial class WorksheetMetaData
    {
        [Required]
        public int WorkID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Prj { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string Staff { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Hour { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string Editor { get; set; }
    
        public virtual MonthData MonthData { get; set; }
        public virtual PrjData PrjData { get; set; }
    }
}
