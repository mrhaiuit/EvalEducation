using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStateDeleteValidator))]
    public class EvalStateDeleteReq : EvalStateBaseReq
    {
    }

    public class EvalStateDeleteValidator : AbstractValidator<EvalStateDeleteReq>
    {
        public EvalStateDeleteValidator()
        {
            RuleFor(c => c.EvalStateCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
