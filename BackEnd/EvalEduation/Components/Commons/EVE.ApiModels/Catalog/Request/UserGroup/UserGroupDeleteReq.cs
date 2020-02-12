using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupDeleteValidator))]
    public class UserGroupDeleteReq : UserGroupBaseReq
    {
    }

    public class UserGroupDeleteValidator : AbstractValidator<UserGroupDeleteReq>
    {
        public UserGroupDeleteValidator()
        {
            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
