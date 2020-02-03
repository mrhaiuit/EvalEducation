using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(DepotDeleteValidator))]
    public class DepotDeleteReq : DepotBaseReq
    {
    }

    public class DepotDeleteValidator : AbstractValidator<DepotDeleteReq>
    {
        public DepotDeleteValidator()
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
