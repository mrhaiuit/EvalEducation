using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(PregateTransactUpdateValidator))]
    public class PregateTransactUpdateReq : PregateTransactInsertReq
    {
    }

    public class PregateTransactUpdateValidator : AbstractValidator<PregateTransactUpdateReq>
    {
        public PregateTransactUpdateValidator()
        {
            RuleFor(c => c.EIR_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.EirIdIsNullOrEmpty).ToString());
        }
    }
}
