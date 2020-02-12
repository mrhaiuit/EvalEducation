using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStandardGetByIdValidator))]
    public class EvalStandardGetByIdReq : EvalStandardBaseReq
    {

    }

    public class EvalStandardGetByIdValidator : AbstractValidator<EvalStandardGetByIdReq>
    {
        public EvalStandardGetByIdValidator()
        {
            RuleFor(c => c.EvalStandardId)
                    .NotNull()
                    .NotEmpty();
        }

    }
}
