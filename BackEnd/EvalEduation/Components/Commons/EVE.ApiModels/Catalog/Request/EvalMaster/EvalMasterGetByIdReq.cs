using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalMasterGetByIdValidator))]
    public class EvalMasterGetByIdReq : EvalMasterBaseReq
    {
        
    }

    public class EvalMasterGetByIdValidator : AbstractValidator<EvalMasterGetByIdReq>
    {
        public EvalMasterGetByIdValidator()
        {
            RuleFor(c => c.EvalMasterId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
