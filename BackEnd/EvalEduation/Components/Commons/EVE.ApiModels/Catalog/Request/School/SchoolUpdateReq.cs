using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolUpdateValidator))]
    public class SchoolUpdateReq : SchoolInsertReq
    {
    }

    public class SchoolUpdateValidator : AbstractValidator<SchoolUpdateReq>
    {
        public SchoolUpdateValidator()
        {
            RuleFor(c => c.SchoolId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
