namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(budget_planMetaData))]
    public partial class budget_plan
    {
    }
    
    public partial class budget_planMetaData
    {
        [Required]
        public int bgid { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string staff { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string prj { get; set; }
        public Nullable<int> budget { get; set; }
        public string comt { get; set; }
    }
}
