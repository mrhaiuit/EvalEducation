using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuItemGetByIdValidator))]
    public class MenuItemGetByIdReq : MenuItemBaseReq
    {
        
    }

    public class MenuItemGetByIdValidator : AbstractValidator<MenuItemGetByIdReq>
    {
        public MenuItemGetByIdValidator()
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
