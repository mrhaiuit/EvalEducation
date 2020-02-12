using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(OperatorGetByIdValidator))]
    public class EmployeeGetByIdReq : EmployeeBaseReq
    {
    }

    public class OperatorGetByIdValidator : AbstractValidator<EmployeeGetByIdReq>
    {
        public OperatorGetByIdValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
        }
    }
}
