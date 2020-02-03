using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(PortCodeDeleteValidator))]
    public class PortCodeDeleteReq : PortCodeBaseReq
    {
    }

    public class PortCodeDeleteValidator : AbstractValidator<PortCodeDeleteReq>
    {
        public PortCodeDeleteValidator()
        {
            RuleFor(c => c.PORT)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.PortIsNullOrEmpty).ToString());
        }
    }
}
