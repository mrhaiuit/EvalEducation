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
    
    public partial class EvalGuide
    {
        public string EvalResultCode { get; set; }
        public int EvalCriteriaId { get; set; }
        public string Description { get; set; }
        public string Sample { get; set; }
    
        public virtual EvalCriteria EvalCriteria { get; set; }
        public virtual EvalResult EvalResult { get; set; }
    }
}