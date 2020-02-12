using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalMasterDeleteValidator))]
    public class EvalMasterDeleteReq : EvalMasterBaseReq
    {
    }

    public class EvalMasterDeleteValidator : AbstractValidator<EvalMasterDeleteReq>
    {
        public EvalMasterDeleteValidator()
        {
            RuleFor(c => c.EvalMasterId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
