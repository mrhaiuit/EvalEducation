using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EvalDetailInsertValidator))]
    public class EvalDetailInsertReq : EvalDetailBaseReq
    {
        public Nullable<int> EvalMasterId { get; set; }
        public Nullable<int> EvalCriteriaId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string EvalResultCode { get; set; }
        public string Sample { get; set; }
        public string Attachment { get; set; }
        public Nullable<int> EvalForEmployee { get; set; }
    }

    public class EvalDetailInsertValidator : AbstractValidator<EvalDetailInsertReq>
    {
        public EvalDetailInsertValidator()
        {
            RuleFor(c => c.EvalDetailId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
