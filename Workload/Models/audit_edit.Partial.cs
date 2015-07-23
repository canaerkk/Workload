namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(audit_editMetaData))]
    public partial class audit_edit
    {
    }
    
    public partial class audit_editMetaData
    {
        [Required]
        public int auid { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string style { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string prj { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string staff { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string editor { get; set; }
        public Nullable<System.DateTime> ctime { get; set; }
    }
}
