using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormsDeleteValidator))]
    public class FormsDeleteReq : FormsBaseReq
    {
    }

    public class FormsDeleteValidator : AbstractValidator<FormsDeleteReq>
    {
        public FormsDeleteValidator()
        {
            RuleFor(c => c.FormCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
