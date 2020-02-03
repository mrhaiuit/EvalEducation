using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkMasterUpdateValidator))]
    public class TrkMasterUpdateReq : TrkMasterInsertReq
    {
    }

    public class TrkMasterUpdateValidator : AbstractValidator<TrkMasterUpdateReq>
    {
        public TrkMasterUpdateValidator()
        {
            RuleFor(c => c.TRK_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TrkIdIsNullOrEmpty).ToString());
        }
    }
}
