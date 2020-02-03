using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(GetFormsPermissionByClassReqValidator))]
    public class GetFormsPermissionByClassReq : UserClassMenuItemGetByClassReq
    {
    }

    public class GetFormsPermissionByClassReqValidator : AbstractValidator<GetFormsPermissionByClassReq>
    {
        public GetFormsPermissionByClassReqValidator()
        {
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
        }
    }
}
