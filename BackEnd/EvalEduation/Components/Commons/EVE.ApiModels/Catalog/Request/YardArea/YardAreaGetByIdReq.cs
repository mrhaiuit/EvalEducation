using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(YardAreaGetByIdValidator))]
    public class YardAreaGetByIdReq : YardAreaBaseReq
    {
        
    }

    public class YardAreaGetByIdValidator : AbstractValidator<YardAreaGetByIdReq>
    {
        public YardAreaGetByIdValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.AREA)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.AreaIsNullOrEmpty).ToString());
            RuleFor(c => c.STACK)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.StackIsNullOrEmpty).ToString());
        }

        public override ValidationResult Validate(ValidationContext<YardAreaGetByIdReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
