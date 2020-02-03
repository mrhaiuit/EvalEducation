using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(LineOperInsertValidator))]
    public class LineOperInsertReq : LineOperBaseReq
    {
        public string CUST_TYPE { get; set; }

        public string FULL_NAME { get; set; }

        public string PHONE { get; set; }

        public string FAX { get; set; }

        public string MOBILE { get; set; }

        public string ADDR1 { get; set; }

        public string ADDR2 { get; set; }

        public string ADDR3 { get; set; }

        public string ADDR4 { get; set; }

        public string EMAIL { get; set; }

        public string CONTACT_NAME { get; set; }

        public string ACC_NO { get; set; }

        public string STOP_YN { get; set; }

        public string OPER_NAME { get; set; }

        public decimal? DEFAULT_DETENTION_DAYS { get; set; }

        public string CUSTOMS_LOP_CODE { get; set; }

        public string DISCH_DAY_INCLUDED { get; set; }

        public decimal? CUST_PM_FREEDAYS { get; set; }

        public string IMP_PLUG_ON { get; set; }

        public string IMP_PLUG_OFF { get; set; }

        public string EXP_PLUG_ON { get; set; }

        public string EXP_PLUG_OFF { get; set; }

        public string FTP_HOST { get; set; }

        public string FTP_USER_NAME { get; set; }

        public string FTP_PASSWORD { get; set; }

        public string FTP_IN_PATH { get; set; }

        public string FTP_OUT_PATH { get; set; }

        public string FTP_IN_ACTIVE_FLG { get; set; }

        public string FTP_OUT_ACTIVE_FLG { get; set; }

        public string FTP_OUT_EDIFACT { get; set; }

        public string FLATFILE_OUT_FLG { get; set; }

        public string TOPS_LINE_OPER { get; set; }

        public decimal? MAX_STORAGE_DAYS { get; set; }

        public string SLOT_CODE { get; set; }

        public string DEPOT { get; set; }

        public string EXTENSION_TIME_CONV { get; set; }

        public string EXTENSION_TIME_FR { get; set; }

        public string EXTENSION_TIME_TO { get; set; }

        public string CONV_LINER_MTY { get; set; }

        public decimal? TEMP_UPPER { get; set; }

        public decimal? TEMP_LOWER { get; set; }

        public string LINER_SHORT_NAME { get; set; }

        public string YARD_AREA_EMPTY_DELV { get; set; }

        public string EXPIRE_FLG { get; set; }

        public string CHANGE_INV_VND { get; set; }
    }

    public class LineOperInsertValidator : AbstractValidator<LineOperInsertReq>
    {
        public LineOperInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.LINE_OPER1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.LineOperIsNullOrEmpty).ToString());
        }
    }
}
