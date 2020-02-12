using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduProvinceDeleteValidator))]
    public class EduProvinceDeleteReq : EduProvinceBaseReq
    {
    }

    public class EduProvinceDeleteValidator : AbstractValidator<EduProvinceDeleteReq>
    {
        public EduProvinceDeleteValidator()
        {
            RuleFor(c => c.EduProvinceId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
