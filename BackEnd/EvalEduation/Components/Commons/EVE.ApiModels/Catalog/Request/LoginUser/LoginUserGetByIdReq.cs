using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LoginUserGetByIdValidator))]
    public class LoginUserGetByIdReq : LoginUserBaseReq
    {
        
    }

    public class LoginUserGetByIdValidator : AbstractValidator<LoginUserGetByIdReq>
    {
        public LoginUserGetByIdValidator()
        {
            RuleFor(c => c.LoginID)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
