using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalGuideGetByIdValidator))]
    public class EvalGuideGetByIdReq : EvalGuideBaseReq
    {

    }

    public class EvalGuideGetByIdValidator : AbstractValidator<EvalGuideGetByIdReq>
    {
        public EvalGuideGetByIdValidator()
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
