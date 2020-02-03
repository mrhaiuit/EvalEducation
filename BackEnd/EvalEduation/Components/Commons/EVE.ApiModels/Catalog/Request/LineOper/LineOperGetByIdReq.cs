using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LineOperGetByIdValidator))]
    public class LineOperGetByIdReq : LineOperBaseReq
    {
    }

    public class LineOperGetByIdValidator : AbstractValidator<LineOperGetByIdReq>
    {
        public LineOperGetByIdValidator()
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
