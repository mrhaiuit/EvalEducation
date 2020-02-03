using System;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.OperatorUserClassSite
{
    [Validator(typeof(OperatorUserClassSiteUserClassSiteInsertValidator))]
    public class OperatorUserClassSiteInsertReq : OperatorUserClassSiteBaseReq
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

        public DateTime? LAST_LOGIN_TS { get; set; }

        public DateTime? LAST_LOGOUT_TS { get; set; }

        public string IP_ADDRESS { get; set; }

        public string DEPT_CODE { get; set; }

        public string SUB_DEPT_CODE { get; set; }

        public DateTime? LAST_UPD_PWD_TS { get; set; }
    }

    public class OperatorUserClassSiteUserClassSiteInsertValidator : AbstractValidator<OperatorUserClassSiteInsertReq>
    {
        public OperatorUserClassSiteUserClassSiteInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
            RuleFor(c => c.OPERATOR)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());
        }
    }
}
