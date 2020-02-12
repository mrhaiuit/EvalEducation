using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalMasterUpdateValidator))]
    public class EvalMasterUpdateReq : EvalMasterInsertReq
    {
    }

    public class EvalMasterUpdateValidator : AbstractValidator<EvalMasterUpdateReq>
    {
        public EvalMasterUpdateValidator()
        {
            RuleFor(c => c.EvalMasterId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
