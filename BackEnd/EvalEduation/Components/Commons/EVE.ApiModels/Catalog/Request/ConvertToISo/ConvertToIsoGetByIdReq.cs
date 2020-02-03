using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(ConvertToIsoGetByIdValidator))]
    public class ConvertToIsoGetByIdReq : ConvertToIsoBaseReq
    {
    }

    public class ConvertToIsoGetByIdValidator : AbstractValidator<ConvertToIsoGetByIdReq>
    {
        public ConvertToIsoGetByIdValidator()
        {
            RuleFor(c => c.ISO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
