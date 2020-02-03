using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(ConvertToIsoInsertValidator))]
    public class ConvertToIsoInsertReq : ConvertToIsoBaseReq
    {
        public string USE_DEFAULT { get; set; }

        public string DESCR { get; set; }

        public decimal? LENGTH { get; set; }

        public decimal? HEIGHT { get; set; }

        public decimal? TARE { get; set; }

        public decimal? WIDTH { get; set; }

        public string CUSTOMS_ISO { get; set; }

        public string CTR_FLG { get; set; }

        public string REEFER_FLG { get; set; }

        public string CTR_TYPE { get; set; }

        public string TOPX_ISO { get; set; }
    }

    public class ConvertToIsoInsertValidator : AbstractValidator<ConvertToIsoInsertReq>
    {
        public ConvertToIsoInsertValidator()
        {
            RuleFor(c => c.ISO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.IsoIsNullOrEmpty).ToString());
        }
    }
}
