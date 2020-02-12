using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStateInsertValidator))]
    public class EvalStateInsertReq : EvalStateBaseReq
    {
        public string EvalStateName { get; set; }
        public Nullable<int> Idx { get; set; }
    }

    public class EvalStateInsertValidator : AbstractValidator<EvalStateInsertReq>
    {
        public EvalStateInsertValidator()
        {
            RuleFor(c => c.EvalStateCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
