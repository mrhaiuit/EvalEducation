using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TruckGetByIdValidator))]
    public class TruckGetByIdReq : TruckBaseReq
    {
    }

    public class TruckGetByIdValidator : AbstractValidator<TruckGetByIdReq>
    {
        public TruckGetByIdValidator()
        {
            RuleFor(c => c.TRK_KEY)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.TruckKeyIsNullOrEmpty).ToString());
        }
    }
}
