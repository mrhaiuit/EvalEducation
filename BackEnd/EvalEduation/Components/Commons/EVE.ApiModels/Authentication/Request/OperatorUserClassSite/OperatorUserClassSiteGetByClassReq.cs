using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request.OperatorUserClassSite
{
    [Validator(typeof(OperatorUserClassSiteGetByClassValidator))]
    public class OperatorUserClassSiteGetByClassReq
    {
        public string SITE_ID { get; set; }
        public string OPER_CLASS { get; set; }
    }

    public class OperatorUserClassSiteGetByClassValidator : AbstractValidator<OperatorUserClassSiteGetByClassReq>
    {
        public OperatorUserClassSiteGetByClassValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
        }
    }
}
