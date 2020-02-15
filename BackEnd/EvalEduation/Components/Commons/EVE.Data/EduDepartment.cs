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
    
    public partial class EduDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EduDepartment()
        {
            this.Schools = new HashSet<School>();
            this.UserGroup_Employee = new HashSet<UserGroup_Employee>();
            this.Employees = new HashSet<Employee>();
        }
    
        public int EduDepartmentId { get; set; }
        public string EduDepartmentName { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> EduProvinceId { get; set; }
        public string Address { get; set; }
        public Nullable<int> Idx { get; set; }
    
        public virtual District District { get; set; }
        public virtual EduProvince EduProvince { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<School> Schools { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserGroup_Employee> UserGroup_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
