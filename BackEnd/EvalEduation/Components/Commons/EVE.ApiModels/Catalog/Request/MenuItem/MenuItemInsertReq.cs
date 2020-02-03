using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuItemInsertValidator))]
    public class MenuItemInsertReq : MenuItemBaseReq
    {
        public string MENU_ITEM_NAME { get; set; }

        public string DESCR { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }
    }

    public class MenuItemInsertValidator : AbstractValidator<MenuItemInsertReq>
    {
        public MenuItemInsertValidator()
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
