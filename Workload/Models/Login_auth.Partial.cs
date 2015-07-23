namespace Workload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Login_authMetaData))]
    public partial class Login_auth
    {
    }
    
    public partial class Login_authMetaData
    {
        [Required]
        public int auid { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string empid { get; set; }
        public Nullable<int> authority { get; set; }
    }
}
