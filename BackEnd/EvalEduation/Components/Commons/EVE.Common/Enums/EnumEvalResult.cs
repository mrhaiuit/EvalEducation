

using System;

namespace EVE.Commons
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class EnumEvalResult : StringEnumClass
    {

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalResult Tot = new EnumEvalResult("EXC");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalResult Kha = new EnumEvalResult("GOO");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalResult Dat = new EnumEvalResult("NOR");

        [CustomTypeEditorBrowsable(true)]
        public static readonly EnumEvalResult KhongDat = new EnumEvalResult("LOW");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private EnumEvalResult(String code)
            : base(code)
        {

        }
        
    }
}


