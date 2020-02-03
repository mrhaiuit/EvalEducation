#region

using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

#endregion

namespace EVE.ApiModels.Authentication.Request.UserClassFormAction
{
    [Validator(typeof(UserClassFormActionUserClassSiteInsertValidator))]
    public class UserClassFormActionInsertReq : UserClassFormActionBaseReq
    {
    }

    public class UserClassFormActionUserClassSiteInsertValidator : AbstractValidator<UserClassFormActionInsertReq>
    {
        public UserClassFormActionUserClassSiteInsertValidator()
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