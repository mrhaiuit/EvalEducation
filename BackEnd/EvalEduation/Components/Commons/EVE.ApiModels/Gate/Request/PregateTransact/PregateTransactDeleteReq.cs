using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(PregateTransactDeleteValidator))]
    public class PregateTransactDeleteReq : PregateTransactBaseReq
    {
    }

    public class PregateTransactDeleteValidator : AbstractValidator<PregateTransactDeleteReq>
    {
        public PregateTransactDeleteValidator()
        {
            RuleFor(c => c.EIR_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.EirIdIsNullOrEmpty).ToString());
        }
    }
}
