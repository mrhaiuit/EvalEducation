using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalResultUpdateValidator))]
    public class EvalResultUpdateReq : EvalResultInsertReq
    {
    }

    public class EvalResultUpdateValidator : AbstractValidator<EvalResultUpdateReq>
    {
        public EvalResultUpdateValidator()
        {
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
