using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupInsertValidator))]
    public class UserGroupInsertReq : UserGroupBaseReq
    {
        public string UserGroupName { get; set; }
        public Nullable<int> Idx { get; set; }
        public string EduLevelCode { get; set; }
    }

    public class UserGroupInsertValidator : AbstractValidator<UserGroupInsertReq>
    {
        public UserGroupInsertValidator()
        {
            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<UserGroupInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
