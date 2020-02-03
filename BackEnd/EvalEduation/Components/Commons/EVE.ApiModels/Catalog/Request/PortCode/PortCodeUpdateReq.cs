using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(PortCodeUpdateValidator))]
    public class PortCodeUpdateReq : PortCodeInsertReq
    {
    }

    public class PortCodeUpdateValidator : AbstractValidator<PortCodeUpdateReq>
    {
        public PortCodeUpdateValidator()
        {
            RuleFor(c => c.PORT)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.PortIsNullOrEmpty).ToString());
        }
    }
}
