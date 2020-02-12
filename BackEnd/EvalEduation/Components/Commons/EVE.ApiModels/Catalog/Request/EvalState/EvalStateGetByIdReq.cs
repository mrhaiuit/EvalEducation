using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStateGetByIdValidator))]
    public class EvalStateGetByIdReq : EvalStateBaseReq
    {
    }

    public class EvalStateGetByIdValidator : AbstractValidator<EvalStateGetByIdReq>
    {
        public EvalStateGetByIdValidator()
        {
            RuleFor(c => c.EvalStateCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
