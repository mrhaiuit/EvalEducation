using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(OperatorUpdateValidator))]
    public class EmployeeUpdateReq : EmployeeInsertReq
    {
    }

    public class OperatorUpdateValidator : AbstractValidator<EmployeeUpdateReq>
    {
        public OperatorUpdateValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
        }
    }
}
