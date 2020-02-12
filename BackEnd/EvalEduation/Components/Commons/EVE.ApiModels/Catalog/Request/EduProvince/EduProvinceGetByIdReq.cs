using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduProvinceGetByIdValidator))]
    public class EduProvinceGetByIdReq : EduProvinceBaseReq
    {
    }

    public class EduProvinceGetByIdValidator : AbstractValidator<EduProvinceGetByIdReq>
    {
        public EduProvinceGetByIdValidator()
        {
            RuleFor(c => c.EduProvinceId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
