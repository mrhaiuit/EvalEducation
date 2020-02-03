using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorInsertValidator))]
    public class OperatorInsertReq : OperatorBaseReq
    {
        public string OWNER { get; set; }
        public string EMPLOYEE_NO { get; set; }
        public string OPER_NO { get; set; }
        public string OPER_CLASS_1 { get; set; }
        public string OPER_CLASS_2 { get; set; }
        public string OPER_CLASS_3 { get; set; }
        public string OPER_CLASS_4 { get; set; }
        public string OPER_PWD { get; set; }
        public string FULL_NAME { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public Nullable<System.DateTime> UPD_TS { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN_TS { get; set; }
        public Nullable<System.DateTime> LAST_LOGOUT_TS { get; set; }
        public string IP_ADDRESS { get; set; }
        public string DEPT_CODE { get; set; }
        public string SUB_DEPT_CODE { get; set; }
        public Nullable<System.DateTime> LAST_UPD_PWD_TS { get; set; }
    }

    public class OperatorInsertValidator : AbstractValidator<OperatorInsertReq>
    {
        public OperatorInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.ModuleCodeIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_NAME)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }
    }
}
