using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormsInsertValidator))]
    public class FormsInsertReq : FormsBaseReq
    {
        public string GroupName { get; set; }
        public Nullable<int> Idx { get; set; }
    }

    public class FormsInsertValidator : AbstractValidator<FormsInsertReq>
    {
        public FormsInsertValidator()
        {
            RuleFor(c => c.FormCode)
                    .NotNull()
                    .NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<FormsInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
