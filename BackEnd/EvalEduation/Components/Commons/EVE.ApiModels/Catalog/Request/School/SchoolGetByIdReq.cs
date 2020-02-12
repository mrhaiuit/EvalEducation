using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SchoolGetByIdValidator))]
    public class SchoolGetByIdReq : SchoolBaseReq
    {
        
    }

    public class SchoolGetByIdValidator : AbstractValidator<SchoolGetByIdReq>
    {
        public SchoolGetByIdValidator()
        {
            RuleFor(c => c.SchoolId)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
