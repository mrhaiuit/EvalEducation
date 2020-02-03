using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(YardAreaDeleteValidator))]
    public class YardAreaDeleteReq : YardAreaBaseReq
    {
    }

    public class YardAreaDeleteValidator : AbstractValidator<YardAreaDeleteReq>
    {
        public YardAreaDeleteValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.AREA)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.AreaIsNullOrEmpty).ToString());
            RuleFor(c => c.STACK)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.StackIsNullOrEmpty).ToString());
        }
    }
}
