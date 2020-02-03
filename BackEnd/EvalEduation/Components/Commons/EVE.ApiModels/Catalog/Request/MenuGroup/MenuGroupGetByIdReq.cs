using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuGroupGetByIdValidator))]
    public class MenuGroupGetByIdReq : MenuGroupBaseReq
    {

    }

    public class MenuGroupGetByIdValidator : AbstractValidator<MenuGroupGetByIdReq>
    {
        public MenuGroupGetByIdValidator()
        {
            RuleFor(c => c.MENU_MODULE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.MenuModuleIsNullOrEmpty).ToString());
            RuleFor(c => c.GROUP_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.GroupCodeIsNullOrEmpty).ToString());
        }
    }
}
