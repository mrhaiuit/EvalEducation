using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalGuideDeleteValidator))]
    public class EvalGuideDeleteReq : EvalGuideBaseReq
    {
    }

    public class EvalGuideDeleteValidator : AbstractValidator<EvalGuideDeleteReq>
    {
        public EvalGuideDeleteValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
