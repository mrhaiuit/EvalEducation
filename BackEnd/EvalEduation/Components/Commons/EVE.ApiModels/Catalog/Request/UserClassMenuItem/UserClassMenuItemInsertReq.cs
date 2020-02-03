using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserClassMenuItemInsertValidator))]
    public class UserClassMenuItemInsertReq : UserClassMenuItemBaseReq
    {
    }

    public class UserClassMenuItemInsertValidator : AbstractValidator<UserClassMenuItemInsertReq>
    {
        public UserClassMenuItemInsertValidator()
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