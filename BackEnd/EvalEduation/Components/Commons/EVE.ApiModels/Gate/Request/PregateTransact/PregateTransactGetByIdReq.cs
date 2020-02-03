using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(PregateTransactGetByIdValidator))]
    public class PregateTransactGetByIdReq : PregateTransactBaseReq
    {
    }

    public class PregateTransactGetByIdValidator : AbstractValidator<PregateTransactGetByIdReq>
    {
        public PregateTransactGetByIdValidator()
        {
            RuleFor(c => c.EIR_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.EirIdIsNullOrEmpty).ToString());
        }
    }
}
