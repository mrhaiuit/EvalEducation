using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkTransactInsertValidator))]
    public class TrkTransactInsertReq : TrkTransactBaseReq
    {
        public int? ITEM_KEY { get; set; }

        public string R_D { get; set; }

        public string OPER_NAME { get; set; }

        public string IG_OPER_NAME { get; set; }

        public string OG_OPER_NAME { get; set; }

        public DateTime? COMPL_TS { get; set; }

        public DateTime? UPD_TS { get; set; }

        public string EIR_FLG { get; set; }

        public int? LANE_NO { get; set; }

        public string CARRIER_TYPE { get; set; }

        public string HIST_FLG { get; set; }

        public string CTNR_ON_TRUCK { get; set; }

        public DateTime? CRT_TS { get; set; }

        public string EIR_ID { get; set; }

        public DateTime? EIR_IG_TS { get; set; }

        public DateTime? EIR_OG_TS { get; set; }

        public decimal? TRUCK_LOAD_WEIGHT { get; set; }
    }

    public class TrkTransactInsertValidator : AbstractValidator<TrkTransactInsertReq>
    {
    }
}
