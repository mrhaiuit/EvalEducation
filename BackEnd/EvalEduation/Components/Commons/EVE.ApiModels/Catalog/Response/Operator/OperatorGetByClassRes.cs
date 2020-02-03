using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Data;

namespace EVE.ApiModels.Catalog.Response.Operator
{
    public class OperatorGetByClassRes
    {
        public OperatorGetByClassRes()
        { }

        public string SITE_ID { get; set; }
        public string OPER_NAME { get; set; }
        public string OPER_CLASS_1 { get; set; }
        public string FULL_NAME { get; set; }
        public string IP_ADDRESS { get; set; }
        public string DEPT_CODE { get; set; }
    }
}
