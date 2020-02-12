using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalPeriodUpdateValidator))]
    public class EvalPeriodUpdateReq : EvalPeriodInsertReq
    {
    }

    public class EvalPeriodUpdateValidator : AbstractValidator<EvalPeriodUpdateReq>
    {
        public EvalPeriodUpdateValidator()
        {
            RuleFor(c => c.EvalPeriodId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
