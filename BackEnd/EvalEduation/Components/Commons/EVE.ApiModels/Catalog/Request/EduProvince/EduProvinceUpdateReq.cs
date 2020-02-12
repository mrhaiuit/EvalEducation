using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduProvinceUpdateValidator))]
    public class EduProvinceUpdateReq : EduProvinceInsertReq
    {
    }

    public class EduProvinceUpdateValidator : AbstractValidator<EduProvinceUpdateReq>
    {
        public EduProvinceUpdateValidator()
        {
            RuleFor(c => c.EduProvinceId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
