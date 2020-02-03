using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.Account
{
    [Validator(typeof(OperatorUpdateValidator))]
    public class OperatorUpdateReq : OperatorInsertReq
    {
    }

    public class OperatorUpdateValidator : AbstractValidator<OperatorUpdateReq>
    {
        public OperatorUpdateValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_NAME)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());}
    }
}
