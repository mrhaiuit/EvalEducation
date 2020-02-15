

using System;

namespace EVE.Commons
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class EnumSchoolLevel : StringEnumClass
    {

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumSchoolLevel HighSchool = new EnumSchoolLevel("HISC");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumSchoolLevel JuniorHighSchool = new EnumSchoolLevel("JUHS");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumSchoolLevel PresSchool = new EnumSchoolLevel("PRES");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumSchoolLevel PrimarySchool = new EnumSchoolLevel("PRIM");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private EnumSchoolLevel(String code)
            : base(code)
        {

        }
        
    }
}


