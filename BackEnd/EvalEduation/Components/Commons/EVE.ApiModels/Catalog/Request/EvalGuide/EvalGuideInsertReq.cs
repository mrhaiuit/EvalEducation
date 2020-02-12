using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalGuideInsertValidator))]
    public class EvalGuideInsertReq : EvalGuideBaseReq
    {
        public string Description { get; set; }
        public string Sample { get; set; }
    }

    public class EvalGuideInsertValidator : AbstractValidator<EvalGuideInsertReq>
    {
        public EvalGuideInsertValidator()
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
