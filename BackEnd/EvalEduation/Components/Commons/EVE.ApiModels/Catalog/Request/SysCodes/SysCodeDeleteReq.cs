using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SysCodeDeleteValidator))]
    public class SysCodeDeleteReq : SysCodeBaseReq
    {
    }

    public class SysCodeDeleteValidator : AbstractValidator<SysCodeDeleteReq>
    {
        public SysCodeDeleteValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.CODE_TP)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CodeTpIsNullOrEmpty).ToString());
            RuleFor(c => c.CODE_REF)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CodeRefIsNullOrEmpty).ToString());
        }
    }
}
