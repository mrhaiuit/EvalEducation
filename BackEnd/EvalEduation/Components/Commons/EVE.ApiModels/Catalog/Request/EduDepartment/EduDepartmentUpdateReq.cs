using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduDepartmentUpdateValidator))]
    public class EduDepartmentUpdateReq : EduDepartmentInsertReq
    {
    }

    public class EduDepartmentUpdateValidator : AbstractValidator<EduDepartmentUpdateReq>
    {
        public EduDepartmentUpdateValidator()
        {
            RuleFor(c => c.EduDepartmentId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
