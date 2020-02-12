using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupGetByIdValidator))]
    public class UserGroupGetByIdReq : UserGroupBaseReq
    {
        
    }

    public class UserGroupGetByIdValidator : AbstractValidator<UserGroupGetByIdReq>
    {
        public UserGroupGetByIdValidator()
        {
            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
