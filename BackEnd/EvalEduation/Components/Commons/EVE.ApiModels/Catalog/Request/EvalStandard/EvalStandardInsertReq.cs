using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalStandardInsertValidator))]
    public class EvalStandardInsertReq : EvalStandardBaseReq
    {
        public string EvalStandardName { get; set; }
        public string SchoolLevelCode { get; set; }
        public string EvalTypeCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Idx { get; set; }
        public string Remarks { get; set; }
    }

    public class EvalStandardInsertValidator : AbstractValidator<EvalStandardInsertReq>
    {
        public EvalStandardInsertValidator()
        {
            RuleFor(c => c.EvalStandardId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
