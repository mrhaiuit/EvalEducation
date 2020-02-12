using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolInsertValidator))]
    public class SchoolInsertReq : SchoolBaseReq
    {
        public string School1 { get; set; }
        public string Address { get; set; }
        public Nullable<int> EduDepartmentId { get; set; }
        public Nullable<int> EduProvinceId { get; set; }
        public string SchoolLevelCode { get; set; }
        public string PhoneNumber { get; set; }
        public string HotLine { get; set; }
        public string MinistryofEducationaCode { get; set; }
    }

    public class SchoolInsertValidator : AbstractValidator<SchoolInsertReq>
    {
        public SchoolInsertValidator()
        {
            RuleFor(c => c.SchoolId)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<SchoolInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
