using System;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(PregateTransactInsertValidator))]
    public class PregateTransactInsertReq : PregateTransactBaseReq
    {
        public string SITE_ID { get; set; }

        public string BATCH_ID { get; set; }

        public string R_D { get; set; }

        public DateTime? STORAGE_EXPIRY_TS { get; set; }

        public DateTime? CUSTOM_EXPIRY_TS { get; set; }

        public DateTime? TERMINAL_EXPIRY_TS { get; set; }

        public DateTime? LINER_EXPIRY_TS { get; set; }

        public string HIST_FLG { get; set; }

        public string ORDER_NO { get; set; }

        public string OPERATION_METHOD { get; set; }

        public string REMARKS { get; set; }

        public string RA_NO { get; set; }

        public DateTime? PICKUP_TS { get; set; }

        public string AREA { get; set; }

        public string RECEIVAL_PLACE { get; set; }

        public string ITEM_NO { get; set; }

        public string ISO_CODE { get; set; }

        public string CTR_LENGTH { get; set; }

        public decimal? CTR_HEIGHT { get; set; }

        public string CTR_TYPE { get; set; }

        public string OPERATION_TYPE { get; set; }

        public string LINE_OPER { get; set; }

        public int? REL_NO { get; set; }

        public string TFC_CODE { get; set; }

        public string CONSIGNOR { get; set; }

        public string PLACE_OF_DELIVERY { get; set; }

        public string LL_POD { get; set; }

        public string BOOK_NO { get; set; }

        public string CREATED_BY { get; set; }

        public decimal? GROSS { get; set; }

        public DateTime? REFEER_EXPIRY_TS { get; set; }

        public string VES_CD { get; set; }

        public string FPOD { get; set; }

        public string VES_ID { get; set; }

        public string OUT_VOYAGE { get; set; }

        public string SEAL_NO { get; set; }

        public decimal? TEMPERATURE { get; set; }

        public string FEL { get; set; }

        public string ORG_ARR_CAR { get; set; }

        public string ORG_IN_VOYAGE { get; set; }

        public DateTime? ORG_ARR_TS { get; set; }

        public string ORG_ARR_BY { get; set; }

        public string EXIT_DEP_CAR { get; set; }

        public string EXIT_POD { get; set; }

        public string EXIT_FPOD { get; set; }

        public string EXIT_DEP_BY { get; set; }

        public string CATEGORY { get; set; }

        public string REG_OUTSIDE { get; set; }

        public string KEY_INTF { get; set; }

        public decimal? NOT_USED { get; set; }

        public DateTime? DELV_OUT_GATE_TS { get; set; }

        public long? RA_KEY { get; set; }

        public string SERVICE { get; set; }

        public int? ITEM_KEY { get; set; }

        public string HAZ_FLG { get; set; }

        public string FL_FLG { get; set; }

        public string OOG_FLG { get; set; }

        public string RFR_FLG { get; set; }

        public string OOW_FLG { get; set; }

        public string MANAGE_BY { get; set; }

        public int? PRINTED_CNT { get; set; }

        public string TRANSFER_REASON_CD { get; set; }

        public DateTime? STORAGE_AS_AT_TS { get; set; }

        public string OWNER { get; set; }

        public string GATE_NO { get; set; }

        public string ARR_VES_NAME { get; set; }

        public string BILL_OF_LADING { get; set; }

        public string INTEGRATE_INV_FLG { get; set; }

        public string INTEGRATE_INV_TRANS_ID { get; set; }

        public string INTEGRATE_INV_MSG { get; set; }

        public string SLOT_CODE { get; set; }

        public int? EPORT_REGISTER_BY { get; set; }

        public int? ID_VCDL { get; set; }
    }

    public class PregateTransactInsertValidator : AbstractValidator<PregateTransactInsertReq>
    {
        public PregateTransactInsertValidator()
        {
            RuleFor(c => c.EIR_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.EirIdIsNullOrEmpty).ToString());
        }
    }
}
