using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(PortCodeGetByIdValidator))]
    public class PortCodeGetByIdReq : PortCodeBaseReq
    {
    }

    public class PortCodeGetByIdValidator : AbstractValidator<PortCodeGetByIdReq>
    {
        public PortCodeGetByIdValidator()
        {
            RuleFor(c => c.PORT)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.PortIsNullOrEmpty).ToString());
        }
    }
}
