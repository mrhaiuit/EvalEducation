using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Vessel
{
    [Validator(typeof(VesselsGetByIdValidator))]
    public class VesselsGetByIdReq : VesselsBaseReq
    {
    }

    public class VesselsGetByIdValidator : AbstractValidator<VesselsGetByIdReq>
    {
        public VesselsGetByIdValidator()
        {
            RuleFor(c => c.VES_CD)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.VesCdIsNullOrEmpty).ToString());
        }
    }
}
