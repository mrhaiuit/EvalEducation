using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserClassMenuItemGetByIdValidator))]
    public class UserClassMenuItemGetByIdReq : UserClassMenuItemBaseReq
    {
    }

    public class UserClassMenuItemGetByIdValidator : AbstractValidator<UserClassMenuItemGetByIdReq>
    {
        public UserClassMenuItemGetByIdValidator()
        {
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
            RuleFor(c => c.MENU_ITEM_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.MenuItemCodeIsNullOrEmpty).ToString());
        }
    }
}
