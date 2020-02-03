using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemChargesInsertValidator))]
    public class ItemChargesInsertReq : ItemChargesBaseReq
    {
        public long? ITEM_KEY { get; set; }

        public string CHARGE_CD { get; set; }

        public string DESCR { get; set; }

        public decimal? QUANTITY { get; set; }

        public decimal? CALCULATED_AMOUNT_TMP { get; set; }

        public decimal? BILLED_AMOUNT_TMP { get; set; }

        public string CURRENCY { get; set; }

        public string INTERNAL_BOOK_NUMBER { get; set; }

        public string INVOICE_NO { get; set; }

        public DateTime? INVOICE_DT { get; set; }

        public string OPER_NAME { get; set; }

        public DateTime? DEMDET_PAID_TO_DT { get; set; }

        public string INVOICE_PRE_CHAR { get; set; }

        public string REASON { get; set; }

        public string IS_CANCELLED { get; set; }

        public string SITE_ID { get; set; }

        public string BILL_LENGTH { get; set; }

        public string BILL_STS { get; set; }

        public string BILL_TYPE { get; set; }

        public string IS_DEMDET { get; set; }

        public string LINE_OPER { get; set; }

        public DateTime? CHARGES_TO_DT { get; set; }

        public string DEMDET_DESC { get; set; }

        public string RA_NO { get; set; }

        public string UNIT_CODE { get; set; }

        public string EIR_ID { get; set; }

        public string HAZ_FLG { get; set; }

        public string HAZ_CLASS { get; set; }

        public string OOG_FLG { get; set; }

        public string OOW_FLG { get; set; }

        public decimal? RATE { get; set; }

        public decimal? TAX_RATE { get; set; }

        public int? DEMDET_BATCH_ID { get; set; }

        public string CHARGE_BATCH_ID { get; set; }

        public string AGENT { get; set; }

        public decimal? CALCULATED_AMOUNT { get; set; }

        public decimal? BILLED_AMOUNT { get; set; }

        public decimal? BILLED_TAX_AMOUNT { get; set; }

        public decimal? CALCULATED_DISCOUNT { get; set; }

        public decimal? INVDETAIL_ID { get; set; }

        public int? RATE_ID { get; set; }

        public DateTime? EXEC_TS { get; set; }

        public decimal? DISCOUNT_RATE { get; set; }

        public string SERVICE_CHARGE { get; set; }

        public string COMMITTED_FLG { get; set; }

        public DateTime? COMMITTED_TS { get; set; }

        public string USER_CONFIRM { get; set; }

        public string IP_ADDRESS { get; set; }
    }

    public class ItemChargesInsertValidator : AbstractValidator<ItemChargesInsertReq>
    {
    }
}
