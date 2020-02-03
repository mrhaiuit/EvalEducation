using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkMasterDeleteValidator))]
    public class TrkMasterDeleteReq : TrkMasterBaseReq
    {
    }

    public class TrkMasterDeleteValidator : AbstractValidator<TrkMasterDeleteReq>
    {
        public TrkMasterDeleteValidator()
        {
            RuleFor(c => c.TRK_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TrkIdHasExist).ToString());
        }
    }
}
