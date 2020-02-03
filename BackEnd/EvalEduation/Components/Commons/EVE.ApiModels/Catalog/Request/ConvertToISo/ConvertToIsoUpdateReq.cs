using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(ConvertToIsoUpdateValidator))]
    public class ConvertToIsoUpdateReq : ConvertToIsoInsertReq
    {
    }

    public class ConvertToIsoUpdateValidator : AbstractValidator<ConvertToIsoUpdateReq>
    {
        public ConvertToIsoUpdateValidator()
        {
            RuleFor(c => c.ISO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
