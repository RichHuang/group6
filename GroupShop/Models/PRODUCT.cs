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
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.TEAMORDER = new HashSet<TEAMORDER>();
        }
    
        public string PRODUCTID { get; set; }
        public string SUPPLIERID { get; set; }
        public string NAME { get; set; }
        public int UNITPRICE { get; set; }
    
        public virtual SUPPLIER SUPPLIER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEAMORDER> TEAMORDER { get; set; }
    }
}
