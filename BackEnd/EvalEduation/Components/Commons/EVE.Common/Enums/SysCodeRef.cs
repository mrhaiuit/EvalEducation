
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVE.Commons
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class SysCodeRef : StringEnumClass
    {

        #region SYS CODE REF

        /// <summary>
        /// "RPR". RPR
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeRef ContReparingService = new SysCodeRef("RPR");

        /// <summary>
        /// "PAPER". PAPER
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeRef PaperInv = new SysCodeRef("PAPER");

        /// <summary>
        /// "EBILL". EBILL
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeRef EBillInv = new SysCodeRef("EBILL");

        public static readonly SysCodeRef RevenueBackDays = new SysCodeRef("DAY_BACK");
        public static readonly SysCodeRef Confirm = new SysCodeRef("CONFIRM");
        public static readonly SysCodeRef Ignore = new SysCodeRef("IGNORE");

        public static readonly SysCodeRef Apply = new SysCodeRef("APPLY");
        public static readonly SysCodeRef CateRecvEdi = new SysCodeRef("CATE_RECV_EDI");


        public static readonly SysCodeRef DVCB = new SysCodeRef("DVCB");

        public static readonly SysCodeRef QLHH = new SysCodeRef("QLHH");

        public static readonly SysCodeRef TOPO = new SysCodeRef("TOPO");

        public static readonly SysCodeRef EPORT = new SysCodeRef("EPORT");

        public static readonly SysCodeRef ALL = new SysCodeRef("ALL");


        //@@dungv2:
        //https://pms.snp.com.vn/browse/TOPO-1134   
        //[Task] Thêm chỉ định cont tank khi GateIn tại T01, hiện thị S14 tại T00
        public static readonly SysCodeRef  TankMaxTare = new SysCodeRef("TANK_MAX_TARE");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private SysCodeRef(String code)
            : base(code)
        {

        }

        #endregion

    }
}
