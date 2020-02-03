using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemOogInsertValidator))]
    public class ItemOogInsertReq : ItemOogBaseReq
    {
        public long? ITEM_KEY { get; set; }

        public short? OOG_BACK { get; set; }

        public short? OOG_FRONT { get; set; }

        public short? OOG_HEIGHT { get; set; }

        public short? OOG_LEFT { get; set; }

        public short? OOG_LENGTH { get; set; }

        public short? OOG_RIGHT { get; set; }

        public short? OOG_TOP { get; set; }

        public short? OOG_WIDTH { get; set; }

        public string LEN_UNIT { get; set; }

        public short? BB_NUM { get; set; }

        public string BB_TYPE { get; set; }

        public int? UPD_CNT { get; set; }

        public string CABLE_REQUIRED { get; set; }

        public string OOG_WEIGHT_FLG { get; set; }

        public string OOG_HEIGHT_FLG { get; set; }

        public string OOG_LENGTH_FLG { get; set; }

        public string OOG_WIDTH_FLG { get; set; }
    }

    public class ItemOogInsertValidator : AbstractValidator<ItemOogInsertReq>
    {
    }
}
