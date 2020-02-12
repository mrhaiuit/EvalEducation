using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LoginUserDeleteValidator))]
    public class LoginUserDeleteReq : LoginUserBaseReq
    {
    }

    public class LoginUserDeleteValidator : AbstractValidator<LoginUserDeleteReq>
    {
        public LoginUserDeleteValidator()
        {
            RuleFor(c => c.LoginID)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
