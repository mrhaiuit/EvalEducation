using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalGuideUpdateValidator))]
    public class EvalGuideUpdateReq : EvalGuideInsertReq
    {
    }

    public class EvalGuideUpdateValidator : AbstractValidator<EvalGuideUpdateReq>
    {
        public EvalGuideUpdateValidator()
        {
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
