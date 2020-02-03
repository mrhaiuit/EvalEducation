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
    
    public partial class School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public School()
        {
            this.Employees = new HashSet<Employee>();
            this.EvalMasters = new HashSet<EvalMaster>();
        }
    
        public int SchoolId { get; set; }
        public string School1 { get; set; }
        public string Address { get; set; }
        public Nullable<int> EduDepartmentId { get; set; }
        public Nullable<int> EduProvinceId { get; set; }
        public string SchoolLevelCode { get; set; }
        public string PhoneNumber { get; set; }
        public string HotLine { get; set; }
        public string MinistryofEducationaCode { get; set; }
    
        public virtual EduDepartment EduDepartment { get; set; }
        public virtual EduProvince EduProvince { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalMaster> EvalMasters { get; set; }
        public virtual MinistryofEducation MinistryofEducation { get; set; }
        public virtual SchoolLevel SchoolLevel { get; set; }
        public virtual EduMinistry EduMinistry { get; set; }
    }
}