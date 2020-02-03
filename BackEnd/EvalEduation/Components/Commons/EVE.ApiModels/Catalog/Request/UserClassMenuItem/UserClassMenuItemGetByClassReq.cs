using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserClassMenuItemGetByClassValidator))]
    public class UserClassMenuItemGetByClassReq 
    {
        public string USER_CLASS { get; set; }
    }

    public class UserClassMenuItemGetByClassValidator : AbstractValidator<UserClassMenuItemGetByClassReq>
    {
        public UserClassMenuItemGetByClassValidator()
        {
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UserClassIsNullOrEmpty).ToString());
        }
    }
}
