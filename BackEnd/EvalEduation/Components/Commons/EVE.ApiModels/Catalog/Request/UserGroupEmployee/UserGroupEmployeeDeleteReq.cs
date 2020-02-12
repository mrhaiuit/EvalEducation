using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupEmployeeDeleteValidator))]
    public class UserGroupEmployeeDeleteReq : UserGroupEmployeeBaseReq
    {
    }

    public class UserGroupEmployeeDeleteValidator : AbstractValidator<UserGroupEmployeeDeleteReq>
    {
        public UserGroupEmployeeDeleteValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
