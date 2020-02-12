using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalPeriodInsertValidator))]
    public class EvalPeriodInsertReq : EvalPeriodBaseReq
    {
        public string PeriodName { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public string Remark { get; set; }
    }

    public class EvalPeriodInsertValidator : AbstractValidator<EvalPeriodInsertReq>
    {
        public EvalPeriodInsertValidator()
        {
            RuleFor(c => c.EvalPeriodId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
