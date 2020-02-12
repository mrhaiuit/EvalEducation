using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalPeriodDeleteValidator))]
    public class EvalPeriodDeleteReq : EvalPeriodBaseReq
    {
    }

    public class EvalPeriodDeleteValidator : AbstractValidator<EvalPeriodDeleteReq>
    {
        public EvalPeriodDeleteValidator()
        {
            RuleFor(c => c.EvalPeriodId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
