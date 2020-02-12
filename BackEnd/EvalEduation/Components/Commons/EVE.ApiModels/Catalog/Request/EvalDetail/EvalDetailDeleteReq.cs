using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalDetailDeleteValidator))]
    public class EvalDetailDeleteReq : EvalDetailBaseReq
    {
    }

    public class EvalDetailDeleteValidator : AbstractValidator<EvalDetailDeleteReq>
    {
        public EvalDetailDeleteValidator()
        {
            RuleFor(c => c.EvalDetailId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
