using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduDepartmentGetByIdValidator))]
    public class EduDepartmentGetByIdReq : EduDepartmentBaseReq
    {
    }

    public class EduDepartmentGetByIdValidator : AbstractValidator<EduDepartmentGetByIdReq>
    {
        public EduDepartmentGetByIdValidator()
        {
            RuleFor(c => c.EduDepartmentId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
