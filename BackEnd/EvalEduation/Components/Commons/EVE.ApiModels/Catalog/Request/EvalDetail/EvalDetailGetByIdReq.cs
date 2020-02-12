using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalDetailGetByIdValidator))]
    public class EvalDetailGetByIdReq : EvalDetailBaseReq
    {
    }

    public class EvalDetailGetByIdValidator : AbstractValidator<EvalDetailGetByIdReq>
    {
        public EvalDetailGetByIdValidator()
        {
            RuleFor(c => c.EvalDetailId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
