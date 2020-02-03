using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemInsertValidator))]
    public class ItemInsertReq : ItemBaseReq
    {
        public string SITE_ID { get; set; }

        public string OWNER { get; set; }

        public string ITEM_NO { get; set; }

        public string FEL { get; set; }

        public string AGENT { get; set; }

        public string LINE_OPER { get; set; }

        public string ARR_BY { get; set; }

        public string ARR_CAR { get; set; }

        public DateTime? ARR_TS { get; set; }

        public string DEP_BY { get; set; }

        public string DEP_CAR { get; set; }

        public DateTime? DEP_TS { get; set; }

        public string CATEGORY { get; set; }

        public string BILL_OF_LADING { get; set; }

        public string BOOK_NO { get; set; }

        public string CONSIGNEE { get; set; }

        public string CONSIGNOR { get; set; }

        public decimal? GROSS { get; set; }

        public decimal? CARGO_WEIGHT { get; set; }

        public string CTR_OWNER { get; set; }

        public string CUSTOM_CHECK_FLG { get; set; }

        public string ORG_PORT { get; set; }

        public string LOAD_PORT { get; set; }

        public string DISCH_PORT { get; set; }

        public string LL_DISCH_PORT { get; set; }

        public string FDISCH_PORT { get; set; }

        public string FIN_DEST { get; set; }

        public string IS_ATTACH { get; set; }

        public string IS_CFS { get; set; }

        public string IS_COMMENTS { get; set; }

        public string IS_CONSOLE { get; set; }

        public string IS_CTR { get; set; }

        public string IS_DAMAGED { get; set; }

        public string IS_DANGEROUS { get; set; }

        public string IS_DOOR_OPEN { get; set; }

        public string IS_FCL_ADD { get; set; }

        public string IS_FOLDED { get; set; }

        public string IS_OOG { get; set; }

        public string IS_PRETRIP { get; set; }

        public string IS_REEFER { get; set; }

        public string IS_SHORING { get; set; }

        public string IS_TOPPING { get; set; }

        public string ORIG_ISO { get; set; }

        public string ISO { get; set; }

        public string ITEM_TYPE { get; set; }

        public decimal? LENGTH { get; set; }

        public decimal? HEIGHT { get; set; }

        public decimal? TARE { get; set; }

        public decimal? MAX_GROSS { get; set; }

        public string MANIFEST_NO { get; set; }

        public string OPER_NAME { get; set; }

        public string ECN_NO { get; set; }

        public string ICN_NO { get; set; }

        public string PLACE_OF_DELIVERY { get; set; }

        public string PLACE_OF_RECEIPT { get; set; }

        public string RELEASE_NO { get; set; }

        public string SEAL_NO_CURRENT { get; set; }

        public string SPEC_HNDL { get; set; }

        public string HIST_FLG { get; set; }

        public DateTime? ORG_CRT_TS { get; set; }

        public int? UPD_CNT { get; set; }

        public string CUST_RELEASE_MARK { get; set; }

        public string TRANSFER_CD { get; set; }

        public string REASON_FOR_TRANSFER { get; set; }

        public string EXP_CTR_REMARK { get; set; }

        public string COPRAR_DISCHARGE { get; set; }

        public string TERMINAL_ID { get; set; }

        public string OP_TERMINAL { get; set; }

        public string OP_SUBTERMINAL { get; set; }

        public string GRADE { get; set; }

        public int? RA_KEY { get; set; }

        public int? BOOK_KEY { get; set; }

        public string BB_ID { get; set; }

        public int? BUNDLE_TO { get; set; }

        public int? UNBUNDLE_FROM { get; set; }

        public DateTime? CHARGES_TO_DT { get; set; }

        public int FREE_DAYS { get; set; }

        public string DIRECT_IMPORT_DELIVERY { get; set; }

        public string SLOT_CODE { get; set; }

        public string SLOT_CODE_OUT { get; set; }

        public string ORG_ARR_CAR { get; set; }

        public DateTime? ORG_ARR_TS { get; set; }

        public string ORG_IN_VOYAGE { get; set; }

        public string DELIVERY_METHOD { get; set; }

        public string DIRECT_LOAD_FLG { get; set; }

        public string TURNING_CHE { get; set; }

        public string CUST_REG_NO { get; set; }

        public string EXIT_VES_CD { get; set; }

        public string EXIT_VOYAGE { get; set; }

        public DateTime? DEPOT_ARR_TS { get; set; }

        public string DOMESTIC { get; set; }

        public string EXPORT_CONFIRMED { get; set; }

        public DateTime EXPORT_CONFIRMED_TS { get; set; }

        public string COPRAR_LOAD { get; set; }

        public string SPECIAL_HDL_CODE { get; set; }

        public string INTER_MOVE_CODE { get; set; }

        public string SPECIAL_GEAR { get; set; }

        public string RESTOW_TYPE { get; set; }

        public string EIR_ID { get; set; }

        public string CMID { get; set; }

        public DateTime EXPIRY_DATE { get; set; }

        public string INSPECT_BY_R { get; set; }

        public string INSPECT_BY_D { get; set; }

        public string PORT_TRANS_BATCH_NO { get; set; }

        public string BOOK_ASSIGN_BY { get; set; }

        public string RAIL_CUSTOM_STATUS { get; set; }
    }

    public class ItemInsertValidator : AbstractValidator<ItemInsertReq>
    {
    }
}
