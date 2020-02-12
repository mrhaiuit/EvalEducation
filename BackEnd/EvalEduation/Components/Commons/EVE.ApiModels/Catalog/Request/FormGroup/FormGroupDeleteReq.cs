using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormGroupDeleteValidator))]
    public class FormGroupDeleteReq : FormGroupBaseReq
    {
    }

    public class FormGroupDeleteValidator : AbstractValidator<FormGroupDeleteReq>
    {
        public FormGroupDeleteValidator()
        {
            RuleFor(c => c.GroupCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
