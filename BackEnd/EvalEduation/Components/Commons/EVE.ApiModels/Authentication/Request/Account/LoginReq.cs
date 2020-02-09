using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(LogonValidator))]
    public class LoginReq
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }
    }

    public class LogonValidator : AbstractValidator<LoginReq>
    {
        public LogonValidator()
        {
            RuleFor(c => c.UserName)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());
            RuleFor(c => c.PassWord)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.PasswordIsNullOrEmpty).ToString());
        }
    }
}
