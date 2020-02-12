using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalResultDeleteValidator))]
    public class EvalResultDeleteReq : EvalResultBaseReq
    {
    }

    public class EvalResultDeleteValidator : AbstractValidator<EvalResultDeleteReq>
    {
        public EvalResultDeleteValidator()
        {
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
