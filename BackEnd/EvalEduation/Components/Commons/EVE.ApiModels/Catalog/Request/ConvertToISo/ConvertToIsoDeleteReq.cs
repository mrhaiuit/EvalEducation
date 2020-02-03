using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(ConvertToIsoDeleteValidator))]
    public class ConvertToIsoDeleteReq : ConvertToIsoBaseReq
    {
    }

    public class ConvertToIsoDeleteValidator : AbstractValidator<ConvertToIsoDeleteReq>
    {
        public ConvertToIsoDeleteValidator()
        {
            RuleFor(c => c.ISO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
