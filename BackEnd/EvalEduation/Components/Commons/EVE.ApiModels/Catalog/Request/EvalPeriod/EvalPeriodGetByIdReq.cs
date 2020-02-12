using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalPeriodGetByIdValidator))]
    public class EvalPeriodGetByIdReq : EvalPeriodBaseReq
    {

    }

    public class EvalPeriodGetByIdValidator : AbstractValidator<EvalPeriodGetByIdReq>
    {
        public EvalPeriodGetByIdValidator()
        {
            RuleFor(c => c.EvalPeriodId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
