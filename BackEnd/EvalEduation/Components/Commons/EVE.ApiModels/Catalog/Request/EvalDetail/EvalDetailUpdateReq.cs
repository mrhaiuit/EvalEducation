using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalDetailUpdateValidator))]
    public class EvalDetailUpdateReq : EvalDetailInsertReq
    {
    }

    public class EvalDetailUpdateValidator : AbstractValidator<EvalDetailUpdateReq>
    {
        public EvalDetailUpdateValidator()
        {
            RuleFor(c => c.EvalDetailId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
