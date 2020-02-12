using EVE.ApiModels.Authentication.Request;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(OperatorDeleteValidator))]
    public class EmployeeDeleteReq : EmployeeBaseReq
    {
    }

    public class OperatorDeleteValidator : AbstractValidator<EmployeeBaseReq>
    {
        public OperatorDeleteValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
        }
    }
}