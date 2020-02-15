

using System;

namespace EVE.Commons
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class EnumEvalLevel : StringEnumClass
    {

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalLevel DEPARMENT = new EnumEvalLevel("DEPARMENT");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalLevel MINISTRY = new EnumEvalLevel("MINISTRY");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalLevel PROVINCE = new EnumEvalLevel("PROVINCE");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalLevel SCHOOL = new EnumEvalLevel("SCHOOL");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalLevel TADMIN = new EnumEvalLevel("TADMIN");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private EnumEvalLevel(String code)
            : base(code)
        {

        }
        
    }
}


