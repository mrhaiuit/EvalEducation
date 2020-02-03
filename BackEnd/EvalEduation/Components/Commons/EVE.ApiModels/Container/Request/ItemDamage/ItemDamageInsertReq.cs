using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemDamageInsertValidator))]
    public class ItemDamageInsertReq : ItemDamageBaseReq
    {
        public long? ITEM_KEY { get; set; }

        public string DAMAGE_CD { get; set; }

        public short? DAMAGE_SEQ { get; set; }

        public string DAMAGE_DESC { get; set; }

        public decimal? MAN_HOUR_REPAIRS { get; set; }

        public DateTime? FIXEDUP_TS { get; set; }

        public string FIXEDUP_OPER { get; set; }

        public string CHARGE_TO { get; set; }

        public string INSPECT_BY { get; set; }

        public string DAMAGE_LOC { get; set; }

        public int? UPD_CNT { get; set; }

        public string DAMAGE_BY { get; set; }

        public string SERVICE_PROVIDER { get; set; }

        public string DAMAGE_INSPECT_LOCATION { get; set; }

        public string DAMAGE_DIMENSION { get; set; }

        public string SERVICE_CD { get; set; }

        public decimal? SERVICE_KEY { get; set; }
    }

    public class ItemDamageInsertValidator : AbstractValidator<ItemDamageInsertReq>
    {
    }
}
