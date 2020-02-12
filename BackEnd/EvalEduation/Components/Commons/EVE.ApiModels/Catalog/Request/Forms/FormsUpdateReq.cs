using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(FormsUpdateValidator))]
    public class FormsUpdateReq : FormsInsertReq
    {
    }

    public class FormsUpdateValidator : AbstractValidator<FormsUpdateReq>
    {
        public FormsUpdateValidator()
        {
            RuleFor(c => c.FormCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
