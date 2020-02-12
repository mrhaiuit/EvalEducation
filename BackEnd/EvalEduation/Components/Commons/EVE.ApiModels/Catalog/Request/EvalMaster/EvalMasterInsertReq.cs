using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalMasterInsertValidator))]
    public class EvalMasterInsertReq : EvalMasterBaseReq
    {
        public Nullable<int> Year { get; set; }
        public string EvalTypeCode { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Active { get; set; }
        public string EvalStateCode { get; set; }
    }

    public class EvalMasterInsertValidator : AbstractValidator<EvalMasterInsertReq>
    {
        public EvalMasterInsertValidator()
        {
            RuleFor(c => c.EvalMasterId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
