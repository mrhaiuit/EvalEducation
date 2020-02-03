using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(DepotGetByIdValidator))]
    public class DepotGetByIdReq : DepotBaseReq
    {
    }

    public class DepotGetByIdValidator : AbstractValidator<DepotGetByIdReq>
    {
        public DepotGetByIdValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.DEPOT1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.DepotIsNullOrEmpty).ToString());
        }
    }
}
