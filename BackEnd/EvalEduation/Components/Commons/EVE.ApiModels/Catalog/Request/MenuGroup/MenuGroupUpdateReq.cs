using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuGroupUpdateValidator))]
    public class MenuGroupUpdateReq : MenuGroupInsertReq
    {
    }

    public class MenuGroupUpdateValidator : AbstractValidator<MenuGroupUpdateReq>
    {
        public MenuGroupUpdateValidator()
        {
            RuleFor(c => c.MENU_MODULE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.MenuModuleIsNullOrEmpty).ToString());
            RuleFor(c => c.GROUP_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.GroupCodeIsNullOrEmpty).ToString());
        }
    }
}
