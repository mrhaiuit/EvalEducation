using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.Account
{
    [Validator(typeof(OperatorGetByIdValidator))]
    public class OperatorGetByIdReq : OperatorBaseReq
    {
    }

    public class OperatorGetByIdValidator : AbstractValidator<OperatorGetByIdReq>
    {
        public OperatorGetByIdValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_NAME)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());
        }
    }
}
