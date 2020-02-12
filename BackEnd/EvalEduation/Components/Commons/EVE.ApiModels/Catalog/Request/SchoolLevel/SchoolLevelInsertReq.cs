using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolLevelInsertValidator))]
    public class SchoolLevelInsertReq : SchoolLevelBaseReq
    {

        public string SchoolLevelName { get; set; }
    }

    public class SchoolLevelInsertValidator : AbstractValidator<SchoolLevelInsertReq>
    {
        public SchoolLevelInsertValidator()
        {
            RuleFor(c => c.SchoolLevelCode)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<SchoolLevelInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
