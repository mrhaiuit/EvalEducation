using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormGroupGetByIdValidator))]
    public class FormGroupGetByIdReq : FormGroupBaseReq
    {
        
    }

    public class FormGroupGetByIdValidator : AbstractValidator<FormGroupGetByIdReq>
    {
        public FormGroupGetByIdValidator()
        {
            RuleFor(c => c.GroupCode)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
