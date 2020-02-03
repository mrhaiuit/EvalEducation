using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Vessel
{
    [Validator(typeof(VesselsUpdateValidator))]
    public class VesselsUpdateReq : VesselsInsertReq
    {
    }

    public class VesselsUpdateValidator : AbstractValidator<VesselsUpdateReq>
    {
        public VesselsUpdateValidator()
        {
            RuleFor(c => c.VES_CD)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.VesCdIsNullOrEmpty).ToString());
        }
    }
}
