using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TruckUpdateValidator))]
    public class TruckUpdateReq : TruckInsertReq
    {
    }

    public class TruckUpdateValidator : AbstractValidator<TruckUpdateReq>
    {
        public TruckUpdateValidator()
        {
            RuleFor(c => c.TRK_KEY)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TruckKeyIsNullOrEmpty).ToString());
        }
    }
}
