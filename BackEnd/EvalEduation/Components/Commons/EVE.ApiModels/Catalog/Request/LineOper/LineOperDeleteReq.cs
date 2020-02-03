using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LineOperDeleteValidator))]
    public class LineOperDeleteReq : LineOperBaseReq
    {
    }

    public class LineOperDeleteValidator : AbstractValidator<LineOperDeleteReq>
    {
        public LineOperDeleteValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.LINE_OPER1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.LineOperIsNullOrEmpty).ToString());
        }
    }
}
