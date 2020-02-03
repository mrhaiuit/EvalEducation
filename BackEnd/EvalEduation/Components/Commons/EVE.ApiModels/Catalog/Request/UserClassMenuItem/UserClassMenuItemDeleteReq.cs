using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserClassMenuItemDeleteValidator))]
    public class UserClassMenuItemDeleteReq : UserClassMenuItemBaseReq
    {
    }

    public class UserClassMenuItemDeleteValidator : AbstractValidator<UserClassMenuItemDeleteReq>
    {
        public UserClassMenuItemDeleteValidator()
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
