using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorMethodInsertValidator))]
    public class OperationMethodInsertReq : OperationMethodBaseReq
    {
        public string CHARGE_CD { get; set; }

        public string CATEGORY { get; set; }

        public string SPEC_HDL_CD { get; set; }

        public string OPERATION_NAME { get; set; }

        public DateTime CRT_TS { get; set; }

        public string SITE_ID { get; set; }

        public string OPERATION_TYPE { get; set; }

        public string TERMINAL_ID { get; set; }

        public string MOVE_REASON_CD { get; set; }

        public string DIRECT_IMP_EXP { get; set; }

        public string PLACE_OF_RECEIPT { get; set; }

        public string PLACE_OF_DELIVERY { get; set; }

        public string OUT_VOYAGE_INFO_FLG { get; set; }

        public string CUSTOM_CHECKED_FLG { get; set; }

        public string SEAL_NO_FLG { get; set; }

        public string GATE_FLG { get; set; }

        public string TRANFER_LINK_DEPOT { get; set; }

        public string DO_YARD_CONSOL_REG { get; set; }

        public string GROUP_REPORT { get; set; }

        public string IS_USED { get; set; }

        public string IS_BARGE_OPER { get; set; }
    }

    public class OperatorMethodInsertValidator : AbstractValidator<OperationMethodInsertReq>
    {
        public OperatorMethodInsertValidator()
        {
            RuleFor(c => c.OPERATION_METHOD1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.OperationMethodIsNullOrEmpty).ToString());
        }
    }
}
