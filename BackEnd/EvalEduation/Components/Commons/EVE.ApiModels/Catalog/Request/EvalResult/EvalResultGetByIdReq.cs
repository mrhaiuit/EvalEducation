using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalResultGetByIdValidator))]
    public class EvalResultGetByIdReq : EvalResultBaseReq
    {
    }

    public class EvalResultGetByIdValidator : AbstractValidator<EvalResultGetByIdReq>
    {
        public EvalResultGetByIdValidator()
        {
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
