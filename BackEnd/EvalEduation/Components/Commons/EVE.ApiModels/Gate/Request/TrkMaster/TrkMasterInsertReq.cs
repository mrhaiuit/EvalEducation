using System;
using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkMasterInsertValidator))]
    public class TrkMasterInsertReq : TrkMasterBaseReq
    {
        public string SITE_ID { get; set; }

        public decimal? TRK_HEAD { get; set; }

        public string TRK_COMPANY_NAME { get; set; }

        public string TRK_USE { get; set; }

        public DateTime? CRT_TS { get; set; }

        public short? MAX_SLOT { get; set; }

        public decimal? TARE { get; set; }

        public decimal? MAX_GROSS { get; set; }

        public string DATA_SOURCE { get; set; }

        public DateTime? REGISTER_EXPIRY_TS { get; set; }

        public string REMARKS { get; set; }

        public string BAT_NO { get; set; }

        public string INTF_BAT_NO { get; set; }

        public string UPD_BAT_BY { get; set; }

        public DateTime? UPD_BAT_TS { get; set; }

        public string TRK_INT_FLG { get; set; }

        public string INTERNAL_TRK_ID { get; set; }

        public string TRUCK_NO { get; set; }

        public string SERIAL_NO { get; set; }
    }

    public class TrkMasterInsertValidator : AbstractValidator<TrkMasterInsertReq>
    {
        public TrkMasterInsertValidator()
        {
            RuleFor(c => c.TRK_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.TrkIdIsNullOrEmpty).ToString());
        }
    }
}
