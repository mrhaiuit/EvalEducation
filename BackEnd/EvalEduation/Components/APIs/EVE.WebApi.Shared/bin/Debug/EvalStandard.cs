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
    
    public partial class EvalStandard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvalStandard()
        {
            this.EvalCriterias = new HashSet<EvalCriteria>();
        }
    
        public int EvalStandardId { get; set; }
        public string EvalStandardName { get; set; }
        public string SchoolLevelCode { get; set; }
        public string EvalTypeCode { get; set; }
        public Nullable<int> Idx { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalCriteria> EvalCriterias { get; set; }
        public virtual EvalType EvalType { get; set; }
        public virtual SchoolLevel SchoolLevel { get; set; }
    }
}
