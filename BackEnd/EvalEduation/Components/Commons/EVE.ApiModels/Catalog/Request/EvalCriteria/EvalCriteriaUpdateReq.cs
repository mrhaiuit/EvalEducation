using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalCriteriaUpdateValidator))]
    public class EvalCriteriaUpdateReq : EvalCriteriaInsertReq
    {
    }

    public class EvalCriteriaUpdateValidator : AbstractValidator<EvalCriteriaUpdateReq>
    {
        public EvalCriteriaUpdateValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
