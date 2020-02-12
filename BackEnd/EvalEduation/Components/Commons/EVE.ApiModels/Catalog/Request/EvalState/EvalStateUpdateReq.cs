using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStateUpdateValidator))]
    public class EvalStateUpdateReq : EvalStateInsertReq
    {
    }

    public class EvalStateUpdateValidator : AbstractValidator<EvalStateUpdateReq>
    {
        public EvalStateUpdateValidator()
        {
            RuleFor(c => c.EvalStateCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
