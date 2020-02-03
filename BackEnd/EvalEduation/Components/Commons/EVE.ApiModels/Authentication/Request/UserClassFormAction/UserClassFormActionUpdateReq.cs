#region

using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

#endregion

namespace EVE.ApiModels.Authentication.Request.UserClassFormAction
{
    [Validator(typeof(UserClassFormActionUpdateValidator))]
    public class UserClassFormActionUpdateReq : UserClassFormActionInsertReq
    {
    }

    public class UserClassFormActionUpdateValidator : AbstractValidator<UserClassFormActionUpdateReq>
    {
        public UserClassFormActionUpdateValidator()
        {
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
            RuleFor(c => c.MENU_ITEM_ACTION_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.MenuItemActionCodeIsNullOrEmpty).ToString());
        }
    }
}
