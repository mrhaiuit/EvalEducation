using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemReeferInsertValidator))]
    public class ItemReeferInsertReq : ItemReeferBaseReq
    {
        public int? ITEM_KEY { get; set; }

        public decimal? CHILLED_TEMP { get; set; }

        public decimal? FLASHPOINT_TEMP { get; set; }

        public string FLASHPOINT_TYPE { get; set; }

        public decimal? FROZEN_TEMP { get; set; }

        public decimal? RFR_TRANS_TEMP { get; set; }

        public string RFR_TYPE { get; set; }

        public string CHILLED_TYPE { get; set; }

        public string FROZEN_TYPE { get; set; }

        public decimal? INGATE_TEMP { get; set; }

        public string IG_TEMP_TYPE { get; set; }

        public decimal? OUTGATE_TEMP { get; set; }

        public string OG_TEMP_TYPE { get; set; }

        public short? PRETRIP_INSPECTION { get; set; }

        public short? PRE_COOLING { get; set; }

        public DateTime? PTIDATE { get; set; }

        public short? NUMBER_PROBES { get; set; }

        public short? HUMIDITY { get; set; }

        public short? O2 { get; set; }

        public short? CO2 { get; set; }

        public DateTime? PLUG_TS { get; set; }

        public DateTime? UNPLUG_TS { get; set; }

        public short? RFR_CHART_COUNT { get; set; }

        public decimal? MIN_TEMP { get; set; }

        public decimal? MAX_TEMP { get; set; }

        public string IS_CONNECTED { get; set; }

        public string CONAIR { get; set; }

        public string TEMP_UNIT { get; set; }

        public int? UPD_CNT { get; set; }

        public string NO_PLUGIN_REQUIRED { get; set; }

        public string TEMP_CONTROL_SETTING { get; set; }

        public string NON_SNP_PTI_FLG { get; set; }

        public string YEAR_MADE { get; set; }

        public string MODEL_MADE { get; set; }

        public string VENTILATION { get; set; }

        public decimal? SETTING_TEMP { get; set; }

        public short? VENT_VOLUMETRIC_RATE { get; set; }

        public string VENT_VOLUMETRIC_UNIT { get; set; }

        public string REEFER_CHECKING_OK { get; set; }
    }

    public class ItemReeferInsertValidator : AbstractValidator<ItemReeferInsertReq>
    {
    }
}
