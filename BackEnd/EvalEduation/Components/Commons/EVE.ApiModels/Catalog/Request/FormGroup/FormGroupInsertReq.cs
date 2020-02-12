using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormGroupInsertValidator))]
    public class FormGroupInsertReq : FormGroupBaseReq
    {
        public string GroupName { get; set; }
        public Nullable<int> Idx { get; set; }
    }

    public class FormGroupInsertValidator : AbstractValidator<FormGroupInsertReq>
    {
        public FormGroupInsertValidator()
        {
            RuleFor(c => c.GroupCode)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<FormGroupInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
