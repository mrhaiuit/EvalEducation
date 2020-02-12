using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(UserGroupEmployeeInsertValidator))]
    public class UserGroupEmployeeInsertReq : UserGroupEmployeeBaseReq
    {
        public string EduMinistryCode { get; set; }
        public Nullable<int> EduProvinceId { get; set; }
        public Nullable<int> EduDepartmentId { get; set; }
        public Nullable<int> SchoolId { get; set; }
    }

    public class UserGroupEmployeeInsertValidator : AbstractValidator<UserGroupEmployeeInsertReq>
    {
        public UserGroupEmployeeInsertValidator()
        {
            RuleFor(c => c.UserGroupCode)
                    .NotNull()
                    .NotEmpty();
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<UserGroupEmployeeInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
