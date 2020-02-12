using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolLevelDeleteValidator))]
    public class SchoolLevelDeleteReq : SchoolLevelBaseReq
    {
    }

    public class SchoolLevelDeleteValidator : AbstractValidator<SchoolLevelDeleteReq>
    {
        public SchoolLevelDeleteValidator()
        {
            RuleFor(c => c.SchoolLevelCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
