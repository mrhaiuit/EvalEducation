using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(OperatorInsertValidator))]
    public class EmployeeInsertReq : EmployeeBaseReq
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

        public string IP_ADDRESS { get; set; }

        public string DEPT_CODE { get; set; }

        public string SUB_DEPT_CODE { get; set; }
    }

    public class OperatorInsertValidator : AbstractValidator<EmployeeInsertReq>
    {
        public OperatorInsertValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
        }
    }
}
