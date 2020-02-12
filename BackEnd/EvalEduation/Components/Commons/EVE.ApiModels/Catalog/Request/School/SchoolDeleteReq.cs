using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolDeleteValidator))]
    public class SchoolDeleteReq : SchoolBaseReq
    {
    }

    public class SchoolDeleteValidator : AbstractValidator<SchoolDeleteReq>
    {
        public SchoolDeleteValidator()
        {
            RuleFor(c => c.SchoolId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
