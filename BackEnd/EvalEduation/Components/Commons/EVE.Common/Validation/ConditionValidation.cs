using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.Commons
{
   public static class ConditionValidation
    {
        public static ConditionValidationRule EmptyValidation()
        {
            return new ConditionValidationRule()
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorType = ErrorType.Critical,
                ErrorText = "Thông tin bắt buộc nhập!"
            };
        }
    }
}
