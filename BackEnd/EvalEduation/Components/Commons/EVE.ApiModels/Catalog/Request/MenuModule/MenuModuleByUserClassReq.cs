using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleByUserClassReqValidator))]
    public class MenuModuleByUserClassReq
    {
        public string USER_CLASS { get; set; }
    }

    public class MenuModuleByUserClassReqValidator : AbstractValidator<MenuModuleByUserClassReq>
    {
        public MenuModuleByUserClassReqValidator()
        {
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());
        }
    }
}
