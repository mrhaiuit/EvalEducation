using System;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TruckInsertValidator))]
    public class TruckInsertReq : TruckBaseReq
    {
        public string SITE_ID { get; set; }

        public string TRK_ID { get; set; }

        public string INSTRUCTION { get; set; }

        public string GATE_IN_NO { get; set; }

        public DateTime? IG_TS { get; set; }

        public string GATE_OUT_NO { get; set; }

        public DateTime? OG_TS { get; set; }

        public string HIST_FLG { get; set; }

        public string OPER_NAME { get; set; }

        public decimal? GROSS { get; set; }

        public DateTime? OG_SECURITY_TS { get; set; }

        public string SECURITY_NAME { get; set; }

        public string TRK_LOC { get; set; }

        public int? TRK_SIZE { get; set; }

        public string TRK_USE { get; set; }

        public string ERROR_MSG { get; set; }

        public string TRUCKER_NAME { get; set; }

        public string IS_TEMP_TRK { get; set; }

        public string LIC_PLATE_NO { get; set; }

        public decimal? TARE { get; set; }

        public string CHASSIS_NO { get; set; }

        public string DRIVER_ID { get; set; }

        public string LANE_NO_IN { get; set; }

        public string LANE_NO_OUT { get; set; }

        public string BAT_NO { get; set; }

        public decimal? TRK_HEAD { get; set; }

        public decimal? CTR_WT_1 { get; set; }

        public decimal? CTR_WT_2 { get; set; }

        public decimal? ACTUAL_CTR_WT_1 { get; set; }

        public decimal? ACTUAL_CTR_WT_2 { get; set; }

        public int? CTR_QTY { get; set; }

        public string INSPECT_BY { get; set; }

        public decimal? TRUCK_MAX_GROSS { get; set; }

        public decimal? CHASSIS_MAX_GROSS { get; set; }

        public decimal? CHASSIS_GROSS { get; set; }

        public decimal? FREE_CHARGE_HOURS { get; set; }

        public string FREE_CHARGE_USER { get; set; }

        public string FREE_CHARGE_DESC { get; set; }
    }

    public class TruckInsertValidator : AbstractValidator<TruckInsertReq>
    {
        public TruckInsertValidator()
        {
            RuleFor(c => c.TRK_KEY)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TruckKeyIsNullOrEmpty).ToString());
        }
    }
}
