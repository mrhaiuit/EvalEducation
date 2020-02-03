using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(DepotInsertValidator))]
    public class DepotInsertReq : DepotBaseReq
    {
        public string DEPOT_NAME { get; set; }

        public string ADDRESS { get; set; }

        public string IS_VIRTUAL { get; set; }

        public string IS_LINKED { get; set; }

        public DateTime? AS_AT_TS { get; set; }

        public DateTime? EXPIRY_TS { get; set; }

        public string IS_MANAGE_CLOSING_TS { get; set; }

        public short? DEFAULT_INT_CLOSING_TS { get; set; }

        public short? DEFAULT_DOM_CLOSING_TS { get; set; }

        public string SITE_CODE { get; set; }

        public string IS_PORT { get; set; }
    }

    public class DepotInsertValidator : AbstractValidator<DepotInsertReq>
    {
        public DepotInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.DEPOT1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.DepotIsNullOrEmpty).ToString());
        }
    }
}
