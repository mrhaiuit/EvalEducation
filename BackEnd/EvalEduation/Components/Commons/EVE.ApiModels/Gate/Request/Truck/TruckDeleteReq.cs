using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TruckDeleteValidator))]
    public class TruckDeleteReq : TruckBaseReq
    {
    }

    public class TruckDeleteValidator : AbstractValidator<TruckDeleteReq>
    {
        public TruckDeleteValidator()
        {
            RuleFor(c => c.TRK_KEY)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TruckKeyIsNullOrEmpty).ToString());
        }
    }
}
