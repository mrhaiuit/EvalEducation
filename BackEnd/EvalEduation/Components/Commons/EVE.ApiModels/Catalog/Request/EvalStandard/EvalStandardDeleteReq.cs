using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStandardDeleteValidator))]
    public class EvalStandardDeleteReq : EvalStandardBaseReq
    {
    }

    public class EvalStandardDeleteValidator : AbstractValidator<EvalStandardDeleteReq>
    {
        public EvalStandardDeleteValidator()
        {
            RuleFor(c => c.EvalStandardId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
