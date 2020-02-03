using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.Account
{
    [Validator(typeof(OperatorDeleteValidator))]
    public class OperatorDeleteReq : OperatorBaseReq
    {
    }

    public class OperatorDeleteValidator : AbstractValidator<OperatorDeleteReq>
    {
        public OperatorDeleteValidator()
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