using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LoginUserUpdateValidator))]
    public class LoginUserUpdateReq : LoginUserInsertReq
    {
    }

    public class LoginUserUpdateValidator : AbstractValidator<LoginUserUpdateReq>
    {
        public LoginUserUpdateValidator()
        {
            RuleFor(c => c.LoginID)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
