using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolLevelUpdateValidator))]
    public class SchoolLevelUpdateReq : SchoolLevelInsertReq
    {
    }

    public class SchoolLevelUpdateValidator : AbstractValidator<SchoolLevelUpdateReq>
    {
        public SchoolLevelUpdateValidator()
        {
            RuleFor(c => c.SchoolLevelCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
