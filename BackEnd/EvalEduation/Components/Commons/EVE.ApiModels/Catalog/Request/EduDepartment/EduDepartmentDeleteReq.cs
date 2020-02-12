using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduDepartmentDeleteValidator))]
    public class EduDepartmentDeleteReq : EduDepartmentBaseReq
    {
    }

    public class EduDepartmentDeleteValidator : AbstractValidator<EduDepartmentDeleteReq>
    {
        public EduDepartmentDeleteValidator()
        {
            RuleFor(c => c.EduDepartmentId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
