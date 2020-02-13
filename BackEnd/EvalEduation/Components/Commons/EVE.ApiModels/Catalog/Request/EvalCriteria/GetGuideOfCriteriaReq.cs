using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(GetGuideOfCriteriaValidator))]
    public class GetGuideOfCriteriaReq 
    {
        public string EvalResultCode { get; set; }
        public int EvalCriteriaId { get; set; }
    }

    public class GetGuideOfCriteriaValidator : AbstractValidator<GetGuideOfCriteriaReq>
    {
        public GetGuideOfCriteriaValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
