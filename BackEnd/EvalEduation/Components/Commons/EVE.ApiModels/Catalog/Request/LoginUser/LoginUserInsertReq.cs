using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LoginUserInsertValidator))]
    public class LoginUserInsertReq : LoginUserBaseReq
    {
        public string IpAddress { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public System.DateTime LoginDate { get; set; }
        public string UserId { get; set; }
        public string Version { get; set; }
        public string UserGroup { get; set; }
        public System.DateTime CrtTs { get; set; }
        public System.DateTime UpdTs { get; set; }
        public string Remarks { get; set; }
    }

    public class LoginUserInsertValidator : AbstractValidator<LoginUserInsertReq>
    {
        public LoginUserInsertValidator()
        {
            RuleFor(c => c.LoginID)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<LoginUserInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
