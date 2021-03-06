//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EVE.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EvalMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvalMaster()
        {
            this.EvalDetails = new HashSet<EvalDetail>();
        }
    
        public int EvalMasterId { get; set; }
        public Nullable<int> Year { get; set; }
        public string EvalTypeCode { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Active { get; set; }
        public string EvalStateCode { get; set; }
    
        public virtual EvalState EvalState { get; set; }
        public virtual EvalType EvalType { get; set; }
        public virtual School School { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalDetail> EvalDetails { get; set; }
    }
}
