using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupFormDeleteValidator))]
    public class UserGroupFormDeleteReq : UserGroupFormBaseReq
    {
    }

    public class UserGroupFormDeleteValidator : AbstractValidator<UserGroupFormDeleteReq>
    {
        public UserGroupFormDeleteValidator()
        {
            RuleFor(c => c.FormCode)
                    .NotNull()
                    .NotEmpty();
            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
