using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Vessel
{
    [Validator(typeof(VesselsDeleteValidator))]
    public class VesselsDeleteReq : VesselsBaseReq
    {
    }

    public class VesselsDeleteValidator : AbstractValidator<VesselsDeleteReq>
    {
        public VesselsDeleteValidator()
        {
            RuleFor(c => c.VES_CD)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.VesCdIsNullOrEmpty).ToString());
        }
    }
}
