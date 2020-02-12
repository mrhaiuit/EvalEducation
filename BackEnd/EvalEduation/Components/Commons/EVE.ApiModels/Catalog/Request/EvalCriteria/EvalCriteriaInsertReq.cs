using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalCriteriaInsertValidator))]
    public class EvalCriteriaInsertReq : EvalCriteriaBaseReq
    {
        public Nullable<int> EvalStandardId { get; set; }
        public string EvalCriteriaName { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Idx { get; set; }
    }

    public class EvalCriteriaInsertValidator : AbstractValidator<EvalCriteriaInsertReq>
    {
        public EvalCriteriaInsertValidator()
        {
            RuleFor(c => c.EvalCriteriaId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
