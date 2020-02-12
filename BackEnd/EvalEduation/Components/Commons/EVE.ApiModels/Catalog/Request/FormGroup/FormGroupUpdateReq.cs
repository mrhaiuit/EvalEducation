using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormGroupUpdateValidator))]
    public class FormGroupUpdateReq : FormGroupInsertReq
    {
    }

    public class FormGroupUpdateValidator : AbstractValidator<FormGroupUpdateReq>
    {
        public FormGroupUpdateValidator()
        {
            RuleFor(c => c.GroupCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
