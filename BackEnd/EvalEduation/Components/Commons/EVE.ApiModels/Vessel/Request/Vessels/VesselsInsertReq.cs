using System;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Vessel
{
    [Validator(typeof(VesselsInsertValidator))]
    public class VesselsInsertReq : VesselsBaseReq
    {
        public string SITE_ID { get; set; }

        public string VES_CLASS { get; set; }

        public string VES_TYPE { get; set; }

        public string VES_NAME { get; set; }

        public string HATCH_TYPE { get; set; }

        public decimal SWL_GEAR { get; set; }

        public decimal DRAFT { get; set; }

        public string CALL_SIGN { get; set; }

        public string LLOYDS_NO { get; set; }

        public string REG_FLG { get; set; }

        public decimal GROSS_TONS { get; set; }

        public decimal DWT { get; set; }

        public decimal VES_LEN { get; set; }

        public short CRANES { get; set; }

        public int NOMINAL_TEU { get; set; }

        public int STOWAGE_ON_DECK { get; set; }

        public int STOWAGE_BELOW_DECK { get; set; }

        public int ALT_ON_DECK { get; set; }

        public int ALT_BELOW_DECK { get; set; }

        public int FOURTYFIVE_FTS { get; set; }

        public int INTAKE_14T { get; set; }

        public int STACK_WT_HATCH20 { get; set; }

        public int STACK_WT_HATCH40 { get; set; }

        public int STACK_WT_HOLD20 { get; set; }

        public int STACK_WT_HOLD40 { get; set; }

        public int RF_PLUGS { get; set; }

        public int HOLDS { get; set; }

        public short HATCHES { get; set; }

        public decimal SPEED { get; set; }

        public string PREFER_BERTH_NO { get; set; }

        public string PREFER_BERTH_SIDE { get; set; }

        public decimal SAFE_DISTANCE_FWD { get; set; }

        public decimal SAFE_DISTANCE_AFT { get; set; }

        public string REMARKS { get; set; }

        public decimal VES_BREADTH { get; set; }

        public int MAX_TEU { get; set; }

        public decimal GROSS { get; set; }

        public decimal MAX_DRAFT { get; set; }

        public decimal BEAM { get; set; }

        public short CRANE_RATE { get; set; }

        public int UPD_CNT { get; set; }

        public string MANUFACT_YEAR { get; set; }

        public string IS_VIRTUAL { get; set; }

        public string INTERFACE_TOPX { get; set; }

        public string LINE_OPER { get; set; }

        public short MAX_DAY_SCHEDULE { get; set; }

        public short LOOP_DAYS { get; set; }

        public string IS_USED { get; set; }

        public DateTime REGIST_EXPIRY_DATE { get; set; }

        public int MAX_TEU_FULL { get; set; }

        public string VES_IMO_NUMBER { get; set; }

        public string VES_PORT { get; set; }
    }

    public class VesselsInsertValidator : AbstractValidator<VesselsInsertReq>
    {
        public VesselsInsertValidator()
        {
            RuleFor(c => c.VES_CD)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.VesCdIsNullOrEmpty).ToString());
        }
    }
}
