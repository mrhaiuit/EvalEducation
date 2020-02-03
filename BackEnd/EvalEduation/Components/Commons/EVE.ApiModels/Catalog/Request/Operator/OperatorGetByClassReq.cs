using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorGetByClassValidator))]
    public class OperatorGetByClassReq 
    {
        public string SITE_ID { get; set; }
        public string USER_CLASS { get; set; }

    }

    public class OperatorGetByClassValidator : AbstractValidator<OperatorGetByClassReq>
    {
        public OperatorGetByClassValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
            RuleFor(c => c.USER_CLASS)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }

    }
}
