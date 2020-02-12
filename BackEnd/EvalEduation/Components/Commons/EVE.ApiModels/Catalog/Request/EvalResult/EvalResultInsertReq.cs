using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalResultInsertValidator))]
    public class EvalResultInsertReq : EvalResultBaseReq
    {
        public string EvalResultName { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Idx { get; set; }
    }

    public class EvalResultInsertValidator : AbstractValidator<EvalResultInsertReq>
    {
        public EvalResultInsertValidator()
        {
            RuleFor(c => c.EvalResultCode)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
