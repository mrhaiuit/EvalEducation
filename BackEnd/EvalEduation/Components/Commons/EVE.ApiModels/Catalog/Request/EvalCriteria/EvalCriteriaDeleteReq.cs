using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalCriteriaDeleteValidator))]
    public class EvalCriteriaDeleteReq : EvalCriteriaBaseReq
    {
    }

    public class EvalCriteriaDeleteValidator : AbstractValidator<EvalCriteriaDeleteReq>
    {
        public EvalCriteriaDeleteValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
