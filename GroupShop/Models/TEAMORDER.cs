//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEAMORDER
    {
        public string MEMBERID { get; set; }
        public string TEAMID { get; set; }
        public string PRODUCTID { get; set; }
        public Nullable<int> AMOUNT { get; set; }
        public Nullable<decimal> QUANTITY { get; set; }
    
        public virtual MEMBERS MEMBERS { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual TEAMBUY TEAMBUY { get; set; }
    }
}
