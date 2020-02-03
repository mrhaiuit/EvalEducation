using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.OperatorUserClassSite
{
    [Validator(typeof(OperatorUserClassSiteUpdateValidator))]
    public class OperatorUserClassSiteUpdateReq : OperatorUserClassSiteInsertReq
    {
    }

    public class OperatorUserClassSiteUpdateValidator : AbstractValidator<OperatorUserClassSiteUpdateReq>
    {
        public OperatorUserClassSiteUpdateValidator()
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
