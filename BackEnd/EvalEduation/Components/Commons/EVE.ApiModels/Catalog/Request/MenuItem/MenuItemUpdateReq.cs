using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuItemUpdateValidator))]
    public class MenuItemUpdateReq : MenuItemInsertReq
    {
    }

    public class MenuItemUpdateValidator : AbstractValidator<MenuItemUpdateReq>
    {
        public MenuItemUpdateValidator()
        {
            RuleFor(c => c.MENU_MODULE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.MenuModuleIsNullOrEmpty).ToString());
            RuleFor(c => c.GROUP_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.GroupCodeIsNullOrEmpty).ToString());
            RuleFor(c => c.MENU_ITEM_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.MenuItemCodeIsNullOrEmpty).ToString());
        }
    }
}
