using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.OperatorUserClassSite
{
    [Validator(typeof(OperatorUserClassSiteDeleteValidator))]
    public class OperatorUserClassSiteDeleteReq : OperatorUserClassSiteBaseReq
    {
    }

    public class OperatorUserClassSiteDeleteValidator : AbstractValidator<OperatorUserClassSiteDeleteReq>
    {
        public OperatorUserClassSiteDeleteValidator()
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
