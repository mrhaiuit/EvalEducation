using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormsGetByIdValidator))]
    public class FormsGetByIdReq : FormsBaseReq
    {
        
    }

    public class FormsGetByIdValidator : AbstractValidator<FormsGetByIdReq>
    {
        public FormsGetByIdValidator()
        {
            RuleFor(c => c.FormCode)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
