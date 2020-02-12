using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolLevelGetByIdValidator))]
    public class SchoolLevelGetByIdReq : SchoolLevelBaseReq
    {
        
    }

    public class SchoolLevelGetByIdValidator : AbstractValidator<SchoolLevelGetByIdReq>
    {
        public SchoolLevelGetByIdValidator()
        {
            RuleFor(c => c.SchoolLevelCode)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
