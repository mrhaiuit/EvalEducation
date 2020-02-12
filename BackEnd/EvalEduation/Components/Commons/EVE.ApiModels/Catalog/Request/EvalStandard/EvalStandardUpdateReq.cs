using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStandardUpdateValidator))]
    public class EvalStandardUpdateReq : EvalStandardInsertReq
    {
    }

    public class EvalStandardUpdateValidator : AbstractValidator<EvalStandardUpdateReq>
    {
        public EvalStandardUpdateValidator()
        {
            RuleFor(c => c.EvalStandardId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
