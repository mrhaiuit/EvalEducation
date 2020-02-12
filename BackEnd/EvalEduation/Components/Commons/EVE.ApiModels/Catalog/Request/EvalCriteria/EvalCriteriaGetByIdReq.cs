using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalCriteriaGetByIdValidator))]
    public class EvalCriteriaGetByIdReq : EvalCriteriaBaseReq
    {
    }

    public class EvalCriteriaGetByIdValidator : AbstractValidator<EvalCriteriaGetByIdReq>
    {
        public EvalCriteriaGetByIdValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
