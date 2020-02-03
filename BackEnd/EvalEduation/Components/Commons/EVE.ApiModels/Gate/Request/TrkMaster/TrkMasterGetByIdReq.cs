using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkMasterGetByIdValidator))]
    public class TrkMasterGetByIdReq : TrkMasterBaseReq
    {
    }

    public class TrkMasterGetByIdValidator : AbstractValidator<TrkMasterGetByIdReq>
    {
        public TrkMasterGetByIdValidator()
        {
            RuleFor(c => c.TRK_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TrkIdIsNullOrEmpty).ToString());
        }
    }
}
